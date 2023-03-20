using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testBackEnd.Models;

namespace testBackEnd.Controllers
{
    public class ClienteDB
    {
        private string connectionString;

        public ClienteDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ClienteId, Nombres, Email FROM dbo.Clientes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.ClienteId = reader.GetString(0);
                            cliente.Nombres = reader.GetString(1);
                            cliente.Email = reader.GetString(2);
                            clientes.Add(cliente);
                        }
                    }
                }
            }
            return clientes;
        }
    }
}
