using System.Collections.ObjectModel;
using Library.WPF;
using LibraryModel.Model;

namespace WpfApp3.ViewModels
{
    public class VM_Pedine : WPF_Notifier
    {
        public Pedine model;

        public static ObservableCollection<VM_Pedina> pedine_list;

        public ObservableCollection<VM_Pedina> Pedine_list
        {
            get
            {
                if (pedine_list == null)
                {
                    pedine_list = new ObservableCollection<VM_Pedina>();
                    foreach (Pedina pedina in this.model.Pedine_list)
                    {
                        pedine_list.Add(new VM_Pedina(pedina.Colore, pedina.Forma, pedina.Altezza, pedina.Buco, pedina.Point));
                    }
                }
                return pedine_list;
            }
            set
            {
                pedine_list = value;
                OnPropertyChanged();
            }
        }

        public VM_Pedine()
        {
            this.model = new Pedine();
        }
    }
}
