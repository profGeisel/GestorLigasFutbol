using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class LigasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage = "El Coreo es requerido")]
        [StringLength(320, ErrorMessage = "Maximo 320 caracteres")]
        public string CorreoE {  get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Telefono { get; set; }
        

    }
}
