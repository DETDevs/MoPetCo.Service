using System.ComponentModel.DataAnnotations;

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
