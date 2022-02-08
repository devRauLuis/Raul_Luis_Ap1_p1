using System;
using System.Windows;
using System.Collections.Generic;

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

            ProductosDG.ItemsSource = null;
            ProductosDG.ItemsSource = lista;
        }
    }

}