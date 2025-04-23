using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class CampeonatosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de Inicio es requerida")]
        public DateTime FechaInicio {  get; set; }

        [Required(ErrorMessage = "La fecha de Cierre es requerida")]
        public DateTime FechaCierre { get; set; }

        [Required(ErrorMessage = "El numero de Equipos Participantes es requerido")]
        public int NumeroEquiposP{  get; set; }

        [Required(ErrorMessage = "El estado del campeonato es requerido")]
        public Boolean activo { get; set; }

        [Required(ErrorMessage = "Debe seleccionarse una liga")]
        public int IdLiga { get; set; }

    }
}
