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
    public class EventosController : Controller
    {
        private readonly DbContextEventos _context;
        public EventosController(DbContextEventos context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var eventos = _context.ObtenerEventos().ToList();

            return View(eventos);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un Eventos
        [HttpPost]
        public IActionResult Insertar(Eventos Eventos)
        {
            if (ModelState.IsValid)
            {
                _context.CrearEvento(Eventos.Nombre, Eventos.Fecha, Eventos.Hora, Eventos.EquipoVisitante, Eventos.EquipoResidente, Eventos.IdCampeonato);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var evento = _context.ObtenerEventoId(id);
            return View(evento);
        }
        [HttpPost]
        public IActionResult Actualizar(Eventos Eventos)
        {
            if (ModelState.IsValid && Eventos.Id > 0)
            {
                _context.ActualizarEventos(Eventos.Id, Eventos.Nombre, Eventos.Fecha, Eventos.Hora, Eventos.EquipoVisitante, Eventos.EquipoResidente, Eventos.IdCampeonato);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var evento = _context.ObtenerEventoId(id);
            return View(evento);
        }
        [HttpPost]
        public IActionResult Eliminar(Eventos Eventos)
        {
            if (Eventos.Id > 0)
            {
                _context.EliminarUsuarios(Eventos.Id);
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
