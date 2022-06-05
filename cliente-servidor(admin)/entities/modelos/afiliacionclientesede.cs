using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.modelos
{
    public class afiliacionclientesede
    {
        public sede sede { get; set; }

        public afiliacionclientesede(sede sedes)
        {
            sede = new sede();
        }

        public afiliacionclientesede()
        {
            sede = new sede();
        }

        public override string ToString()
        {
            return $" id: {sede.Idsede} nombre de la sede: {sede.nombre_sede}  estado: {sede.estado}";
        }
    }
}
