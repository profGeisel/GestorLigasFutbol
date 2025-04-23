using System;
using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class ResultadosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Equipo es requerido")]
        public int IdEquipo { get; set; }
        [Required(ErrorMessage = "El Evento es requerido")]
        public int  IdEvento { get; set; }
        [Required(ErrorMessage = "Si gano digite 1 y si no digite 0")]
        public int Triunfos { get; set; }
        [Required(ErrorMessage = "Si empato digite 1 y si perdio digite 0")]
        public int Empates { get; set; }
        [Required(ErrorMessage = "Si perdio digite 1 y si no dijite 0")]
        public int Derrotas { get; set; }

        [Required(ErrorMessage = "Digite la cantidad de juegos")]
        public int Juegos { get; set; }
        [Required(ErrorMessage = "Debe indicar la cantidad de goles a favor")]
        public int GolesFavor { get; set; }
        [Required(ErrorMessage = "Debe indicar la cantidad de goles en contra")]
        public int GolesContra { get; set; }
        [Required(ErrorMessage = "Debe indicar la diferencia de goles")]
        public int DiferenciaGoles { get; set; }

    }
}
