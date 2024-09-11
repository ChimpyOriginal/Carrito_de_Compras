using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class Producto
    {
        private string nombreProducto; // Nombre del producto.
        private double precio; // Precio del producto.
        private int cantidad; // Cantidad disponible del producto.
        private string descripcion; // Descripción del producto.

        public Producto(string nombreProducto, double precio, int cantidad, string descripcion) // Constructor de la clase Producto.
        {
            this.nombreProducto = nombreProducto;
            this.precio = precio;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
        }
        //Setters y getters
        public string NombreProducto { get { return nombreProducto; } set { this.nombreProducto = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public double Precio { get { return precio; } set { precio = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        public string InfoProducto() // Obtiene la información completa del producto.
        {
            return (NombreProducto + " - $" + Precio + " - " + Cantidad + " disponibles: " + Descripcion);
        }

        public string InfoProductoCarrito() // Obtiene el nombre, precio y cantidad del producto agregada al carrito
        {
            return (NombreProducto + " - $" + Precio + " - Cantidad: " + Cantidad);
        }
    }
}
