using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LibraryModel.Model;
using System.Text.Json;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
       /* [TestMethod]
        public void TestMethod1()
        {
        }*/

        [DataTestMethod]
        [DataRow("Defeat.json")]
      //[DataRow("NotValid1.json")]
        [DataRow("NotValid2.json")]
        [DataRow("NotWin.json")]
        [DataRow("NotWin2.json")]
        [DataRow("Win.json")]
        [DataRow("Win2.json")]
        [DataRow("Win3.json")]
        public void Result_is_correct(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);

            VerificaEsito verificaEsito = JsonSerializer.Deserialize<VerificaEsito>(jsonString);

            Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();

            foreach(var chiaveValore in verificaEsito.Properties)
            {
                keyValuePairs.Add(chiaveValore.Key, chiaveValore.Value.ToString());
            }

            string risultatoAspettato = verificaEsito.Risultato_Aspettato;

            string risultatoOttenuto;
            List<List<string>> rigaVincente;
            (risultatoOttenuto, rigaVincente)= verificaEsito.CalcolaRisultato(keyValuePairs);

            Assert.AreEqual(risultatoAspettato, risultatoOttenuto);
        }
    }
}
