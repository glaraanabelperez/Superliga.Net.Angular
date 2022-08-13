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
        public Partner partner { get; set; }

        public SetData()
        {
             partner= new Partner();
            ReadCvs();

        }

        public void ReadCvs()
        {
            //List<string> lineas = new List<string>();
            //using (StreamReader sr = new StreamReader(Path))
            //{
            //    sr.ReadLine();
            //    while (sr.Peek() != -1)
            //    {
            //        lineas.Add(sr.ReadLine());
            //    }
            //}

            var dtExcelTable = new DataTable();
            dtExcelTable.Rows.Clear();
            dtExcelTable.Columns.Clear();
            dtExcelTable.Columns.Add("Nombre");
            dtExcelTable.Columns.Add("Edad");

            var reader = new StreamReader(File.OpenRead(@"C:\Users\Lara\source\repos\Superliga.Net.Angular\Superliga\DataCvs\socios.csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();

            var d = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                var dr = dtExcelTable.NewRow();
                dr[d] = values[0];
                d = d + 1;

                listA.Add(values[0]);
                listB.Add(values[1]);

                dtExcelTable.Rows.Add(dr);


                
            }
        }
    }
}
