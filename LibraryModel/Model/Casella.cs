using System.Windows.Media;

namespace LibraryModel.Model
{

    public class Casella 
    {
        public Point point;
        public Pedina pedina;
        public Brush background;


        public Pedina Pedina
        {
            get { return pedina; }
            set { pedina = value; }
        }

        public Brush Background
        {
            get { return background; }
            set { background = value; }
        }

        public Point Point
        {
            get { return point; }
            set
            {
                point = value;
            }
        }

        public Casella(Point point, Pedina pedina, Brush background)
        {
            this.point = point;
            this.pedina = pedina; 
            this.background = background;
        }
    }
}
