using System.Windows;

namespace WpfApp3.View
{
    /// <summary>
    /// Logica di interazione per MessageboxNew.xaml
    /// </summary>
    public partial class MessageboxNew : Window
    {
        public MessageboxNew()
        {
            InitializeComponent();

            //second time show error solved
            if (Application.Current == null) new Application();
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { DragMove(); };
        }

        /*public static implicit operator MessageboxNew(MessageboxNew v)
        {
            throw new NotImplementedException();
        }*/
    }
}