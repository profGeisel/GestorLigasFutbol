using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class ResultadosIndividuales
    {
        public int Id {  get; set; }
        [Required (ErrorMessage ="El jugador es requerido")]
        public string IdJugador { get; set; }
        [Required(ErrorMessage = "El numero de goles es requerido")]
        public int cantidadGoles {  get; set; }
        [Required(ErrorMessage = "El numero de asistencias es requerido")]
        public  int asistencias { get; set; }
        [Required(ErrorMessage = "El numero de tarjetas rojas es requerido")]
        public int tRojas { get; set; }
        [Required(ErrorMessage = "El numero de tarjetas amarillas es requerido")]
        public int tAmarillas { get; set; }

    }
}
