using System.Security.Claims;
using GestorLigasFutbol.Data;
using GestorLigasFutbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using static GestorLigasFutbol.Services.Sesion;


namespace GestorLigasFutbol.Controllers
{
    
    public class UsuariosLoginController : Controller
    {

        private readonly DbContextLogin _contextLogin;
        private readonly ISesionService _sesionService;

        public UsuariosLoginController(DbContextLogin contextLogin, ISesionService sesionService)
        {
            _contextLogin = contextLogin;
            _sesionService = sesionService;
        }

        //metodo para mostrar la vista de login o formulario de ingreso
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correoE)
        {
            var usu = _contextLogin.Usuario.FirstOrDefault(u=>u.CorreoE == correoE);
            if (usu != null)
            {
                //Inicio de sesion Singleton
                //_sesionService.UsuActual = usu;
                return RedirectToAction("Gestion", "Home");
            }
           
            ViewBag.Error = "Usuario no encontrado";
            return View();
        }

        //Cerrar Sesion
        public IActionResult Logout()
        {
            _sesionService.UsuActual = null;
            return RedirectToAction("Login");
        }

        

        [ResponseCache(Duration =0,Location = ResponseCacheLocation.None,NoStore =true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
       
    }
}
