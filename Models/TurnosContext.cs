using Microsoft.EntityFrameworkCore;
namespace turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext>options):base(options)
        {

        }
        public DbSet<especialidad> especialidad{get ;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
modelBuilder.Entity<especialidad>(entidad =>
{

    entidad.ToTable("especialidad");
    entidad.HasKey(e => e.idEspecialidad);
    entidad.Property(e =>e.descripcion)
    .IsRequired()
    .HasMaxLength(200)
    .IsUnicode(false);
    
}
);
        }
    }
}