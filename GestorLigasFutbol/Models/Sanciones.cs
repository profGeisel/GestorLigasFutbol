using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class Sanciones
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La condicion de la sancion es requerida")]
        public string? EsActiva { get; set; }

        [Required(ErrorMessage = "El jugador es requerido")]
        public int IdJugador { get; set; }

        [Required(ErrorMessage = "El jugador es requerido")]
        public int IdEquipo { get; set; }

        [Required(ErrorMessage = "El jugador es requerido")]
        public int IdCampeonato {  get; set; }

        [Required(ErrorMessage = "El jugador es requerido")]
        public int IdTipoS {  get; set; }

     
    }
}
