using testBackEnd.Controllers;

class Program
{
    static void Main(string[] args)
    {
        var clientesRepo = new ClienteDB("Data Source=practicas-sql.database.windows.net;Initial Catalog=cliente;Persist Security Info=False;User ID=mperez;Password=Admin123456");
        var carritoRepo = new CarritoCompraDB("Data Source=practicas-sql.database.windows.net;Initial Catalog=carrito-compra;Persist Security Info=False;User ID=mperez;Password=Admin123456");
        var productosRepo = new ProductoDB("Data Source=practicas-sql.database.windows.net;Initial Catalog=producto;Persist Security Info=False;User ID=mperez;Password=Admin123456");

        var clientes = clientesRepo.ObtenerClientes();
        var carrito = carritoRepo.ObtenerCarritoCompra("d7f5085b-c23a-49af-a0c3-7eb0a704c8b7");
        var productos = productosRepo.ObtenerProductos();

        var result = from c in clientes
                     join ca in carrito on c.ClienteId equals ca.IdCliente
                     join p in productos on ca.IdProducto equals p.IdProducto
                     select new
                     {
                         ClienteId = c.ClienteId,
                         ProductoId = p.IdProducto,
                         ProductoNombre = p.Nombre,
                         ClienteNombre = c.Nombres,
                         Cantidad = ca.Cantidad
                     };

        foreach (var item in result)
        {
            Console.WriteLine($"{item.ClienteId} - {item.ProductoId} - {item.ProductoNombre} - {item.ClienteNombre} - {item.Cantidad}");
        }
    }
}