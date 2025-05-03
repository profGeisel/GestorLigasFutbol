using Microsoft.AspNetCore.Mvc;
using GestorLigasFutbol.Data;
using GestorLigasFutbol.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;




namespace GestorLigasFutbol.Controllers
{

    public class UsuariosController : Controller
    {
        private readonly DbContextUsuarios _context;
        public UsuariosController(DbContextUsuarios context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var usuarios = _context.ObtenerUsuarios().ToList();

            return View(usuarios);
        }
        public IActionResult Insertar()
        {
            //Crear lista de tipos de Usuarios
            var tipoUsuarios = _context.TipoUsuarios.Select( c=>new {c.Id,c.Nombre}).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.TipoUsuarios = new SelectList(tipoUsuarios, "Id", "Nombre");

            return View();
         
        }

        //metodo para crear un usuario
        [HttpPost]
        public IActionResult Insertar(Usuarios Usuarios)
        {

            if (ModelState.IsValid ){
                _context.CrearUsuario(Usuarios.Nombre, Usuarios.ApellidoP, Usuarios.ApellidoM, Usuarios.CorreoE, Usuarios.Contrasena, Usuarios.IdTipoUsuarios);
            return RedirectToAction("Index");
            }
            return View();

        }

        //metodo para la actualizacion 
        //GEt de actualizar
        public IActionResult Actualizar(int id)
        {
            //Crear lista de tipos de Usuarios
            var tipoUsuarios = _context.TipoUsuarios.Select(c => new { c.Id, c.Nombre }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.TipoUsuarios = new SelectList(tipoUsuarios, "Id", "Nombre");

            var usuario = _context.ObtenerUsuarioId(id);
           
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Actualizar(Usuarios Usuarios)
        {
            if (ModelState.IsValid && Usuarios.Id >0 )
            {
                _context.ActualizarUsuario(Usuarios.Id, Usuarios.Nombre, Usuarios.ApellidoP, Usuarios.ApellidoM, Usuarios.CorreoE, Usuarios.Contrasena, Usuarios.IdTipoUsuarios);
                return RedirectToAction("Index");
            }

                return View();
        }


        //metodo para Eliminar 
        //GEt de actualizar
        public IActionResult Eliminar(int id)
        {
            var usuario = _context.ObtenerUsuarioId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Eliminar(Usuarios Usuarios)
        {
            if (Usuarios.Id > 0)
            {
                _context.EliminarUsuarios(Usuarios.Id);
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
