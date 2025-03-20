using System.ComponentModel.DataAnnotations;


namespace MoPetCo.Models
{
    public class Precio
    {
        [Key]
        public int IdPrecio { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public RangoPeso RangoPeso { get; set; }

        public Servicio Servicio { get; set; }
    }
}
