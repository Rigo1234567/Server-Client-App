using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.modelos
{
    public class reserva
    {
        public int idreserva { get; set; }
        public sede sede { get; set; }
        public cliente cliente { get; set; }
        public DateTime fecha { get; set; }

        public reserva()
        {
            idreserva = -1;
            sede = new sede();
            cliente = new cliente();
            fecha = DateTime.MinValue;

        }

        public override String ToString()
        {
            return

                 "id reserva:" + idreserva + "   " + "fecha " + fecha + "   " + "sede " + sede.Idsede + "   " + "cliente " + cliente.Id;


        }

    }
}
