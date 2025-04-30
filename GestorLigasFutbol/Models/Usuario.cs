using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorLigasFutbol.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El correo Electronico es requerido")]
        public string? CorreoE { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string? Contrasena { get; set; }

        //propiedad para mantener sesion 
        [NotMapped]
        public bool MantenerActivo { get; set; }


    }
}
