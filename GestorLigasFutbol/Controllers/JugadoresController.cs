using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using GestorLigasFutbol.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    // [Authorize]
    public class JugadoresController : Controller
    {
        private readonly DbContextJugadores _context;
        public JugadoresController(DbContextJugadores context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var jugadores = _context.ObtenerJugadores().ToList();

            return View(jugadores);
        }
        public IActionResult Insertar()
        {
            //Crear lista de tipos de Equipos
            var equipos = _context.Equipos.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Equipos = new SelectList(equipos, "Id", "Nombre");

            return View();
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(Jugadores Jugadores)
        {
            if (ModelState.IsValid)
            {
                _context.CrearJugador(Jugadores.Nombre, Jugadores.ApellidoP, Jugadores.ApellidoM, Jugadores.NumeroCamisa, Jugadores.Fecha_Nacimiento, Jugadores.Edad, Jugadores.Cedula,Jugadores.IdEquipo);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            //Crear lista de tipos de Equipos
            var equipos = _context.Equipos.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Equipos = new SelectList(equipos, "Id", "Nombre");

            var usuario = _context.ObtenerJugadorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Actualizar(Jugadores Jugadores)
        {
            if (ModelState.IsValid && Jugadores.Id > 0)
            {
                _context.ActualizarJugador(Jugadores.Id, Jugadores.Nombre, Jugadores.ApellidoP, Jugadores.ApellidoM, Jugadores.NumeroCamisa, Jugadores.Fecha_Nacimiento, Jugadores.Edad, Jugadores.Cedula, Jugadores.IdEquipo);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var jugador = _context.ObtenerJugadorId(id);
            return View(jugador);
        }
        [HttpPost]
        public IActionResult Eliminar(Jugadores Jugadores)
        {
            if (Jugadores.Id > 0)
            {
                _context.EliminarJugador(Jugadores.Id);
                return RedirectToAction("Index");
            }

            return View();
        }

       

    }

}
