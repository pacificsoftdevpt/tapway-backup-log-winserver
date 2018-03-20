using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.Timers;

namespace BackupSaleFromLog
{
    public partial class MainForm : Form
    {
        private const string defaultValueFileName = "defaultValue.txt";
        private const int maxLineLog = 500;
        private const string API_URL = "http://tapway.elasticbeanstalk.com/receiver/sales/receive?access_token=5d1d8c0be2c4476fb3b347d2b851d950";

        private bool enableClose = false;

        public MainForm()
        {
            InitializeComponent();
            InitParams();
        }

        private void InitParams()
        {
            if (!File.Exists(defaultValueFileName))
            {
                File.WriteAllText(defaultValueFileName, @"C:\epos\History\,");
            }

            string readText = File.ReadAllText(defaultValueFileName);
            string[] arrDefaultValue = readText.Split(',');
            txtPath.Text = arrDefaultValue[0];
            txtVenueID.Text = arrDefaultValue[1];

            buttonSendData.Enabled = false;
            if (txtPath.Text == "")
            {
                labelNotiEnterPath.Visible = true;
            }

            if (txtVenueID.Text == "")
            {
                labelNotiEnterVenue.Visible = true;
            }

            setEnableForSendButton();

            SetUpTimer(new TimeSpan(9, 57, 00));
        }

        // PROCESS FUNCTION
        private void setEnableForSendButton()
        {
            if (txtPath.Text != "" && txtVenueID.Text != "")
            {
                buttonSendData.Enabled = true;
            }
            else
            {
                buttonSendData.Enabled = false;
            }
        }

        private void setVisibleForNotiPath()
        {
            if (txtPath.Text == "")
            {
                labelNotiEnterPath.Visible = true;
            }
            else
            {
                labelNotiEnterPath.Visible = false;
            }
        }

        private void setVisibleForNotiVenueID()
        {
            if (txtVenueID.Text == "")
            {
                labelNotiEnterVenue.Visible = true;
            }
            else
            {
                labelNotiEnterVenue.Visible = false;
            }
        }

        private void appendRichTextBox(string text, Color color)
        {
            this.richTextBoxLog.Invoke((MethodInvoker)delegate
            {
                if (richTextBoxLog.Lines.Length > maxLineLog)
                {
                    richTextBoxLog.ReadOnly = false;
                    richTextBoxLog.SelectionStart = 0;
                    richTextBoxLog.SelectionLength = richTextBoxLog.Text.IndexOf("\n", 0) + 1;
                    richTextBoxLog.SelectedText = "";
                    richTextBoxLog.ReadOnly = true;
                }
                richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
                richTextBoxLog.SelectionLength = 0;
                richTextBoxLog.SelectionColor = color;
                richTextBoxLog.AppendText("[" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "]: " + text + "\n");
                richTextBoxLog.SelectionColor = richTextBoxLog.ForeColor;
            });
        }

        private void sendDataToServer(string data)
        {
            using (var client = new WebClient())
            {

                var postData = new NameValueCollection();
                postData["DATA"] = data;
                try
                {
                    appendRichTextBox("Start upload data", Color.Black);
                    var response = client.UploadValues(API_URL, postData);
                    var responseText = Encoding.Default.GetString(response);

                    if (responseText.IndexOf("\"status\": \"ok\"") >= 0)
                    {
                        appendRichTextBox("Successfully upload data", Color.Green);
                    }
                    else
                    {
                        MessageBox.Show(responseText);
                        if (responseText.IndexOf("\"error\": \"invalid_venue\"") >= 0) 
                        {
                            appendRichTextBox("Invalid Venue", Color.Red);
                        }
                    }
                }
                catch (Exception err)
                {
                    appendRichTextBox(err.Message, Color.Red);
                }
            }
        }

        private void readInfoFile()
        {
            List<CLog> listData = new List<CLog>();

            var startDate = dateTimePickerStart.Value;
            var endDate = dateTimePickerEnd.Value;
            //if (isDaily)
            //{
              //  startDate = DateTime.Now.AddDays(-1); // run at midnight (new day) => make -1 day
               // endDate = DateTime.Now.AddDays(-1);
            //}

            foreach (DateTime day in Library.EachDay(startDate, endDate))
            {
                string date = day.Year + "-" + Library.formatNumber10(day.Month) + "-" + Library.formatNumber10(day.Day);
                string pathFileNameLog = txtPath.Text + day.Year + Library.formatNumber10(day.Month) + @"\" + day.Year + Library.formatNumber10(day.Month) + Library.formatNumber10(day.Day) + ".log";

                try
                {
                    var lines = FileHelper.ReadAllLines(pathFileNameLog);
                    
                    int transactions = 0, sales_revenue = 0, units_sold = 0;

                    for (int i = 0; i < lines.Length; i++ )
                    {
                        string line = lines[i];
                        
                        string[] splitBySumAmount = line.Split(new string[] { "sum amount=" }, StringSplitOptions.None);
                        
                        if (splitBySumAmount.Length == 2)
                        {
                            string stringSalses = "";
                            string trimmedData = splitBySumAmount[1].Trim();
                            int j = 0;
                            while (j < trimmedData.Length && trimmedData[j] >= '0' && trimmedData[j] <= '9')
                            {
                                stringSalses += trimmedData[j];
                                j++;
                            }
                            if (stringSalses != "")
                            {
                                sales_revenue += int.Parse(stringSalses);
                            }
                        }
                        
                        if (line.Split(new string[] { "F10 - Payment" }, StringSplitOptions.None).Length == 2)
                        {
                            transactions++;
                        }
                        if (Library.IsDigitsOnly(line.Substring(22, line.Length - 22)))
                        {
                            units_sold += 1;
                        }
                    }
                    listData.Add(new CLog(date, txtVenueID.Text, transactions.ToString(), sales_revenue.ToString(), units_sold.ToString()));
                }
                catch (Exception err)
                {
                    appendRichTextBox(err.Message, Color.Red);
                }
            }

            string stringData = "[";
            foreach(var log in listData)
            {
                if (stringData != "[")
                {
                    stringData += ",";
                }
                stringData += "{\"date\": \"" + log.date + "\",";
                stringData += "\"venue\": \"" + log.venue + "\",";
                stringData += "\"transactions\": \"" + log.transactions + "\",";
                stringData += "\"sales_revenue\": \"" + log.sales_revenue + "\",";
                stringData += "\"units_sold\": \"" + log.units_sold + "\"}";
            }
            stringData += "]";

            //stringData = "[{\"date\":\"2018-03-02\",\"venue\":\"20320\",\"sales_revenue\":\"1000\",\"units_sold\":\"10\",\"transactions\":\"10\"}]";

            if (stringData != "[]") sendDataToServer(stringData);
            else appendRichTextBox("Date range do not have file", Color.Blue);
                
            this.progressBarLoading.Invoke((MethodInvoker)delegate
            {
                progressBarLoading.Visible = false;
            });

            this.buttonSendData.Invoke((MethodInvoker)delegate
            {
                buttonSendData.Enabled = true;
            });
        }

        private void SetUpTimer(TimeSpan alertTime)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                Thread postLogDataThread = new Thread(new ThreadStart(readInfoFile));
                postLogDataThread.Start();
            }
        }

        // EVENT FUNCTION
        private void buttonChangePath_Click(object sender, EventArgs e)
        {
            if (txtPath.ReadOnly)
            {
                txtPath.ReadOnly = false;
                buttonChangePath.Text = "Save Path";
            }
            else
            {
                txtPath.ReadOnly = true;
                buttonChangePath.Text = "Path";
                File.WriteAllText(defaultValueFileName, txtPath.Text + "," + txtVenueID.Text);
            }

            setVisibleForNotiPath();
            setEnableForSendButton();
        }

        private void buttonChangeVenueID_Click(object sender, EventArgs e)
        {
            if (txtVenueID.ReadOnly)
            {
                txtVenueID.ReadOnly = false;
                buttonChangeVenueID.Text = "Save Venue ID";
            }
            else
            {
                txtVenueID.ReadOnly = true;
                buttonChangeVenueID.Text = "Venue ID";
                File.WriteAllText(defaultValueFileName, txtPath.Text + "," + txtVenueID.Text);
            }

            setVisibleForNotiVenueID();
            setEnableForSendButton();
        }

        private void buttonSendData_Click(object sender, EventArgs e)
        {
            progressBarLoading.Style = ProgressBarStyle.Marquee;
            progressBarLoading.MarqueeAnimationSpeed = 10;
            progressBarLoading.Visible = true;
            buttonSendData.Enabled = false;

            Thread postLogDataThread = new Thread(new ThreadStart(readInfoFile));
            postLogDataThread.Start();
        }

        private void txtVenueID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value.Date > dateTimePickerEnd.Value.Date)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value.Date > dateTimePickerEnd.Value.Date)
            {
                dateTimePickerStart.Value = dateTimePickerEnd.Value;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!enableClose)
                {
                    e.Cancel = true;
                    Hide();
                    new Thread(() =>
                    {
                        notifyIcon.ShowBalloonTip(2000, "Tapway Sale Backup Log", "Right click to select Show or Exit", ToolTipIcon.Info);
                    }).Start();
                }
                else
                {
                    enableClose = false;
                }
            }
        }

        private void toolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            enableClose = true;
            Close();
        }
    }
}
