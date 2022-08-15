using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superliga.Data
{
    public  sealed class BaseData
    {
        private readonly static BaseData _instance = new BaseData();
        public static BaseData Instance
        {
            get { return _instance;}
        }

        public string[] data { get;  private set; }

        protected BaseData()
        {
            ReadCvs();
        }

        private void ReadCvs()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv"));
            data = System.IO.File.ReadAllLines(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv");
        }
        
    }
}
