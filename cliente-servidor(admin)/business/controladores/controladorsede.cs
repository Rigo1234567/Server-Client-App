using entities.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dataaccess.servicios.sedeService;

namespace business.controladores
{
   public static class controladorsede

    {
        public static bool Existe( int id)
        {
            foreach (var item in Sedes)
            {
                if (item != null)
                {
                    PropertyInfo lector = item.GetType().GetProperty("Idsede");
                    if ((int)lector.GetValue(item) == id)
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        

        public static sede BuscarId( int id) // Este método busca en clientes y si existe devuelve el objeto con la información
        {
            sede Estecliente = new sede();

            for (int i = 0; i < Sedes.Length; i++)
            {
                if (Sedes[i] != null)
                {
                    if (Sedes[i].Idsede.Equals(id))
                    {
                        Estecliente = Sedes[i];
                    }
                }
                else
                {
                    i = Sedes.Length;
                }
            }
            return Estecliente;
        }

        public static bool llenosede()
        {
            return Array.IndexOf(Sedes, null) == -1;


        }

        public static bool BuscarIdactivo( sede sede) // Este método busca en Arreglosedes si el id indicado existe
        {
            bool IdentExiste = false;

            for (int i = 0; i < Sedes.Length; i++)
            {
                if (Sedes[i] != null)
                {
                    if (Sedes[i].Idsede.Equals(sede.Idsede))
                    {
                        if (Sedes[i].estado == true)
                        {
                            IdentExiste = true;
                        }
                    }
                }
                else
                {
                    i = Sedes.Length;
                }
            }
            return IdentExiste;
        }


        public static void agregar( sede nuevo)
        {
             Sedes[Array.IndexOf(Sedes, null)] = nuevo;
        }

        public static sede[] listarsedes()
        {
            Sedes.OfType<sede>();
            return Sedes;
        }
    }
}
