using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
