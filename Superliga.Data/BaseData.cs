using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superliga.Data
{
    public class BaseData
    {
        public string[] data { get; protected set; }

        public BaseData()
        {
            ReadCvs();
        }

        public void ReadCvs()
        {

            var reader = new StreamReader(File.OpenRead(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv"));
            data = System.IO.File.ReadAllLines(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv");

        }

    }
}
