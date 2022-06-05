using entities.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static business.controladores.controladorclientesede;
using static business.controladores.controladorafiliacion;
using business.controladores;
using servidor_datos;

namespace app
{
    public partial class mostrarafiliaciones : Form
    {
        Cone C_Datos = new Cone();
        public mostrarafiliaciones()
        {
            InitializeComponent();
        }

        private void cargarasignaciones()
        {
            dgvasignaciones.Rows.Clear();

            foreach (afiliacionSede item in listarsedesafiliaciones().Where(x => x != null))
            {

                foreach (var item2 in listarafisedes().Where(x => x != null))
                {

                    object[] row = new object[]
               {
                    item.id_afiliacion,
                    item.fecha_afiliacion,
                    item.cliente.Id,
                    item.cliente.nombrecompleto,
                    item2.sede.Idsede,
                    item2.sede.nombre_sede,
                    item2.sede.estado,
               };

                   // dgvasignaciones.Rows.Add(row);
                }






            }


        }

        private void btnver_Click(object sender, EventArgs e)
        {
           // cargarasignaciones();
        }

        private void btnsalr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mostrarafiliaciones_Load(object sender, EventArgs e)
        {
            C_Datos.llenargridafiliacion(dgvasignaciones);

            
        }
    }
}
