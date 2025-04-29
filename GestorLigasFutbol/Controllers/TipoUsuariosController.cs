using Microsoft.AspNetCore.Mvc;
using GestorLigasFutbol.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestorLigasFutbol.Data;
using Microsoft.AspNetCore.Authorization;


namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    [Authorize]
    public class TipoUsuariosController : Controller
    {
        private readonly DbContextTipoUsuarios _context;
        public TipoUsuariosController(DbContextTipoUsuarios context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tipoUsuarios = _context.ObtenerTipoUsuarios().ToList();

            return View(tipoUsuarios);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(TipoUsuarios TipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                _context.CrearTipoUsuario(TipoUsuarios.Nombre);
                return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            var tipoUsuario = _context.ObtenerTipoUsuarioId(id);
            return View(tipoUsuario);
        }
        [HttpPost]
        public IActionResult Actualizar(TipoUsuarios TipoUsuarios)
        {
            if (ModelState.IsValid && TipoUsuarios.Id > 0)
            {
                _context.ActualizarTipoUsuario(TipoUsuarios.Id, TipoUsuarios.Nombre);
                return RedirectToAction("Index");
            }

            return View();
        }


        //metodo para Eliminar 
        //GEt de Eliminar
        public IActionResult Eliminar(int id)
        {
            var TipoUsuario = _context.ObtenerTipoUsuarioId(id);
            return View(TipoUsuario);
        }
        [HttpPost]
        public IActionResult Eliminar(TipoUsuarios TipoUsuarios)
        {
            if (TipoUsuarios.Id > 0)
            {
                _context.EliminarTipoUsuarios(TipoUsuarios.Id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
