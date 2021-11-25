using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class especialidad
    {
        [Key]
        public int idEspecialidad { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio, debe de ingresar una Descripción")]
        [Display(Name ="Descripción",Prompt ="Ingrese una  Descripción")] 
        [StringLength(20,ErrorMessage ="El campo debe de tener como maximo 20 caracteres")]       
        public string descripcion  { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        

    }
}