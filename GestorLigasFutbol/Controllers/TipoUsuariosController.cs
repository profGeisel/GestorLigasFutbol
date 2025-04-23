using Microsoft.AspNetCore.Mvc;
using GestorLigasFutbol.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestorLigasFutbol.Data;


namespace GestorLigasFutbol.Controllers
{
    public class TipoUsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public TipoUsuariosController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var TipoUsuarios = _context.TipoUsuarios.ToList();
            return View(TipoUsuarios);
        }       

    }
}
