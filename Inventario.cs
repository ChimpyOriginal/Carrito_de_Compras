using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class Inventario
    {
        private List<Producto> productos; // Lista de productos en el inventario.

        public Inventario() // Constructor de la clase Inventario. Inicializa la lista de productos y crea productos iniciales.
        {
            productos = new List<Producto>();
            CrearInventario();
        }

        private void CrearInventario() // Crea productos iniciales para el inventario.
        {
            productos.Add(new Producto("Leche", 27.5, 10, "Lácteo básico para bebidas o cocinar."));
            productos.Add(new Producto("Arroz", 24.9, 5, "Grano saludable, fuente de fibra."));
            productos.Add(new Producto("Detergente", 39.9, 7, "Producto de limpieza para ropa."));
            productos.Add(new Producto("Huevos", 40, 11, "Fuente de proteína, ideal para el desayuno."));
        }

        public Producto ObtenerProductoPorNombre(string nombreProducto) // Obtiene un producto del inventario por su nombre.
        {
            //Hace una búsqueda entre la lista de productos hasta encontrar una que coincida con el nombre
            foreach (var producto in productos)
            {
                if (producto.NombreProducto == nombreProducto)
                {
                    return producto;
                }
            }
            return null;
        }

        public List<Producto> ObtenerProductos() // Obtiene la lista de todos los productos en el inventario.
        {
            return productos;
        }

        public void ActualizarStock(string nombreProducto, int cantidad) // Actualiza la cantidad de un producto en el inventario luego de que un cliente agregara uno a su carrito.
        {
            foreach (var producto in productos)
            {
                if (producto.NombreProducto == nombreProducto)
                {
                    producto.Cantidad = cantidad;
                    return;
                }
            }
        }
    }
}
