using Library.WPF;

namespace WpfApp3.Library
{
    public enum Esito 
    {
        Win,
        NotWin,
        Defeat
    }

    public class VittoriaVsSconfitta : WPF_Notifier
    {
        public Esito esito=Esito.NotWin;
        public Esito Esito
        {
            get
            {
                return esito;
            }
            set 
            { 
                esito = value;
                OnPropertyChanged();
            }
        }
        public Esito EsitoPartita(string result)
        {
            switch (result)
            {
                case "Win":
                    {
                        esito = Esito.Win;
                        OnPropertyChanged();
                        break;
                    }
                case "Defeat":
                    {
                        esito = Esito.Defeat;
                        OnPropertyChanged();
                        break;
                    }
                default:
                    {
                        esito = Esito.NotWin;
                        break;
                    }
            }
            return esito;
        }
    }
}
