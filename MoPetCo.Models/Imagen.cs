using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class Imagen
    {
        [Key]
        public int IdImagen { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required, MaxLength(500)]
        public string UrlImagen { get; set; }
    }
}
