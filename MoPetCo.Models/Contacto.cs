using System.ComponentModel.DataAnnotations;

namespace MoPetCo.Models
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Number { get; set; }
        public string Correo { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Pendiente";
    }
}
