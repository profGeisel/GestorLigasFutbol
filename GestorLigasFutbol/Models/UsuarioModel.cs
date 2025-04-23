using System.ComponentModel.DataAnnotations;
namespace GestorLigasFutbol.Models
{
    public class JugadorModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage="El nombre es requerido")]
        [StringLength(20, ErrorMessage="Maximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 320 caracteres")]
        public string ApellidoM { get; set; }


        [Required(ErrorMessage = "El correo Electronico es requerido")]
        public string CorreoE { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El tipo de Usuario es requerida")]
        public int IdTipoUsuario { get; set; }
    }
}
