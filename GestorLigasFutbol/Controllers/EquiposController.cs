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
    public class EquiposController : Controller
    {
        private readonly DbContextEquipos _context;
        public EquiposController(DbContextEquipos context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var equipos = _context.ObtenerEquipos().ToList();

            return View(equipos);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un equipos
        [HttpPost]
        public IActionResult Insertar(Equipos Equipos)
        {
            if (ModelState.IsValid)
            {
                _context.CrearEquipo(Equipos.Nombre, Equipos.CorreoE, Equipos.Lugar, Equipos.FechaFundacion, Equipos.Descripcion, Equipos.NumIdentificacion, Equipos.IdCampeonato);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var Equipo = _context.ObtenerEquipoId(id);
            return View(Equipo);
        }
        [HttpPost]
        public IActionResult Actualizar(Equipos Equipos)
        {
            if (ModelState.IsValid && Equipos.Id > 0)
            {
                _context.ActualizarEquipo(Equipos.Id, Equipos.Nombre, Equipos.CorreoE, Equipos.Lugar, Equipos.FechaFundacion, Equipos.Descripcion, Equipos.NumIdentificacion, Equipos.IdCampeonato);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var equipo = _context.ObtenerEquipoId(id);
            return View(equipo);
        }
        [HttpPost]
        public IActionResult Eliminar(Equipos Equipos)
        {
            if (Equipos.Id > 0)
            {
                _context.EliminarEquipo(Equipos.Id);
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
