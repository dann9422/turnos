using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using turnos.Models;

namespace turnos.Controllers
{
    public class PruebaController : Controller

    {
        private readonly TurnosContext _context;

        public PruebaController(TurnosContext context){

            _context = context;
        }
        
        public async Task<IActionResult> Index(){
        return View(await _context.Prueba.ToListAsync());


        }


    }
}