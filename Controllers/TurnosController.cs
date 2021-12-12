using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using turnos.Models;

namespace turnos.Controllers
{
    public class TurnosController : Controller
    {
        private readonly TurnosContext _context;
        private IConfiguration _configuration;


        public TurnosController(TurnosContext context, IConfiguration configuration){

            _context = context;
            _configuration = configuration;
        }

    //     public IActionResult Index(){
    //      // ViewData["IdMedico"]= new SelectList( from Medico in _context.Medico.ToList()select new {IdMedico = Medico.IdMedico,NombreCompleto = Medico.Nombre + "" +Medico.Apellido}, "IdMedico","NombreCompleto");// devuelve todas las propiedades del modelo medico 
    //       //ViewData["IdPaciente"]= new SelectList( from Paciente in _context.Paciente.ToList()select new {IdPaciente = Paciente.idPaciente,NombreCompleto = Paciente.Nombre + "" +Paciente.Apellido}, "IdPacinte","NombreCompleto");// devuelve todas las propiedades del modelo paciente donde selecciona el nombre y apelluido del objeto lista  
    //    ViewBag["IdMedico"]= new SelectList((from Medico in _context.Medico.ToList() select new {IdMedico = Medico.IdMedico, NombreCompleto = Medico.Nombre + "" + Medico.Apellido}),"IdMedico","NombreCompleto");
    //    ViewBag["IdPaciente"]= new SelectList((from Paciente in _context.Paciente.ToList() select new {IdPaciente = Paciente.idPaciente, NombreCompleto = Paciente.Nombre + "" + Paciente.Apellido}),"IdPaciente","NombreCompleto");

    //         return View();

    //     }
     public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in _context.Medico.ToList() select new { IdMedico = medico.IdMedico, NombreCompleto = medico.Nombre + " " + medico.Apellido}),"IdMedico","NombreCompleto");
            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.ToList() select new { IdPaciente = paciente.idPaciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido}),"IdPaciente","NombreCompleto");
            return View();
        }
        public JsonResult ObtenerTurnos(int idMedico){

            List<Turnos> turnos = new List<Turnos>();// recibe un parametro y devuelve un json
            turnos =_context.Turnos.Where(t => t.IdMedico == idMedico).ToList();
            return Json(turnos);// convierte una coleccion con formato json 
        }
        [HttpPost]
        public JsonResult GuardarTurno(Turnos turno){

var Ok = false;
try
{
     _context.Turnos.Add(turno);
     _context.SaveChanges();
     Ok = true;
}
catch (Exception e)
{
    
    Console.WriteLine("{0} Excepcion encontrada",e);// tenemos una respuesta si ocurre un error en el try//
}
var JsonResult= new {Ok = Ok};// asignamos al objeto jsonresult un contenido json y le colocamos el resultado del objeto ok
        return Json(JsonResult);
        }

[HttpPost]
public JsonResult EliminarTurno(int idTurno){

    var ok = false;
    try
    {
         var TurnoEliminar =_context.Turnos.Where(t => t.Idturno == idTurno).FirstOrDefault();
    if(TurnoEliminar !=null){

        _context.Turnos.Remove(TurnoEliminar);
        _context.SaveChanges();
        ok = true;
    }
    }
    catch (Exception e)
    {
        Console.WriteLine("{0} Excepcion encontrada",e);
        
    }
var JsonResult = new {ok=ok};
return Json(JsonResult);


}

    }
}