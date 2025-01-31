using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Revisor")]
    public class Revisor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nombres { get; set; }

        [Required]
        [StringLength(255)]
        public string? Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string? Cedula { get; set; }

        [Required]
        [StringLength(100)]
        public string? Correo { get; set; }
    }
}
