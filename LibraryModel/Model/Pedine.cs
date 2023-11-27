using System.Collections.Generic;
using System.Windows.Media;

namespace LibraryModel.Model
{
    public class Pedine
    {
        public List<Pedina> Pedine_list { get { return pedine_list; } set { pedine_list = value; } }
        private List<Pedina> pedine_list = new List<Pedina>();

        public Pedine()
        {
            Pedine_list = new List<Pedina>() { };

            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Tondo, Altezza.Alto, Buco.Buco, new Point(0,0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Tondo, Altezza.Alto, Buco.Buco, new Point(0, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Tondo, Altezza.Alto, Buco.NoBuco, new Point(1, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Tondo, Altezza.Alto, Buco.NoBuco, new Point(1, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Tondo, Altezza.Basso, Buco.Buco, new Point(2, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Tondo, Altezza.Basso, Buco.Buco, new Point(2, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Tondo, Altezza.Basso, Buco.NoBuco, new Point(3, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Tondo, Altezza.Basso, Buco.NoBuco, new Point(3, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Quadrato, Altezza.Alto, Buco.Buco, new Point(4, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Quadrato, Altezza.Alto, Buco.Buco, new Point(4, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Quadrato, Altezza.Alto, Buco.NoBuco, new Point(5, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Quadrato, Altezza.Alto, Buco.NoBuco, new Point(5, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Quadrato, Altezza.Basso, Buco.Buco, new Point(6, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Quadrato, Altezza.Basso, Buco.Buco, new Point(6, 1)));
            Pedine_list.Add(new Pedina(Colore.Bianco, Forma.Quadrato, Altezza.Basso, Buco.NoBuco, new Point(7, 0)));
            Pedine_list.Add(new Pedina(Colore.Nero, Forma.Quadrato, Altezza.Basso, Buco.NoBuco, new Point(7, 1)));

        }

    }
}