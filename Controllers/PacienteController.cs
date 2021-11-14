using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using turnos.Models;

namespace turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext context){

            _context = context;
        }
        public async Task<IActionResult> Index(){
          return View(await _context.Paciente.ToListAsync());

        }

public async Task<IActionResult> Details(int ? id){

if(id==null){
    return NotFound();
}
var paciente = await _context.Paciente.FirstOrDefaultAsync(p =>p.idPaciente ==id);
if(paciente==null){

    return NotFound();
}
return View(paciente);

}

// se crea el metodo para las vistas de creacion sdonde las cosas que se van a ver 
////////////////////////////////////metodo crear//////////////////////////////////////////////////////
public IActionResult Create(){

    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
// se crean los metodos donde tenemos que  enviar los datos, capturamos los datos del modelo 
public async Task<IActionResult>Create([Bind("idPaciente","Nombre","Apellido","Direccion","Telefono","Email")]Paciente paciente){

    if(ModelState.IsValid){
_context.Add(paciente);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));


    }
    return View(paciente);
}
////////////////////////////////// fin metodo/////////////////////////////////////////////
/////////////////////////////////////Metodo editar////////////////////////////////////////////////
public async Task<IActionResult> Edit(int ? id){
// validamos que los datos esten 
if(id== null){

    return NotFound();// si los datos nos e encuentran retornamos un no found
}
var paciente =await _context.Paciente.FindAsync(id);// realizamos una busqueda por linq con el context 
if(paciente == null){
    return NotFound();
}
return View(paciente);
} 

[HttpPost]
[ValidateAntiForgeryToken]

public async Task<IActionResult> Edit(int id,[Bind("idPaciente","Nombre","Apellido","Direccion","Telefono","Email")]Paciente paciente){
if(id !=paciente.idPaciente){
return NotFound();

}

if(ModelState.IsValid){

    _context.Update(paciente);
    await _context.SaveChangesAsync();
 return RedirectToAction(nameof(Index));
}
return View(paciente);
}
//////////////////////////////////////Fin metodo/////////////////////////////////////////////////
///////////////////////////////Metodo Eliminar ////////////////////////////////////////////////////
public async Task<IActionResult> Delete(int ? id){

        if(id==null){

            return NotFound();
        }
        var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.idPaciente ==id);
        if(paciente ==null){
            return NotFound();

        }
            return View(paciente);
}

[HttpPost,ActionName("Delete") ]
[ValidateAntiForgeryToken]

public async Task<IActionResult> DeleteConfirm(int? id){

if(id==null){

    return NotFound();
}
    var paciente = await _context.Paciente.FindAsync(id);
    if(paciente==null){
        return NotFound();
    }
    _context.Paciente.Remove(paciente);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

    }
}