using Microsoft.AspNetCore.Mvc;
using turnos.Models;
using System.Linq;
namespace turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context){

                _context = context;

        }
    public IActionResult Index(){
        return View(_context.especialidad.ToList());
    }
        public IActionResult Edit(int? id){

            if(id== null){

                return NotFound();// retornamos un error 404 algo no encontrado 
            }

                var especialidad = _context.especialidad.Find(id);

                if(especialidad == null){

                    return NotFound();        // validamos el parametro pero puede que no exista en la base de datos   
                        }
            return View(especialidad);
        }
[HttpPost]
        public IActionResult Edit(int id,[Bind("idEspecialidad,descripcion")]especialidad especialidad){
            if(id != especialidad.idEspecialidad){
                    return NotFound();// validamos que los valores sean distintos, asi mostramos un error 


            }

                if(ModelState.IsValid){
                _context.Update(especialidad);// hacemos la actualizacion 
                 _context.SaveChanges();// guardamos los cambios
                return RedirectToAction(nameof(Index));// le pasamos el actions al cual debe de redirigir los datos
                }
                    return View(especialidad);

        }

        public IActionResult Delete(int? id){
if(id==null){

    return NotFound();
}
            var especialidad = _context.especialidad.FirstOrDefault(e => e.idEspecialidad==id);

            if(especialidad == null){

                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id){

                var especialidad =_context.especialidad.Find(id);
                _context.especialidad.Remove(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

    }
}