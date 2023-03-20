using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testBackEnd.Models;

namespace testBackEnd.Controllers
{
    public class CarritoCompraDB
    {
        private string connectionString;

        public CarritoCompraDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CarritoCompra> ObtenerCarritoCompra(string clienteId)
        {
            List<CarritoCompra> carritosCompras = new List<CarritoCompra>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IdProducto, Cantidad FROM dbo.carrito_de_compras WHERE IdCliente = @clienteId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clienteId", clienteId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarritoCompra carritoCompra = new CarritoCompra();
                            carritoCompra.IdCliente = clienteId;
                            carritoCompra.IdProducto = reader.GetString(0);
                            carritoCompra.Cantidad = reader.GetDecimal(1);
                            carritosCompras.Add(carritoCompra);
                        }
                    }
                }
            }

            return carritosCompras;
        }
    }
}
