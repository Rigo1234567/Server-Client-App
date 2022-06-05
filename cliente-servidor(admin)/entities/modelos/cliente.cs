using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.modelos
{
   public class cliente
    {

       

            public String Id { get; set; }
            public String nombre { get; set; }
            public String primer_apellido { get; set; }
            public String segundo_apellido { get; set; }
            public DateTime fecha_nacimiento { get; set; }
            public char genero { get; set; }       
            public DateTime fecha_ingreso { get; set; }
            public string nombrecompleto { get => nombre + "" + primer_apellido + " " + segundo_apellido; }

        public cliente()
            {
                this.Id = string.Empty;
                this.nombre = string.Empty;
                this.primer_apellido = string.Empty;
                this.segundo_apellido = string.Empty;
                this.fecha_nacimiento = DateTime.MinValue;
                this.genero = '\0';

                this.fecha_ingreso = DateTime.MinValue;
            }





        public override String ToString()
        {
            return

                " " + Id  ;


        }
    }
}
