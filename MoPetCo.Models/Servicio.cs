using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicios { get; set; }

        [Required, MaxLength(255)]
        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        [Required]
        public string Incluye { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
