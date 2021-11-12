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


    }
}