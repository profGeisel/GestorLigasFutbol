using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using GestorLigasFutbol.Data;

namespace GestorLigasFutbol.Controllers
{
    public class SancionesController : Controller
    {
        private readonly DbContextSanciones _context;
        public SancionesController(DbContextSanciones context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sanciones = _context.ObtenerSanciones().ToList();

            return View(sanciones);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(Sanciones Sanciones)
        {
            if (ModelState.IsValid)
            {
                _context.CrearSanciones(Sanciones.Activa, Sanciones.IdJugador, Sanciones.IdEquipo, Sanciones.IdCampeonato, Sanciones.IdTipoS);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var sanciones = _context.ObtenerSancionesId(id);
            return View(sanciones);
        }
        [HttpPost]
        public IActionResult Actualizar(Sanciones Sanciones)
        {
            if (ModelState.IsValid && Sanciones.Id > 0)
            {
                _context.ActualizarSanciones(Sanciones.Id, Sanciones.Activa, Sanciones.IdJugador, Sanciones.IdEquipo, Sanciones.IdCampeonato, Sanciones.IdTipoS);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var sanciones = _context.ObtenerSancionesId(id);
            return View(sanciones);
        }
        [HttpPost]
        public IActionResult Eliminar(Sanciones Sanciones)
        {
            if (Sanciones.Id > 0)
            {
                _context.EliminarSanciones(Sanciones.Id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }

}
