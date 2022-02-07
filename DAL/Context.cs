using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raul_Luis_Ap1_p1.Entidades;
namespace Raul_Luis_Ap1_p1.DAL;
public class Context : DbContext
{

    public DbSet<Producto> Productos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DATA/Productos.db");
    }
}
