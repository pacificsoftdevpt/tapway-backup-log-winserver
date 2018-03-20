using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BackupSaleFromLog
{
    public static class FileHelper
    {
        public static string[] ReadAllLines(string path)
        {
            List<string> lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                    lines.Add(reader.ReadLine());
            }
            return lines.ToArray();
        }

    }
}
