using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcher
{
    class Parser
    {
        public IList<Record> ParseData(string path)
        {
            string managerName = Path.GetFileName(path).Split('_').First();
            IList<Record> records = new List<Record>();
            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("windows-1251")))
            {
                while (!sr.EndOfStream)
                {
                    var param = sr.ReadLine().Split(';');
                    records.Add(new Record(managerName, param[0], param[1], param[2], param[3]));
                }
            }
            return records;
        }

    }
}
