using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class Carrito
    {
        private Inventario inventario; // Inventario de productos

        public Carrito() //Constructor de la clase Carrito.
        {
            inventario = new Inventario();
        }

        public short AgregarProducto(string nombreProducto, int cantidad, Cliente clienteActual) // Agrega un producto al carrito del cliente actual, si hay stock suficiente
        {
            Producto producto = inventario.ObtenerProductoPorNombre(nombreProducto);

            if (producto == null)
            {
                return 3; // Producto no encontrado
            }

            if (producto.Cantidad < cantidad)
            {
                return 2; // Stock insuficiente
            }

            clienteActual.Agregar(producto, cantidad);
            producto.Cantidad -= cantidad;

            return 1; // Producto agregado
        }

        public double CalcularTotal(Cliente clienteActual) // Calcula el total del carrito del cliente
        {
            double total = 0;

            // Revisa la lista de productos del cliente y hace una sumatoria de los precios.
            foreach (var producto in clienteActual.Productos)
            {
                total += producto.Precio * producto.Cantidad;
            }
            return total;
        }

        public List<Producto> ObtenerCatalogo()   // Obtiene la lista de productos del inventario
        {
            return inventario.ObtenerProductos();
        }
    }

}
