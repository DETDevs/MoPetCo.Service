using System.ComponentModel.DataAnnotations;

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
