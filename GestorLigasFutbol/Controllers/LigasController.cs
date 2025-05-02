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
    public class LigasController : Controller
    {
       
        private readonly DbContextLigas _context;
        public LigasController(DbContextLigas context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ligas = _context.ObtenerLigas().ToList();

            return View(ligas);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(Ligas Ligas)
        {
            if (ModelState.IsValid)
            {
                _context.CrearLiga(Ligas.Nombre, Ligas.Descripcion, Ligas.CorreoE, Ligas.Telefono);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var liga = _context.ObtenerLigasId(id);
            return View(liga);
        }
        [HttpPost]
        public IActionResult Actualizar(Ligas Ligas)
        {
            if (ModelState.IsValid && Ligas.Id > 0)
            {
                _context.ActualizarLiga(Ligas.Id, Ligas.Nombre, Ligas.Descripcion, Ligas.CorreoE, Ligas.Telefono);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var liga = _context.ObtenerLigasId(id);
            return View(liga);
        }
        [HttpPost]
        public IActionResult Eliminar(Ligas Ligas)
        {
            if (Ligas.Id > 0)
            {
                _context.EliminarLiga(Ligas.Id);
                return RedirectToAction("Index");
            }

            return View();
        }


    }

}
