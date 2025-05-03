using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using GestorLigasFutbol.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    // [Authorize]
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
            // COMBO JUGADORES 
            //Crear lista de tipos de Jugadores
            var jugadores = _context.Jugadores.Select(c => new { c.Id, c.Nombre, c.ApellidoP }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Jugadores = new SelectList(jugadores, "Id", "Nombre","ApellidoP");

            // COMBO EQUIPOS 
            //Crear lista de tipos de Jugadores
            var equipos = _context.Equipos.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Equipos = new SelectList(equipos, "Id", "Nombre");

            // COMBO CAMPEONATOS 
            //Crear lista de tipos de Campeonatos
            var campeonatos = _context.Campeonatos.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Campeonatos = new SelectList(campeonatos, "Id", "Nombre");

            // COMBO IdTipoS 
            //Crear lista de tipos de Campeonatos
            var tipoSanciones = _context.TipoSanciones.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.TipoSanciones = new SelectList(tipoSanciones, "Id", "Nombre");

            return View();
        }

        //metodo para crear una sancion
        [HttpPost]
        public IActionResult Insertar(Sanciones Sanciones)
        {
            if (ModelState.IsValid)
            {
                _context.CrearSanciones(Sanciones.EsActiva, Sanciones.IdJugador, Sanciones.IdEquipo, Sanciones.IdCampeonato, Sanciones.IdTipoS);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            // COMBO JUGADORES 
            //Crear lista de tipos de Jugadores
            var jugadores = _context.Jugadores.Select(c => new { c.Id, c.Nombre, c.ApellidoP }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Jugadores = new SelectList(jugadores, "Id", "Nombre", "ApellidoP");

            // COMBO EQUIPOS 
            //Crear lista de tipos de Jugadores
            var equipos = _context.Equipos.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Equipos = new SelectList(equipos, "Id", "Nombre");

            // COMBO CAMPEONATOS 
            //Crear lista de tipos de Campeonatos
            var campeonatos = _context.Campeonatos.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Campeonatos = new SelectList(campeonatos, "Id", "Nombre");

            // COMBO IdTipoS 
            //Crear lista de tipos de Campeonatos
            var tipoSanciones = _context.TipoSanciones.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.TipoSanciones = new SelectList(tipoSanciones, "Id", "Nombre");

            var sanciones = _context.ObtenerSancionesId(id);
            return View(sanciones);
        }
        [HttpPost]
        public IActionResult Actualizar(Sanciones Sanciones)
        {
            if (ModelState.IsValid && Sanciones.Id > 0)
            {
                _context.ActualizarSanciones(Sanciones.Id, Sanciones.EsActiva, Sanciones.IdJugador, Sanciones.IdEquipo, Sanciones.IdCampeonato, Sanciones.IdTipoS);
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
