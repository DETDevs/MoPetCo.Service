using System.ComponentModel.DataAnnotations;


namespace MoPetCo.Models
{
    public class Precio
    {
        public int IdPrecio { get; set; }

        public decimal? Monto { get; set; }

        public RangoPeso? RangoPeso { get; set; }

        public Servicio? Servicio { get; set; }
    }
}
