using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities.modelos;

namespace entities.modelos
{
    public class afiliacionSede
    {
        public int id_afiliacion { get; set; }
        public DateTime fecha_afiliacion { get; set; }
        public cliente cliente { get; set; }
      public sede sede { get; set; }


        

        public afiliacionSede()
        {
            id_afiliacion = -1;
            fecha_afiliacion = DateTime.MinValue;
            cliente = new cliente();
            sede = new sede();          
        }


        
        public override string ToString()
        {
            return
                $" Id de afiliacion: {id_afiliacion}  Fecha: {fecha_afiliacion}   cliente: {cliente.Id} nombre: {cliente.nombre}  primer apellido:  {cliente.primer_apellido}  segundo apellido: {cliente.segundo_apellido}  ";

        }
    }

    


}
