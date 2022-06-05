using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.funciones
{
    public class functions
    {

        public static bool entero(string text)
        {
            try
            {
                int.Parse(text);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


    }
}
