using System;

namespace LibraryModel.Model
{
    public enum Colore
    {
        Bianco,
        Nero
    }

    public enum Altezza
    {
        Alto,
        Basso
    }

    public enum Forma
    {
        Quadrato,
        Tondo
    }

    public enum Buco
    {
        Buco,
        NoBuco
    }

    public class Pedina 
    {
        public Colore colore;
        public Forma forma;
        public Buco buco;
        public Altezza altezza;
        public Point point;

        public Buco Buco
        {
            get { return buco; }
            set { buco = value; }
        }

        public Altezza Altezza
        {
            get { return altezza; }
            set { altezza = value; }
        }


        public Colore Colore
        {
            get { return colore; }
            set { colore = value; }
        }

        public Forma Forma
        {
            get { return forma; }
            set { forma = value; }
        }

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public Pedina(Colore colore, Forma forma, Altezza altezza, Buco buco, Point point)
        {
            this.colore = colore;
            this.altezza = altezza;
            this.buco = buco;
            this.forma = forma;
            this.point = point;
        }
    }

}
