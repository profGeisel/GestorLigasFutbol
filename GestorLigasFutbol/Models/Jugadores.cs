using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class Jugadores
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string ApellidoM { get; set; }

        public byte Foto { get; set; }

        [Required(ErrorMessage = "El numero de camiseta es requerido")]
        public int NumeroCamisa { get; set; }

        [Required(ErrorMessage = "El año de nacimiento es requerido")]
        public DateOnly Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "La cedula es requerida")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El equipo es requerido")]
        public int IdEquipo { get; set; }
    }
}
