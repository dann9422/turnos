using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Medico
    {
        [Key]
        
        public int IdMedico { get; set; }
       
        [Required (ErrorMessage ="campo obligatorio, debe de agregar un Nombre")]
        public string Nombre { get; set; }
        [Required (ErrorMessage ="campo obligatorio, debe de agregar un Apellido ")]
        public string  Apellido{ get; set; }
        [Required (ErrorMessage ="campo obligatorio, debe de agregar un Teléfono")]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }

         [Required (ErrorMessage ="campo obligatorio, debe de agregar un Email") ]
         [EmailAddress(ErrorMessage ="No es una direción de email valida")]
        public string Email { get; set; }
        [Display(Name ="Horario desde")] 
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString ="{0:hh:mm tt}",ApplyFormatInEditMode =true)]
              public DateTime HorarioAtencionDesde { get; set; }
              [Display(Name ="Horario hasta")]
              [DataType(DataType.Time)]
              [DisplayFormat(DataFormatString ="{0:hh:mm tt}",ApplyFormatInEditMode =true)]
         public DateTime HorarioAtencionHasta { get; set; }
         public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
         public List<Turnos> Turnos{get; set;}


    }
}