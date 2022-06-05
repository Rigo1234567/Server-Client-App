using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.modelos
{
    public class cscuposxsede
    {
        public sede sede { get; set; }
        public DateTime fecha { get; set; }
        public int cupos { get; set; }

        public string FullName{
            get{ return  fecha + "," + "sede:" + sede.Idsede + "," + "Cupos:" + cupos; }
        }

        public cscuposxsede()
        {
            sede = new sede();
            fecha = DateTime.MinValue;
            cupos = -1;
            
        }

        public cscuposxsede(sede sede, DateTime fecha, int cupos)
        {
            this.sede = sede ?? throw new ArgumentNullException(nameof(sede));
            this.fecha = fecha;
            this.cupos = cupos;
        }

        public override String ToString()
        {
            return

                 "nombre:" + sede.nombre_sede + "   " + "fecha " + fecha + "   " + "cupos " +  cupos ;


        }
    }
}
