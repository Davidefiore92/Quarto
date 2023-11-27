using Library.WPF;
using LibraryModel.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using WpfApp3.Library;
using System.Windows;
using System.Windows.Media;

namespace WpfApp3.ViewModels
{
    public class VM_Casella : WPF_Notifier
    {
        public Casella model;
        public bool youWin;
        LibraryModel.Model.Point punto;

        public ICommand MoveToCasella { get; set; }

        public VM_Casella(LibraryModel.Model.Point point, Pedina pedina, Brush background)
        {
            this.model = new Casella(point, pedina, background);
            MoveToCasella = new RelayCommand<object>(OnCasellaCliccata, CanMoveToCasella);
        }

        public Pedina Pedina
        {
            get { return model.Pedina; }
            set
            {
                model.Pedina = value;
                OnPropertyChanged();
            }
        }

        public Brush Background
        {
            get { return model.Background; }
            set
            {
                model.Background = value;
                OnPropertyChanged();
            }
        }

        public LibraryModel.Model.Point Point
        {
            get { return model.Point; }
            set
            {
                model.Point = value;
                OnPropertyChanged();
            }
        }
        public bool CanMoveToCasella
        {
            get
            {
                UpdateCanMoveToCasella();
                return canMoveToCasella;
            }
            set
            {
                if (canMoveToCasella != value)
                {
                    canMoveToCasella = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnCasellaCliccata(object obj)
        {
            Pedina pedina = VM_Pedina.pedinaSelected;
            
            if(CanMoveToCasella && pedina!=null && Pedina==null)
            {
                punto = new LibraryModel.Model.Point(Point.PosX, Point.PosY);

                VM_Casella vM_Casella = new VM_Casella(punto, pedina, Brushes.Transparent);

                ShiftPedina(VM_Scacchiera.caselle_list, vM_Casella);
            }

        }

        public void ShiftPedina(ObservableCollection<VM_Casella> list, VM_Casella newCasella)
        {
            int index = -1;
            for(int i = 0; i<list.Count; i++)
                if (list[i].Point.Equals(newCasella.Point))
                    index = i;

            VM_Scacchiera.caselle_list.Remove(this);
            VM_Pedine.pedine_list.Remove(VM_Pedina.pedinaDaRimuovere);
            
            Pedina = null;
            canMoveToCasella = false;

            list.Insert(index, newCasella);

            ScriviNelFile(VM_Pedina.pedinaSelected);

            VM_Pedina.pedinaSelected = null;

            VerificaEsito verificaEsito = new VerificaEsito();

            string result;
            List<List<string>> righeVincenti;

            (result, righeVincenti) = verificaEsito.CalcolaRisultato(OttieniDictionary());

            if (righeVincenti != null)
                ColoraRigaVincente(righeVincenti);

            VittoriaSconfitta(result);
            

        }


        protected void ScriviNelFile(Pedina pedina)
        {
            string infoPedina = $"\"{punto.PosX},{punto.PosY}\": \"{pedina.Colore}, {pedina.Forma}, {pedina.Altezza}, {pedina.Buco}\"";
            string filePath = "game.json";
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(infoPedina);
            }
        }

        private Dictionary<string, string> OttieniDictionary()
        {
            string filePath = "game.json";

            var keyValuePairs = new Dictionary<string, string>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    string[] keyValue = line.Split(':');
                    string key = keyValue[0].Replace("\"","");
                    string value = keyValue[1].Replace("\"", "");
                    keyValuePairs.Add(key, value);
                }
            }
            return keyValuePairs;
        }

        private void VittoriaSconfitta(string result)
        {
            VittoriaVsSconfitta vittoriaVsSconfitta = new VittoriaVsSconfitta();
            Esito esito = vittoriaVsSconfitta.EsitoPartita(result);
            if (esito.Equals(Esito.Win))
            {
                Mk_MessageBox.Show("Vittoria!", Brushes.Green);
                Application.Current.Shutdown();

            }
            else if (esito.Equals(Esito.Defeat))
            {
                Mk_MessageBox.Show("Sconfitta!", Brushes.Red);
                Application.Current.Shutdown();
            }
        }

        public void ColoraRigaVincente(List<List<string>> righeVincenti)
        {
            foreach (List<string> lista in righeVincenti)
            {
                foreach (string stringa in lista)
                {
                    string[] values = stringa.Split(',');
                    LibraryModel.Model.Point point = new LibraryModel.Model.Point(int.Parse(values[0]), int.Parse(values[1]));
                    foreach (VM_Casella casella in VM_Scacchiera.caselle_list)
                    {
                        if (casella.Point.Equals(point))
                            casella.Background = Brushes.Green;
                    }
                }
            }
        }

        public void UpdateCanMoveToCasella()
        {
            
        }

        public bool canMoveToCasella = true;
    }

}
