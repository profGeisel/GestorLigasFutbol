using GestorLigasFutbol.Models;

namespace GestorLigasFutbol.Services
{
    public class Sesion
    {
        public interface ISesionService
        {
            Usuario UsuActual { get; set; }
        }
        public class SesionService : ISesionService
        {
            public Usuario UsuActual { get; set; }
        }
    }
}
