using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities.modelos;
using static dataaccess.servicios.afiliacionservice;
using static dataaccess.servicios.clientesede;
using static business.controladores.controladorclientesede;
using static business.controladores.controladorclientesede;
namespace business.controladores
{
   public static class controladorafiliacion
    {

        public static void agregarafisede(afiliacionSede nuevo)
        {
           clientesafi[Array.IndexOf(clientesafi, null)] = nuevo;
        }



        public static bool BuscarIdaux(sede sede, cliente cliente)
        {

            afiliacionSede este = new afiliacionSede();

            foreach (var item in listarsedesafiliaciones().Where(x => x != null))
            {
                foreach (var item2 in item.afi.Where(x => x != null))
                {
                    if ((item.cliente.Id.Equals(cliente.Id)) && (item2.sede.Idsede.Equals(sede.Idsede)))
                    {

                        return true;

                    }




                }

            }


            return false;

        }

        public static afiliacionSede BuscarId(string id) // Este método busca en clientes y si existe devuelve el objeto con la información
        {
            afiliacionSede Estecliente = new afiliacionSede();

            for (int i = 0; i < clientesafi.Length; i++)
            {
                foreach ( var item in listarafisedes().Where(x => x != null))
                {
                    if (clientesafi[i] != null)
                    {
                        if (clientesafi[i].Equals(id))
                        {
                            Estecliente = clientesafi[i];
                        }
                    }
                    else
                    {
                        i = clientesafi.Length;
                    }
                }

               
            }
            return Estecliente;
        }


        public static bool llenoafi()
        {
            return Array.IndexOf(clientesafi, null) == -1;


        }


        public static afiliacionSede[] listarsedesafiliaciones()
        {
            clientesafi.OfType<afiliacionSede>();
            return clientesafi ;
        }

    }
}
