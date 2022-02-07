using System.ComponentModel.DataAnnotations;

namespace Raul_Luis_Ap1_p1.Entidades;
public class Producto
{
    [Key]
    public int ProductoId { get; set; }

    [Required]
    public string? Descripcion { get; set; }

    [Required]
    public int Existencia { get; set; }

    [Required]
    public float Costo { get; set; }

    [Required]
    public float ValorInventario { get; set; }

}