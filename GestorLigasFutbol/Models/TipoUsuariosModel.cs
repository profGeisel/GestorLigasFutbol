using System.ComponentModel.DataAnnotations;
namespace GestorLigasFutbol.Models
{
    public class TipoUsuariosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Nombre { get; set; }

    }
}
