using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testBackEnd.Models
{
    public class CarritoCompra
    {
        public string IdCliente { get; set; }
        public string IdProducto { get; set; }
        public decimal Cantidad { get; set; }
    }
}
