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

        public int CountRecords()
        {
            return data.lineas.Count();
        }

        //Promedio edad socios registrados
        public int GetAgeAverage()
        {
            int agesSum = (from x in data.lineas
                           select ConvertToInt(data.lineas[0].Split(';')[1])).Sum();
                        

            int total = CountRecords();
            var result = agesSum/ total;

            return result;
        }

        //Listado con las 100 primeras personas casadas, con estudios Universitarios, ordenadas de menor a mayor según su edad.
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

        //Listado con los 5 nombres más comunes entre los hinchas de River.
        public List<string> GetTopFiveNames()
        {

            var records= (
                            data.lineas
                            .Where(r => r.Split(';')[2].Equals("River"))
                            .Select(x => x)
                            )
                            .GroupBy(x => x.Split(';')[0])
                            .Where(g => g.Count() > 1)
                            .OrderByDescending(x => x.Count()).Take(5)
                            .Select(x => new { Name = x.Key, Counter = x.Count() }).ToList();


            return records.Select(r => r.Name).ToList();

        }

        //Devuelve Un listado, ordenado de mayor a menor con el equipo, el promedio de edad,
        //la menor edad registrada y la mayor edad registrada.
        public List<TeamsDto> GetTeamsInfo()
        {
            List<TeamsDto> listTeams = new List<TeamsDto>();

            var teamsNamesList = data.lineas.Select(x => x.Split(';')[2]).Distinct().ToList();
            foreach(var teamNames in teamsNamesList)
            {

                TeamsDto team = new TeamsDto();
                team.Team = teamNames;
                team.AgeAverage= AverageAgeOfTeam(teamNames);
                team.AgeMax = GetMaxAgeTeam(teamNames);
                team.AgeMin = GetMinAgeTeam(teamNames);

                listTeams.Add(team);
            }

            return listTeams;
        }


        //
        protected int AverageAgeOfTeam(string team)
        {

            var filterListTeam = from x in data.lineas
                          where x.Split(';')[2].Equals(team)
                          select ConvertToInt(x.Split(';')[1]);
            
            int totalPeople= filterListTeam.Count();

            var result = filterListTeam.Sum() / totalPeople;

            return result;
        }

        protected int ConvertToInt( string data)
        {
            try
            {
               return Int32.Parse(data);
            }
            catch (FormatException e)
            {
               throw e;
            }

        }

        protected int GetMaxAgeTeam(string team)
        {
            var result = (
                            data.lineas
                            .Where(r => r.Split(';')[2].Equals(team))
                            .Select(x => ConvertToInt(x.Split(';')[1]))
                            );



            return result.Max();
        }

        protected int GetMinAgeTeam(string team)
        {
            var result = (
                            data.lineas
                            .Where(r => r.Split(';')[2].Equals(team))
                            .Select(x => ConvertToInt(x.Split(';')[1]))
                            );



            return result.Min();
        }
    }
}





