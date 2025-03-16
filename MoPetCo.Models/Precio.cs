using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
