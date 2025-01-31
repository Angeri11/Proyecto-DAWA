using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Propuesta")]
    public class Propuesta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string? NombrePropuesta { get; set; }

        [Required]
        [StringLength(255)]
        public string? NombreEstudiante { get; set; }

        [Required]
        [StringLength(10)]
        public string? CedulaEstudiante { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }


        [Required]
        public EstadoPropuesta Estado { get; set; } = EstadoPropuesta.Pendiente;
    }
}
