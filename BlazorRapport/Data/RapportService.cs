using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRapport.Data
{
    public class RapportService
    {
        public static readonly string[] Vakken = new[]
        {
            "Nederlands","Frans","Engels","Geschiedenis","Aardrijkskunde","Wiskunde","Informatica"
        };
        public Task<Rapport[][]> GetRapportAsync(string naamStudent)
        {
            var rnd = new Random();
            int aantalRapporten = 10;
            int maxSpreiding = 4;
            List<Rapport[]> rapporten = new();
            foreach (var item in Vakken)
            {
                List<Rapport> rapportenPerVak = new();
                int vorigeScore = 0;
                for (int i = 0; i < aantalRapporten; i++)
                {
                    Rapport rapport = new();
                    rapport.Student = naamStudent;
                    rapport.Vak = item;
                    rapport.Score = rnd.Next(0, 11);
                    if (i == 0)
                    {
                        vorigeScore = rapport.Score;
                    }
                    else
                    {
                        while((rapport.Score > (vorigeScore + maxSpreiding)) || (rapport.Score < (vorigeScore - maxSpreiding)))
                        {
                            rapport.Score = rnd.Next(0, 11);
                        }
                        vorigeScore = rapport.Score;
                    }
                    rapportenPerVak.Add(rapport);
                }
                rapporten.Add(rapportenPerVak.ToArray());
            }
            return Task.FromResult(rapporten.ToArray());
        }
    }
}
