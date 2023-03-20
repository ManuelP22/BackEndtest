using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testBackEnd.Models;

namespace testBackEnd.Controllers
{
    public class ProductoDB
    {
        private string connectionString;

        public ProductoDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IdProducto, Nombre FROM dbo.Productos";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();
                            producto.IdProducto = reader.GetString(0);
                            producto.Nombre = reader.GetString(1);
                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }
    }
}

