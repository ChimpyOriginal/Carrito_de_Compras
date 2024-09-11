using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito_de_Compras
{
    internal class Opcion
    {
        private string message; // Mensaje para describir la opción
        private Action action; // Acción que se ejecutará cuando se selecciona esta opción

        public Opcion(string message, Action action) // Constructor que inicializa el mensaje y la acción de la opción
        {
            this.message = message;
            this.action = action;
        }
        //Setters y getters
        public string Message { get { return message; } } // Propiedad para obtener el mensaje de la opción
        public Action Action { get { return action; } }  // Propiedad para obtener la acción asociada con la opción
    }
}
