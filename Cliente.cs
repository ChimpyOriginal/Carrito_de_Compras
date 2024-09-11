using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class Cliente
    {
        private string clienteNombre; // Nombre del cliente
        private string email; // Correo electrónico del cliente
        private string contraseña; // Contraseña del cliente
        private List<Producto> productos; // Productos en el carrito del cliente

        public Cliente(string clienteNombre, string email, string contraseña) // Constructor de la clase Cliente.
        {
            this.clienteNombre = clienteNombre;
            this.email = email;
            this.contraseña = contraseña;
            productos = new List<Producto>();
        }
        //Setters y getters
        public string ClienteNombre { get { return clienteNombre; } }
        public string Email { get { return email; } }
        public string Contraseña { get { return contraseña; } }
        public List<Producto> Productos { get { return productos; } }

        public void Agregar(Producto producto, int cantidad)  // Agrega un producto al carrito del cliente, o lo actualiza si ya existe
        {
            bool encontrado = false;

            // Verifica si el producto ya está en el carrito.
            foreach (var p in productos)
            {
                if (p.NombreProducto == producto.NombreProducto)
                {
                    p.Cantidad += cantidad;
                    encontrado = true;
                    break;
                }
            }

            // Si el producto no está en el carrito, lo agrega con la cantidad especificada.
            if (!encontrado)
            {
                productos.Add(new Producto(producto.NombreProducto, producto.Precio, cantidad, producto.Descripcion));
            }
        }
    }
}
