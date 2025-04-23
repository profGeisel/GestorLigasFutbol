using Microsoft.AspNetCore.Mvc;
using GestorLigasFutbol.Data;




namespace GestorLigasFutbol.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Usuarios = _context.Usuarios.ToList();
            return View(Usuarios);
        }
    }
}
