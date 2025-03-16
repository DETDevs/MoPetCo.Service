using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public string Incluye { get; set; }

        [Required]
        public string Descripcion { get; set; }

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
