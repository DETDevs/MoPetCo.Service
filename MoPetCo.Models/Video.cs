using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class Video
    {
        [Key]
        public int IdVideo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required, MaxLength(500)]
        public string UrlVideo { get; set; }
    }
}
