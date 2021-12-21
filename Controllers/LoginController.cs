using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using turnos.Models;

namespace turnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurnosContext _context;
        public LoginController(TurnosContext context){
            _context = context;
        }

public IActionResult Index(){
return View();
}

  public IActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                //Encriptar Password
                string passEncriptado = Encriptar(login.Password);
               
                //Consulta a la base si existe el usuario, y si el password es correcto
                var loginUsuario = _context.Login.Where(l => l.Usuario == login.Usuario && l.Password == passEncriptado)
                .FirstOrDefault();
 
                if(loginUsuario != null)
                {
                    HttpContext.Session.SetString("usuario",loginUsuario.Usuario);
                    return RedirectToAction("Index","Home");
                }else
                {
                  ViewData["errorLogin"] = "Los datos son incorrectos, intente nuevamente.";
                 return View("Index");
                }
 
            }
            return View("Index");
        }
 
        public string Encriptar(string password)
        {
            // Se define un objeto SHA en un espacio y se le asigna el metodo CREATE 
            using (SHA256 sha256hash = SHA256.Create())
            {
               
               // Se pasa el metodo ComputeHash a traves del objeto Encoding el string password convertido a Bytes, por medio del metodo GetBytes
               // Luego se lo asigna a una Array 
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(password));
 
                // se crea e inicializa un objeto del tipo StringBuilder
                StringBuilder stringBuilder = new StringBuilder();
               // se itera el objeto bytes para ir concatenando los valores del array
                for(int i=0;i<bytes.Length; i++)
                {
                    // luego se convierte el valor binario en hexadecimal
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}