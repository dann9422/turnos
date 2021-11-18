namespace turnos.Models
{
    public class MedicoEspecialidad
    {
        public int idMedico { get; set; }
        public int idEspecialidad { get; set; }
        public Medico Medico { get; set; }
        public especialidad especialidad { get; set; }
    }
}