using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackupSaleFromLog
{
    public class CLog
    {
        public string date, venue, transactions, sales_revenue, units_sold;

        public CLog(string date, string venue, string transactions, string sales_revenue, string units_sold)
        {
            this.date = date;
            this.venue = venue;
            this.transactions = transactions;
            this.sales_revenue = sales_revenue;
            this.units_sold = units_sold;
        }
    }
}
