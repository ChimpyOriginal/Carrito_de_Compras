using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class Menu //Clase que maneja las opciones del menú y la interacción con el usuario.
    {
        static Carrito carrito = new Carrito(); // Instancia del carrito de compras.
        static Inventario inventario = new Inventario(); // Instancia del inventario de productos.
        static Cliente clienteActual; // Cliente que está actualmente logueado.
        static AdministradorCliente administradorCliente = new AdministradorCliente(); // Gestión de clientes.
        List<Opcion> opciones; // Lista de opciones disponibles en el menú.


        private bool sesionIniciada; // Estado de la sesión.

        public Menu() //Constructor de la clase Menu. Inicializa el menú y gestiona las opciones.
        {
            sesionIniciada = false;
            opciones = new List<Opcion>()
            {
                new Opcion("Iniciar sesión.", IniciarSesion),
                new Opcion("Registrarse.", Registro),
            };

            MostrarMenu();

            while (true)
            {
                ElegirOpcion();
            }
        }

        public void MostrarMenu() //Muestra el menú principal al usuario.
        {
            Console.Clear();
            Console.WriteLine("BIENVENIDO AL SUPERMERCADO RKMJJ.\n");

            // Muestra las opciones disponibles en el menú.
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + opciones[i].Message);
            }
        }

        public void ElegirOpcion() //Permite al usuario elegir una opción del menú.
        {
            Console.Write("\nElige una opción: ");
            int numOpcion = Convert.ToInt32(Console.ReadLine()) - 1;

            // Ejecuta la acción correspondiente a la opción seleccionada.
            if (numOpcion >= 0 && numOpcion < opciones.Count)
            {
                Console.Clear();
                opciones[numOpcion].Action.Invoke();
            }
            else
            {
                Console.WriteLine("\nOpción no válida. Por favor, elige una opción válida del menú.");
                Continuar();
            }

            MostrarMenu();
        }

        private void ActualizarOpciones() // Actualiza las opciones del menú cuando la sesión está iniciada.
        {
            if (sesionIniciada)
            {
                opciones = new List<Opcion>()
                {
                    new Opcion("Mostrar catálogo de productos.", MostrarCatalogo),
                    new Opcion("Agregar productos al carrito.", AgregarProducto),
                    new Opcion("Ver productos en el carrito.", VerCarrito),
                    new Opcion("Ver costo total.", VerTotal),
                    new Opcion("Cerrar sesión.", () => Environment.Exit(0))
                };
            }
        }

        public void IniciarSesion() // Permite al usuario iniciar sesión proporcionando el correo electrónico y la contraseña.
        {
            Console.Write("Correo electrónico: ");
            string email = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contraseña = Console.ReadLine();

            Cliente cliente = administradorCliente.BuscarCliente(email);

            // Verifica si el cliente existe y la contraseña es correcta.
            if (cliente != null && cliente.Contraseña == contraseña)
            {
                clienteActual = cliente;
                Console.WriteLine($"¡Bienvenido, {cliente.ClienteNombre}!");
                sesionIniciada = true;
                ActualizarOpciones();
            }
            else 
            {
                Console.WriteLine("Cliente no encontrado o contraseña incorrecta. ¿Desea registrarse? (S/N)");
                string respuesta = Console.ReadLine();

                // Ofrece la opción de registrarse si el cliente no se encuentra.
                if (respuesta == "S" || respuesta == "s")
                {
                    Registro(); //Llama al método para hacer el registro del cliente
                }
                else if (respuesta == "N" || respuesta == "n")
                {
                    Console.WriteLine("Operación cancelada.");
                    Continuar();
                }
                else
                {
                    Console.WriteLine("Respuesta no válida.");
                    Continuar();

                }
            }

        }
        
        public void IniciarSesion(string email, string contraseña) // Sobrecarga del método iniciar sesión, este acepta parámetros y es llamado luego de que un cliente se registre
        {
            Cliente cliente = administradorCliente.BuscarCliente(email);

            if (cliente != null && cliente.Contraseña == contraseña)
            {
                clienteActual = cliente;
                Console.WriteLine($"¡Bienvenido, {cliente.ClienteNombre}!");
                sesionIniciada = true;
                ActualizarOpciones();
            }

            Continuar();
        }

        public void Registro() // Permite al usuario registrarse proporcionando nombre, correo electrónico y contraseña.

        {
            Console.Write("Nombre del cliente: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Correo electrónico: ");
            string email = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contraseña = Console.ReadLine();

            administradorCliente.Registro(nombreCliente, email, contraseña); // Llama al método en el administrador de clientes para crear un nuevo cliente con esos datos
            Console.WriteLine("\nEl cliente ha sido registrado.");

            IniciarSesion(email, contraseña);
        }

        public void MostrarCatalogo() // Muestra el catálogo de productos disponibles en el inventario.
        {
            Console.WriteLine("Inventario disponible: \n");
            var productos = carrito.ObtenerCatalogo();

            // Busca los productos en el catálogos y los imprime a través de la llamada de otros métodos
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.InfoProducto());
            }
            Continuar();
        }

        public void AgregarProducto() // Permite al usuario agregar un producto al carrito.
        {
            Console.Write("Nombre del producto: ");
            string nombreProducto = Console.ReadLine();

            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            short status = carrito.AgregarProducto(nombreProducto, cantidad, clienteActual);

            //Los if determinarán el mensaje que se mostrará al usuario de acuerdo al resultado de la invocación del método
            if (status == 1)
            {
                Console.WriteLine("¡Producto agregado al carrito!");
            }
            else if (status == 2)
            {
                Console.WriteLine("Stock insuficiente.");
            }
            else if (status == 3)
            {
                Console.WriteLine("Producto no encontrado.");
            }

            Continuar();
        }

        public void VerCarrito() // Muestra los productos que están en el carrito del cliente actual.
        {
            if (clienteActual.Productos.Count > 0)
            {
                Console.WriteLine("Productos en el carrito:");
                foreach (var producto in clienteActual.Productos)
                {
                    Console.WriteLine(producto.InfoProductoCarrito());
                }
            }
            else
            {
                Console.WriteLine("El carrito está vacío.");
            }
            Continuar();
        }

        public void VerTotal() // Muestra el costo total de los productos en el carrito del cliente actual.
        {
            double total = carrito.CalcularTotal(clienteActual);
            Console.WriteLine($"El costo total del carrito es: ${total}");
            Continuar();
        }

        public void Continuar() // Pausa la ejecución y espera a que el usuario presione una tecla para continuar.
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}

