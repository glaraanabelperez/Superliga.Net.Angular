using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superliga.Data;
using Superliga.Entities;

namespace Superliga.Logic
{

    public class PartnerLogic : BaseData
    {

        public int CountPepopleRegistered()
        {
            return Convert.ToInt32(data.lineas.Count());
        }

        //Promedio edad socios registrados
        public int GetAgeAverage()
        {
            var agesSum = from x in data.lineas
            group x by x.Split(';')[1] into t
            select t.Sum( x => x[1]);

            int total = CountPepopleRegistered();
            var result = Convert.ToInt32(agesSum)/ total;

            return result;
        }

        //Devuelve listado con las 100 primeras personas casadas, con estudios Universitarios, ordenadas de menor a mayor según su edad.
        public List<PartnerDto> GetTopOneHundred()
        {
            var records = data.lineas
                .Where(r => r.Split(';')[3].Contains("Soltero") 
                    && r.Split(';')[4].Contains("Universitario"))
                .OrderBy(l => l.Split(';')[1])
                .Take(100)
                .Select(r => new PartnerDto  {  Name = r.Split(';')[0], 
                                                Age = int.Parse(r.Split(';')[1]), 
                                                Team = r.Split(';')[3] 
                                              }).ToList();

            return records;

        }

        //Devuelve listado con los 5 nombres más comunes entre los hinchas de River.
        public List<string> GetTopFiveNames()
        {
            //var records = data.lineas
            //                .GroupBy(x => x.Split(';')[0])
            //                .Where(g => (g.Count() > 1))
            //                .OrderByDescending(x => x.Count())
            //                .Select(x => new { Element = x.Key, Counter = x.Count() }).ToList();
            //var records = data.lineas                       
            //                .Where( x => x.Split(';')[3].Equals("River") )
            //                .Select(x );

            var records = data.lineas
                            .GroupBy(x => x.Split(';')[0])
                            .Where(g => (g.Count() > 1 && g.All( r => r.Split(';')[2].Equals("River"))))
                            .OrderByDescending(x => x.Count())
                            .Select(x => new { Name = x.Key, Counter = x.Count() }).ToList();


            return records.Select(r => r.Name).ToList();

        }

        //Devuelve Un listado, ordenado de mayor a menor con el equipo, el promedio de edad,
        //la menor edad registrada y la mayor edad registrada.
        public List<TeamsDto> GetTeamsInfo()
        {
            

            var teamsList = data.lineas.Select(x => x.Split(';')[1]).Distinct().ToList();
            foreach(var team in teamsList)
            {
                AverageAgeOfTeam(team);
            }
            return null;
        }

        public int AverageAgeOfTeam(string team)
        {
            var team_ = team.ToLower();
            var filterListTeam = from x in data.lineas
                          where x.Split(';')[2].Equals(team_)
                          select x;


            var agesSum = from x in filterListTeam
                          group x by x.Split(';')[1] into t
                          select t.Sum(x => x[1]);

            int totalPeople= filterListTeam.Count();
            var result = Convert.ToInt32(agesSum) / totalPeople;

            return result;
        }
    }
}





