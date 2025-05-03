using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GestorLigasFutbol.Models
{
    public class Eventos
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = "El equipo Visitante es requerido")]
        public int EquipoVisitante {  get; set; }

        [Required(ErrorMessage = "El equipo residente es requerido")]
        public int EquipoResidente {  get; set; }

        [Required(ErrorMessage = "EL campeonato es requerido")]
        public int IdCampeonato { get; set; }

    }
}
