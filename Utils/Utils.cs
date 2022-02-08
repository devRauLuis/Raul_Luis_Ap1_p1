using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raul_Luis_Ap1_p1;
public class Utils
{
    public static void ShowErrorMessageBox(string msg, string title = "Validación")
    {
        MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Error);
    }
    public static void ShowInformationMessageBox(string msg, string title = "Éxito")
    {
        MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Information);
    }

}