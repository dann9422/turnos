using Microsoft.EntityFrameworkCore;
namespace turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext>options):base(options)
        {

        }
        public DbSet<especialidad> especialidad{get ;set;}
    }
}