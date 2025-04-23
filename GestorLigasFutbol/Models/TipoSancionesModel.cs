using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class TipoSancionesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Nombre {  get; set; }

        [Required(ErrorMessage = "La descripcion es requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Descripcion {  get; set; }

        [Required(ErrorMessage = "La duracion de la sancion es requerida")]
        public int Tiempo { get; set; }

        [Required(ErrorMessage = "El Valor o costo es requerido")]
        public int Valor {  get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado {  get; set; }

        [Required(ErrorMessage = "La liga es requerida")]
        public int IdLiga {  get; set; }
    }
}
