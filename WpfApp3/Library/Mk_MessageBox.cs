using System.Windows.Media;
using WpfApp3.View;

public class Mk_MessageBox
{
    public static bool? Show(string title, object colore)
    {
        MessageboxNew msg = new MessageboxNew
        {
            TitleBar = { Text = title, Background = (Brush)colore }
            //Textbar = { Text = text }
        };
        //msg.noBtn.Focus();
        return msg.ShowDialog();
    }
}