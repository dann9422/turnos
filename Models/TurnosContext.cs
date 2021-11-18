using Microsoft.EntityFrameworkCore;
using turnos.Models;
namespace turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext>options):base(options)
        {

        }
        public DbSet<especialidad> especialidad{get ;set;}
        public DbSet<Paciente> Paciente{get;set;}
        public DbSet<Prueba> Prueba {get;set;}
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad{get;set;}


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

modelBuilder.Entity<Paciente>(entidad =>{

entidad.ToTable("Paciente");
entidad.HasKey(p => p.idPaciente);

entidad.Property(p=>p.Nombre)
.IsRequired()
.HasMaxLength(50)
.IsUnicode(false);

entidad.Property(p=>p.Apellido)
.IsRequired()
.HasMaxLength(50)
.IsUnicode(false);

entidad.Property(p=>p.Direccion)
.IsRequired()
.HasMaxLength(250)
.IsUnicode(false);


entidad.Property(p=>p.Telefono)
.IsRequired()
.HasMaxLength(20)
.IsUnicode(false);

entidad.Property(p=>p.Email)
.IsRequired()
.HasMaxLength(100)
.IsUnicode(false);
});

modelBuilder.Entity<Medico>(entidad =>{

entidad.ToTable("Medico");
entidad.HasKey(m=>m.IdMedico);
entidad.Property(m => m.Nombre)
.IsRequired()
.HasMaxLength(50)
.IsUnicode(false);

entidad.Property(m => m.Apellido)
.IsRequired()
.HasMaxLength(50)
.IsUnicode(false);


entidad.Property(m => m.Telefono)
.IsRequired()
.HasMaxLength(20)
.IsUnicode(false);


entidad.Property(m => m.Email)
.IsRequired()
.HasMaxLength(50)
.IsUnicode(false);



entidad.Property(m => m.HorarioAtencionDesde)
.IsRequired()
.IsUnicode(false);

entidad.Property(m => m.HorarioAtencionHasta)
.IsRequired()
.IsUnicode(false);

}); 

modelBuilder.Entity<MedicoEspecialidad>().HasKey(x=> new{x.idMedico,x.idEspecialidad});
modelBuilder.Entity<MedicoEspecialidad>().HasOne(x=>x.Medico)
.WithMany(p=>p.MedicoEspecialidad)
.HasForeignKey(p=>p.idMedico);


modelBuilder.Entity<MedicoEspecialidad>().HasOne(x=>x.especialidad)
.WithMany(p=>p.MedicoEspecialidad)
.HasForeignKey(p=>p.idEspecialidad);

        }


    }
}