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
    public class TipoSancionesController : Controller
    {
        private readonly DbContextP _context;
        public TipoSancionesController(DbContextP context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tipoSanciones = _context.ObtenerTipoSanciones().ToList();

            return View(tipoSanciones);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(TipoSanciones TipoSanciones)
        {
            if (ModelState.IsValid)
            {
                _context.CrearTipoSancion(TipoSanciones.Nombre, TipoSanciones.Descripcion,TipoSanciones.Tiempo,TipoSanciones.Valor,TipoSanciones.Estado, TipoSanciones.IdLiga);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var tipoSanciones = _context.ObtenerTipoSancionId(id);
            return View(tipoSanciones);
        }
        [HttpPost]
        public IActionResult Actualizar(TipoSanciones TipoSanciones)
        {
            if (ModelState.IsValid && TipoSanciones.Id > 0)
            {
                _context.ActualizarTipoSancion(TipoSanciones.Id, TipoSanciones.Nombre, TipoSanciones.Descripcion,TipoSanciones.Tiempo, TipoSanciones.Valor, TipoSanciones.Estado, TipoSanciones.IdLiga);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de Eliminar
        public IActionResult Eliminar(int id)
        {
            var TipoSanciones = _context.ObtenerTipoSancionId(id);
            return View(TipoSanciones);
        }
        [HttpPost]
        public IActionResult Eliminar(TipoSanciones TipoSanciones)
        {
            if (TipoSanciones.Id > 0)
            {
                _context.EliminarTipoSancion(TipoSanciones.Id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }

}



