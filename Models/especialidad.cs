using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class especialidad
    {
        [Key]
        public int idEspecialidad { get; set; }

        public string descripcion  { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        

    }
}