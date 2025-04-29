using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class ContextLogin
    {
        public string Conexion {  get; }

        //constructor
        public ContextLogin(string conexion)
        {
            Conexion = conexion;

        }

    }
}
