using Microsoft.AspNetCore.Mvc;
using turnos.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context){

                _context = context;

        }
    public async Task<IActionResult> Index(){
        return  View(await _context.especialidad.ToListAsync());
    }
        public async Task<IActionResult> Edit(int? id){

            if(id== null){

                return NotFound();// retornamos un error 404 algo no encontrado 
            }

                var especialidad =await _context.especialidad.FindAsync(id);

                if(especialidad == null){

                    return NotFound();        // validamos el parametro pero puede que no exista en la base de datos   
                        }
            return View(especialidad);
        }
[HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("idEspecialidad,descripcion")]especialidad especialidad){
            if(id != especialidad.idEspecialidad){
                    return NotFound();// validamos que los valores sean distintos, asi mostramos un error 


            }

                if(ModelState.IsValid){
                _context.Update(especialidad);// hacemos la actualizacion 
                 await _context.SaveChangesAsync();// guardamos los cambios
                return RedirectToAction(nameof(Index));// le pasamos el actions al cual debe de redirigir los datos
                }
                    return View(especialidad);

        }

        public async Task<IActionResult> Delete(int? id){
if(id==null){

    return NotFound();
}
            var especialidad = await _context.especialidad.FirstOrDefaultAsync(e => e.idEspecialidad==id);

            if(especialidad == null){

                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id){

                var especialidad = await _context.especialidad.FindAsync(id);
                _context.especialidad.Remove(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(){

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create([Bind("idEspecialidad","descripcion")]especialidad especialidad){

if(ModelState.IsValid){
_context.Add(especialidad);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));

}

return View();
        }
            


    }
}