using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Prueba
    {
        [Key]
        public int iDprueba { get; set; }
        public string Categoria { get; set; }
    }
}