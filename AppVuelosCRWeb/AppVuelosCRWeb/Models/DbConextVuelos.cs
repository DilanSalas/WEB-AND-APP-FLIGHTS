using Microsoft.EntityFrameworkCore;

namespace AppVuelosCRWeb.Models
{
    public class DbConextVuelos : DbContext
    {
        public DbConextVuelos(DbContextOptions<DbConextVuelos> options) : base(options)
        {
            
        }

        public DbSet<Tiquete> Tiquete { get; set; }

    }
}
