using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using GestorLigasFutbol.Data;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
   // [Authorize]
    public class EntrenadoresController : Controller
    {
        private readonly DbContextEntrenadores _context;
        public EntrenadoresController(DbContextEntrenadores context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var entrenadores = _context.ObtenerEntrenadores().ToList();

            return View(entrenadores);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(Entrenadores Entrenadores)
        {
            if (ModelState.IsValid)
            {
                _context.CrearEntrenador(Entrenadores.Nombre, Entrenadores.ApellidoP, Entrenadores.ApellidoM, Entrenadores.FechaNacimiento, Entrenadores.CorreoE, Entrenadores.Cedula, Entrenadores.IdEquipo);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var usuario = _context.ObtenerEntrenadorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Actualizar(Entrenadores Entrenadores)
        {
            if (ModelState.IsValid && Entrenadores.Id > 0)
            {
                _context.ActualizarEntrenador(Entrenadores.Id, Entrenadores.Nombre, Entrenadores.ApellidoP, Entrenadores.ApellidoM, Entrenadores.FechaNacimiento, Entrenadores.CorreoE, Entrenadores.Cedula, Entrenadores.IdEquipo);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var entrenador = _context.ObtenerEntrenadorId(id);
            return View(entrenador);
        }
        [HttpPost]
        public IActionResult Eliminar(Entrenadores Entrenadores)
        {
            if (Entrenadores.Id > 0)
            {
                _context.EliminarEntrenador(Entrenadores.Id);
                return RedirectToAction("Index");
            }

            return View();
        }


    }

}
