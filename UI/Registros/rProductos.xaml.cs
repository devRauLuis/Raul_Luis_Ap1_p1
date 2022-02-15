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
using Raul_Luis_Ap1_p1;
using Raul_Luis_Ap1_p1.Entidades;
using Raul_Luis_Ap1_p1.BLL;

namespace Raul_Luis_Ap1_p1.UI.Registros;

public partial class rProductos : Window
{

    Producto productoActual = new Producto();

    public rProductos()
    {
        InitializeComponent();
        Cargar();
    }

    private void Cargar()
    {
        this.DataContext = null;
        this.DataContext = productoActual;
    }

    private void Limpiar()
    {
        productoActual = new Producto();
        Cargar();
    }

    private bool Validar()
    {
        if (string.IsNullOrWhiteSpace(productoActual.Descripcion))
        {
            DescripcionTB.Focus();
            Utils.ShowErrorMessageBox("¡Debe indicar una descripción válida!");
            return false;
        }
        else if (productoActual.Existencia <= 0)
        {
            ExistenciaTB.Focus();
            Utils.ShowErrorMessageBox("¡Debe indicar una existencia válida!");
            return false;
        }
        else if (productoActual.Costo <= 0)
        {
            CostoTB.Focus();
            Utils.ShowErrorMessageBox("¡Debe indicar un costo válida!");
            return false;
        }
        return true;
    }

    private void BuscarButton_Click(object sender, RoutedEventArgs e)
    {
        var encontrado = ProductosBLL.Buscar(productoActual.ProductoId);
        if (encontrado is not null)
        {
            productoActual = encontrado;
            Cargar();
        }
        else
        {
            Limpiar();
            Utils.ShowErrorMessageBox("¡No es encontró el producto!", "Falló");
        }
    }

    private void NuevoButton_Click(object sender, RoutedEventArgs e)
    {
        Limpiar();
    }

    private void GuardarButton_Click(object sender, RoutedEventArgs e)
    {
        if (!Validar()) return;
        var editando = ProductosBLL.GetList(p => true).Any(p => p.ProductoId == productoActual.ProductoId);
        var existeDescripcion = ProductosBLL.GetList(p => true).Any(p => p.Descripcion == productoActual.Descripcion);

        if (existeDescripcion is true && editando is not true)
        {
            Utils.ShowErrorMessageBox("¡Ya existe un producto con esa descripción!");
            return;
        }
        if (ProductosBLL.Guardar(productoActual))
        {
            Utils.ShowInformationMessageBox("¡Producto guardado con éxito!");
            Limpiar();
        }
        else Utils.ShowErrorMessageBox("¡No se pudo guardar el producto!");

    }

    private void EliminarButton_Click(object sender, RoutedEventArgs e)
    {
        if (ProductosBLL.Eliminar(productoActual.ProductoId))
        {
            Limpiar();
            Utils.ShowInformationMessageBox("¡Fue eliminado con éxito!");
        }
        else Utils.ShowErrorMessageBox("¡No se pudo eliminar el producto!");
    }

    private void OnProductoIdTBChanged(object sender, EventArgs e)
    {
        BuscarBtn.IsEnabled = int.TryParse(ProductoId.Text, out _);
    }
    private void OnExistenciaTBChanged(object sender, EventArgs e)
    {
        CalcularValorInventario();
    }

    private void OnCostoTBChanged(object sender, EventArgs e)
    {
        CalcularValorInventario();
    }

    private void CalcularValorInventario()
    {
        int existencia = int.TryParse(ExistenciaTB.Text, out existencia) ? existencia : 0;
        float costo = float.TryParse(CostoTB.Text, out costo) ? costo : 0;
        var valorInventario = (float)existencia * costo;
        productoActual.ValorInventario = valorInventario;
        ValorInventarioTB.Text = $"{valorInventario:N2}";
    }

}