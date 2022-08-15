using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superliga.Entities;

namespace Superliga.Data
{
    public class SetData
    {
        public string[] lineas;

        public SetData()
        {
            ReadCvs();
        }

        public void ReadCvs()
        {

            var reader = new StreamReader(File.OpenRead(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv"));
            lineas = System.IO.File.ReadAllLines(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv");
           
        }
    }
}
