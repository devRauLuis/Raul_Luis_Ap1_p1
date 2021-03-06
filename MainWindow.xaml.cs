using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raul_Luis_Ap1_p1.UI.Registros;
using Raul_Luis_Ap1_p1.UI.Consultas;



namespace Raul_Luis_Ap1_p1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onRegistroProductosMenuItemClick(object sender, RoutedEventArgs e)
        {
            var rProductosView = new rProductos();
            rProductosView.Show();
        }

        private void onConsultaProductosMenuItemClick(object sender, RoutedEventArgs e)
        {
            var cProductosView = new cProductos();
            cProductosView.Show();
        }
    }
}
