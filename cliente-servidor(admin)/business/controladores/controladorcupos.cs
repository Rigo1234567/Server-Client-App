using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities.modelos;
using static dataaccess.servicios.cuposservice;
namespace business.controladores
{
    public class controladorcupos
    {


        public static cscuposxsede[] listarcupos()
        {
            cuposxsedes.OfType<cscuposxsede>();
            return cuposxsedes;
        }

        public static void agregar(cscuposxsede nuevo)
        {
            cuposxsedes[Array.IndexOf(cuposxsedes, null)] = nuevo;
        }
    }
}
