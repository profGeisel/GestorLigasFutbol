using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace GestorLigasFutbol.Models
{
    public class Equipos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }
        public byte Logo   { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(320, ErrorMessage = "Maximo 320 caracteres")]
        public string CorreoE {  get; set; }

        [Required(ErrorMessage = "El Lugar es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Lugar { get; set; }

        public DateTime FechaFundacion { get; set; }

        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string Descripcion { get;set; }

        [Required(ErrorMessage = "El numero de identificaci[on es requerido")]
        [StringLength(12, ErrorMessage = "Maximo 12 caracteres")]
        public int NumIdentificacion { get; set; }

        [Required(ErrorMessage = "El Campeonato es requerido")]
        public int IdCampeonato { get; set; }




    }
}
