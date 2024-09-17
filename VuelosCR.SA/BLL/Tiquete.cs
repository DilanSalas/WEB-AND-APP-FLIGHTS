using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Tiquete
    {
        public string cedula { get; set; }

        public string nombreCompleto { get; set; }

        public string lugarDestino { get; set; }

        public string aerolinea { get; set; }

        public decimal pagoTiquete { get; set; }

        public decimal impuesto { get; set; }

        public decimal precioFinal { get; set; }
    }
}
