using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MoPetCo.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }

        [Required, MaxLength(255)]
        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string Incluye { get; set; }

        [Required]
        public string Descripcion { get; set; }
        public string Icon { get; set; }
        public string UrlImagen { get; set; }

        public RangoPeso RangoPeso { get; set; }
        public Precio Precio { get; set; }

        // Propiedad NO mapeada para manejar el JSON como lista de objetos
        [NotMapped]
        public List<IncluyeItem> IncluyeLista
        {
            get => string.IsNullOrEmpty(Incluye) ? new List<IncluyeItem>() : JsonSerializer.Deserialize<List<IncluyeItem>>(Incluye);
            set => Incluye = JsonSerializer.Serialize(value);
        }
    }

    // Definir el modelo de cada ítem dentro de "Incluye"
    public class IncluyeItem
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
