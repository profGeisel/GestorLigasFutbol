using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GestorLigasFutbol.Models
{
    public class Usuario :IdentityUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El correo Electronico es requerido")]
        public string? CorreoE { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string? Contrasena { get; set; }

        //propiedad para mantener sesion 
        [NotMapped]
        public bool MantenerActivo { get; set; }


    }
}
