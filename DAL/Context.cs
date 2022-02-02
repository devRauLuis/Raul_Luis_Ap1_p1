using Microsoft.EntityFrameworkCore;

namespace Raul_Luis_Ap1_p1.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\Data.db");
        }
    }
}