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
    public class Names
    {
        string name;
        int coun;
    }
    public class SetData
    {
        public DataTable dtExcelTable;
        public List<Names> listNames;
        public string test = "ok";

        public SetData()
        {
            dtExcelTable = new DataTable();
            listNames = new List<Names>();
            ReadCvs();
            
        }

        public void ReadCvs()
        {
            string[] lineas;

            dtExcelTable.Rows.Clear();
            dtExcelTable.Columns.Clear();
            dtExcelTable.Columns.Add("Name");
            dtExcelTable.Columns.Add("Age");
            dtExcelTable.Columns.Add("Team");
            dtExcelTable.Columns.Add("State");
            dtExcelTable.Columns.Add("Studies");

            var reader = new StreamReader(File.OpenRead(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv"));
            List<string> listNames = new List<string>();

            lineas = System.IO.File.ReadAllLines(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv");
            //var test=lineas.Where(li => li.Contains("soltero"));
            //var campos1 = lineas[0].Split(';');
            //var test2 = 0;
            //var test3 = Array.FindAll(lineas, c => c.Split(';').Contains("Soltero"));
            //var test4 = 0;




            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                var dr = dtExcelTable.NewRow();

                //llena tabla con casados universitarios
                if (values[3].ToLower().Equals("casado") && values[4].ToLower().Equals("universitario"))
                {
                    var d = 0;
                    while (d != 5)
                    {
                        dr[d] = values[d];
                        d = d + 1;
                    }
                    dtExcelTable.Rows.Add(dr);

                }
                //compara nombre



            }
        }
    }
}
