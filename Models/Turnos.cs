using System;
using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Turnos
    {
        [Key]
        public int Idturno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        [Display(Name ="Fecha hora ini.")]
        public DateTime FechaHoraInicio { get; set; }
        [Display(Name ="Fecha hora Fin.")]
        public DateTime FechaHoraFin { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }

    }
}