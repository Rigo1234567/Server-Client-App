using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dataaccess.servicios.clientesede;
using entities.modelos;
namespace business.controladores

{
    public static class controladorclientesede
    {
        public static void agregarsede(afiliacionclientesede nuevo)
        {
            afisede[Array.IndexOf(afisede, null)] = nuevo;


        }


        public static bool llenoclientesede()
        {
            return Array.IndexOf(afisede, null) == -1;


        }
        public static afiliacionclientesede BuscarIdafi(int id) // Este método busca en clientes y si existe devuelve el objeto con la información
        {
            afiliacionclientesede Estecliente = new afiliacionclientesede();

            for (int i = 0; i < afisede.Length; i++)
            {
                if (afisede[i] != null)
                {
                    if (afisede[i].sede.Idsede.Equals(id))
                    {
                        Estecliente = afisede[i];
                        
                    }
                }
                else
                {
                    i = afisede.Length;
                }
            }
            return Estecliente;
        }
        public static afiliacionclientesede[] listarafisedes()
        {
            afisede.OfType<afiliacionclientesede>();
            return afisede;
        }
    }
}
