using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class Contacto
    {
        [Key]
        public int IdContacto { get; set; }

        [Required, MaxLength(255)]
        public string Nombre { get; set; }

        [Required, MaxLength(255)]
        public string Correo { get; set; }

        public string Direccion { get; set; }

        [Required]
        public string Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        [Required, MaxLength(50)]
        public string Estado { get; set; } = "Pendiente";
    }
}
