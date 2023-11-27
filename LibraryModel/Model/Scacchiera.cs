using System.Collections.ObjectModel;
using System.Windows.Media;

namespace LibraryModel.Model
{
    public class Scacchiera 
    {
        public ObservableCollection<Casella> Caselle_list { get; set; }

        public Scacchiera()
        {

            MakeScacchiera();

        }

        private void MakeScacchiera()
        {
            Caselle_list = new ObservableCollection<Casella>();
            Point point;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    point = new Point(x, y);
                    Caselle_list.Add(new Casella(point, null, Brushes.Transparent)); 
                }
            }
        }

    }
}
