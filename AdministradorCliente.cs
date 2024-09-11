using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class AdministradorCliente
    {
        private List<Cliente> clientes; // Lista de clientes registrados

        public AdministradorCliente()
        {
            clientes = new List<Cliente>();
        }

        public void Registro(string nombreCliente, string email, string contraseña)  // Registra un nuevo cliente en la lista
        {
            Cliente cliente = new Cliente(nombreCliente, email, contraseña);
            clientes.Add(cliente);
        }

        public Cliente BuscarCliente(string email) // Busca un cliente en la lista por correo electrónico
        {
            foreach (Cliente c in clientes)
            {
                if (c.Email == email)
                {
                    return c;
                }
            }
            return null;
        }

    }
}
