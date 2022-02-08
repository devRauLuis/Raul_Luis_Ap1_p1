using System;
using System.Windows;
using System.Collections.Generic;
// using System.Windows.Controls;
// using System.Windows.Data;
// using System.Windows.Documents;
// using System.Windows.Input;
// using System.Windows.Media;
// using System.Windows.Media.Imaging;
// using System.Windows.Navigation;
// using System.Windows.Shapes;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

using Raul_Luis_Ap1_p1;
using Raul_Luis_Ap1_p1.Entidades;
using Raul_Luis_Ap1_p1.BLL;
namespace Raul_Luis_Ap1_p1.UI.Consultas;

public partial class cProductos : Window
{
    public cProductos()
    {
        InitializeComponent();
    }

    private void BuscarButton_Click(object sender, RoutedEventArgs e)
    {
        var lista = new List<Producto>();
        if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
        {
            lista = ProductosBLL.GetList(p => true);
        }
        else
        {
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0:
                    int id = int.TryParse(CriterioTextBox.Text, out id) ? id : 0;
                    if (id <= 0)
                    {
                        Utils.ShowErrorMessageBox("ID no valido");
                        break;
                    }
                    lista = ProductosBLL.GetList(p => p.ProductoId == id);
                    break;
                case 1:
                    lista = ProductosBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                    break;
            }
        }
    }

}