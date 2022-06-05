using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.modelos
{
    /// <summary>
    /// Clase utilizada para enviar mensajes entre el cliente y el servidor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MensajeSocket<T>
    {
        public string Metodo { get; set; }

        public T Entidad { get; set; }
    }
}
