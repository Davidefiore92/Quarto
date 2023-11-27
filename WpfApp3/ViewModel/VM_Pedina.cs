using Library.WPF;
using LibraryModel.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Controls;

namespace WpfApp3.ViewModels
{
    public class VM_Pedina : WPF_Notifier
    {
        public Pedina model;
        public ICommand SelectedPedina { get; set; }

        public static Pedina pedinaSelected;
        public static VM_Pedina pedinaDaRimuovere;

        public VM_Pedina(Colore colore, Forma forma, Altezza altezza, Buco buco, Point point)
        {
            this.model = new Pedina(colore, forma, altezza, buco, point);
            SelectedPedina = new RelayCommand<object>(Selected, CanMovePedina);
        }

        public Point Point
        {
            get { return model.Point; }
            set
            {
                model.Point = value;
                OnPropertyChanged();
            }
        }

        public Colore Colore
        {
            get { return model.Colore; }
            set
            {
                model.Colore = value;
                OnPropertyChanged();
            }
        }

        public Forma Forma
        {
            get { return model.Forma; }
            set
            {
                model.Forma = value;
                OnPropertyChanged();
            }
        }

        public Altezza Altezza
        {
            get { return model.Altezza; }
            set
            {
                model.Altezza = value;
                OnPropertyChanged();
            }
        }

        public Buco Buco
        {
            get { return model.Buco; }
            set
            {
                model.Buco = value;
                OnPropertyChanged();
            }
        }

        public bool CanMovePedina
        {
            get
            {
                UpdateCanMovePedina();
                return canMovePedina;
            }
            set
            {
                if (canMovePedina != value)
                {
                    canMovePedina = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Selected(object obj)
        {
            pedinaSelected = model;
            pedinaDaRimuovere = this;
        }


        public void UpdateCanMovePedina()
        {
            if (isSelectedPedina)
                CanMovePedina = true;
            else 
                CanMovePedina = false;
        }

        public bool canMovePedina;
        public bool isSelectedPedina;
    }
}
