using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Required (ErrorMessage ="Debe de ingresar un usuario")]
        public string Usuario { get; set; }
        [Required (ErrorMessage ="Debe de ingresar una contraseña")]
        public string Password { get; set; }
    }
}