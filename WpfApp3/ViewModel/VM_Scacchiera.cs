using Library.WPF;
using LibraryModel.Model;
using System.Collections.ObjectModel;

namespace WpfApp3.ViewModels
{
    public class VM_Scacchiera : WPF_Notifier
    {
        public Scacchiera model;

        public static ObservableCollection<VM_Casella> caselle_list;

        public ObservableCollection<VM_Casella> Caselle_list
        {
            get
            {
                if (caselle_list == null)
                {
                    caselle_list = new ObservableCollection<VM_Casella>();
                    foreach (Casella casella in this.model.Caselle_list)
                    {
                        caselle_list.Add(new VM_Casella(casella.Point, casella.Pedina, casella.Background));
                    }
                }
                return caselle_list;
            }
            set
            {
                caselle_list = value;
                OnPropertyChanged();
            }
        }

        public VM_Scacchiera()
        {
            this.model = new Scacchiera();
        }

    }
}
