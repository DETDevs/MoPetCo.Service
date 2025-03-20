using System.ComponentModel.DataAnnotations;

namespace MoPetCo.Models
{
    public class RangoPeso
    {
        [Key]
        public int IdRango { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public decimal PesoMin { get; set; }

        [Required]
        public decimal PesoMax { get; set; }
    }
}
