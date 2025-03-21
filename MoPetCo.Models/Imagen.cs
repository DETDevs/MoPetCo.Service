using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MoPetCo.Models
{
    public class Imagen
    {
        [Key]
        public int IdImagen { get; set; }
        public string? Descripcion { get; set; }
        public string? UrlImagen { get; set; }
        public IFormFile? DataImagen { get; set; }
    }
}
