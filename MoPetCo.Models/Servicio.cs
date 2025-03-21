using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MoPetCo.Models
{
    public class Servicio
    {
        public int IdServicio { get; set; }

        public string? Titulo { get; set; }

        public string? SubTitulo { get; set; }

        public string? Incluye { get; set; }

        public string? Descripcion { get; set; }
        public string? Icon { get; set; }
        public string? UrlImagen { get; set; }

        public List<Precio> Precio { get; set; } = new List<Precio>();

        [NotMapped]
        public List<IncluyeItem> IncluyeLista
        {
            get => string.IsNullOrEmpty(Incluye) ? new List<IncluyeItem>() : JsonSerializer.Deserialize<List<IncluyeItem>>(Incluye);
            set => Incluye = JsonSerializer.Serialize(value);
        }
    }

    public class IncluyeItem
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
