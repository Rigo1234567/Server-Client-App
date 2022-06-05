using entities.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static dataaccess.servicios.clienteservice;

namespace business.controladores
{
    public static class controladorcliente
    {

        public static bool Existecliente(string id)
        {
            foreach (var item in clientes)
            {
                if (item != null)
                {
                    PropertyInfo lector = item.GetType().GetProperty("Id");
                    if (lector.GetValue(item).Equals(id))
                    {
                        return true;
                    }

                }

            }
            return false;
        }


        public static bool lleno()
        {
            return Array.IndexOf(clientes,null) == -1;
                           
            
        }


        public static cliente BuscarIdcliente( string id) // Este método busca en clientes y si existe devuelve el objeto con la información
        {
            cliente Estecliente = new cliente();

            for (int i = 0; i < clientes.Length; i++)
            {
                if (clientes[i] != null)
                {
                    if (clientes[i].Id.Equals(id))
                    {
                        Estecliente = clientes[i];
                    }
                }
                else
                {
                    i = clientes.Length;
                }
            }
            return Estecliente;
        }

        public static bool Existe(string id)
        {
            return clientes.Any(x => x.Id.Equals(id));
        }

        public static void agregar(cliente nuevo)
        {
            clientes[Array.IndexOf(clientes, null)] = nuevo;
        }


        public static cliente[] listarclientes()
        {
            clientes.OfType<cliente>();
            
            return clientes;



        }




    }
}
