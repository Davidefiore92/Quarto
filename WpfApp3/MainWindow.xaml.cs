using System.IO;
using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if(File.Exists("game.json"))
                File.WriteAllText("game.json", "");
        }        

    }
}
