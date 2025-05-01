using System.ComponentModel.DataAnnotations;

namespace GestorLigasFutbol.Models
{
    public class Entrenadores
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

        [Required(ErrorMessage = "La fecha de nacimiento es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        public String CorreoE { get; set; }

        [Required(ErrorMessage = "La cedula es requerida")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El equipo es requerido")]
        public int IdEquipo { get; set; }
    }
}
