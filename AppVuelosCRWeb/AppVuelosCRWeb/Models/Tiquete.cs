using System.ComponentModel.DataAnnotations;

namespace AppVuelosCRWeb.Models
{
    public class Tiquete
    {
        [Key]
        public string cedula { get; set; }

        public string  nombreCompleto { get; set; }

        public string lugarDestino { get; set; }

        public string aerolinea { get; set; }

        public decimal pagoTiquete { get; set; }

        public decimal impuesto { get; set; }

        public decimal precioFinal { get; set; }
    }
}
