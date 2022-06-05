using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static business.controladores.controladorcupos;
using entities.modelos;
using business.controladores;
using servidor_datos;

namespace app.forms
{
    public partial class mostrarcupos : Form
    {
        Cone C_Datos = new Cone();
        public mostrarcupos()
        {
            InitializeComponent();
        }

        private void cargarcupos()
        {

            List<cscuposxsede> listaOrdenes = new List<cscuposxsede>();

            listaOrdenes = C_Datos.ObtenerCuposSede();

            dgvcupos.Rows.Clear();
            foreach (var item in listaOrdenes.Where(x => x != null))
            {

                object[] nuevo = new object[]
                {
                    item.sede,
                    item.fecha,
                    item.cupos

                };
                dgvcupos.Rows.Add(nuevo);
            }
        }

        private void mostrarcupos_Load(object sender, EventArgs e)
        {
            //List<cscuposxsede> listaOrdenes = new List<cscuposxsede>();

            // listaOrdenes = C_Datos.ObtenerCuposSede();
            cargarcupos();

            
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
