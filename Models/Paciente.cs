using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Paciente
    {
        [Key]
        
        public int idPaciente { get; set; }
        [Required (ErrorMessage ="campo obligatorio, debe de agregar un Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="campo obligatorio, debe de agregar un Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="campo obligatorio, debe de agregar un Direción")]
          [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="campo obligatorio, debe de agregar un Teléfono")]
          [Display(Name ="Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="campo obligatorio, debe de agregar un Email")]
         [EmailAddress(ErrorMessage ="No es una direción de email valida")]
        public string Email { get; set; }

        public List<Turnos> Turnos{get; set;}
        
    }
}