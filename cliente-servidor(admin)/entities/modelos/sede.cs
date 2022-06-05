using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.modelos
{
   public class sede
    {
        public int Idsede { get; set; }
        public string nombre_sede { get; set; }
        public string direccion_sede { get; set; }
        public bool estado { get; set; }
        public string telefono { get; set; }

        public sede(int idsede)
        {
            Idsede = idsede;
        }

        public sede()
        {
            Idsede = -1;
            nombre_sede = string.Empty;
            direccion_sede = string.Empty;
            estado = true;
            telefono = string.Empty;
        }

        public override String ToString()
        {
            return ""+ Idsede ;
        }

     

    }
}
