using System.ComponentModel.DataAnnotations;

namespace MoPetCo.Models
{
    public class RangoPeso
    {
        public int IdRango { get; set; }

        public string? Nombre { get; set; }

        public decimal? PesoMin { get; set; }

        public decimal? PesoMax { get; set; }
    }
}
