using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;

namespace LibraryModel.Model
{
    public class VerificaEsito
    {
        readonly List<string[]> righeVincenti = new List<string[]>
        {
            new string[] { "0,0", "0,1", "0,2", "0,3" },
            new string[] { "1,0", "1,1", "1,2", "1,3" },
            new string[] { "2,0", "2,1", "2,2", "2,3" },
            new string[] { "3,0", "3,1", "3,2", "3,3" },
            new string[] { "0,0", "1,0", "2,0", "3,0" },
            new string[] { "0,1", "1,1", "2,1", "3,1" },
            new string[] { "0,2", "1,2", "2,2", "3,2" },
            new string[] { "0,3", "1,3", "2,3", "3,3" },
            new string[] { "0,0", "1,1", "2,2", "3,3" },
            new string[] { "3,0", "2,1", "1,2", "0,3" }
        };

        [JsonExtensionData]
        public Dictionary<string, object> Properties { get; set; }

        public string Risultato_Aspettato { get; set; } 

        public (string,List<List<string>>) CalcolaRisultato(Dictionary<string,string> keyValuePairs)
        {
            int count = 0;

            if (keyValuePairs.Values.GroupBy(v => v).Any(g => g.Count() > 1))
                return ("Not Valid",null);
            else if (keyValuePairs.Count < 4)
                return ("Not Win",null);
            else
            {
                List<List<string>> righeDiRitorno = new List<List<string>>();
                foreach (string[] rigaDaControllare in righeVincenti)
                {
                    foreach (string key in keyValuePairs.Keys)
                    {
                        if (rigaDaControllare.Contains(key))
                            count++;
                        if (count == 4)
                        {
                            string riga = $"{rigaDaControllare[0]}& {rigaDaControllare[1]}& {rigaDaControllare[2]}& {rigaDaControllare[3]} ";
                            bool controlloVittoria;
                            List<string> rigaDiRitorno;
                            (controlloVittoria, rigaDiRitorno) = ControlloVittoria(riga, keyValuePairs);
                            if (controlloVittoria)
                                righeDiRitorno.Add(rigaDiRitorno);
                        }
                    }
                    count = 0;
                }
                if (righeDiRitorno.Count>=1)
                    return("Win", righeDiRitorno);
            }
            if (keyValuePairs.Count == 16)
                return ("Defeat", null);

            return ("Not Win", null);
        }

        private (bool,List<string>) ControlloVittoria(string rigaDaControllare, Dictionary<string, string> keyValuePairs)
        {
            List<string> chiaviDaConfrontare = rigaDaControllare.Replace(" ","").Split('&').ToList();

            List<string> pedine = keyValuePairs
                .Where(key => chiaviDaConfrontare.Contains(key.Key))
                .Select(key => key.Value)
                .ToList();

            string[] colore = new string[4];
            string[] forma = new string[4];
            string[] altezza = new string[4];
            string[] buco = new string[4];
            int i = 0;

            foreach(string pedina in pedine)
            {
                string[] valori = pedina.Split(',');
                colore[i] = valori[0];
                forma[i] = valori[1];
                altezza[i] = valori[2];
                buco[i++] = valori[3];
            }

            bool coloriUguali = colore.All(x => x == colore[0]);
            bool formeUguali = forma.All(x => x == forma[0]);
            bool altezzeUguali = altezza.All(x => x == altezza[0]);
            bool buchiUguali = buco.All(x => x == buco[0]);

            if (coloriUguali || formeUguali || altezzeUguali || buchiUguali)
                return (true,chiaviDaConfrontare);

            return (false, chiaviDaConfrontare);
        }
    }
}
