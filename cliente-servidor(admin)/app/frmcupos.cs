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
using static business.controladores.controladorsede;
using static business.controladores.controladorcupos;
using business.controladores;
using servidor_datos;

namespace app
{
    public partial class frmcupos : Form
    {
       Cone C_Datos = new Cone();
        public frmcupos()
        {
            InitializeComponent();
            acciones_formulario.CargarSedes(cmbsede);
        }




        ////private void cargar()
        //{
        //    cmbsede.ValueMember = "Idsede";
        //    cmbsede.DisplayMember = "nombre_sede";
        //    cmbsede.DataSource = listarsedes();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {

            try
            {
                sede sede = new sede();

            int idDigitada = int.Parse(cmbsede.SelectedItem.ToString());
            DateTime fecha1 = dtpfecha.Value; 
                DateTime fecha2 = C_Datos.Buscarfecha("CupoSede", "FechaCupo", fecha1, 0);


            int IdExiste = C_Datos.BuscarId("CupoSede", "IdSede", idDigitada, 0);

            if (IdExiste == idDigitada && fecha1 == fecha2)
            {

                MessageBox.Show("a esa sede ya le fueron agregados cupos en esa fecha");
                return;
            }

            if (cmbsede.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar una sede");
                return;
            }
            string[] valores1 = acciones_formulario.Buscarsede(int.Parse(cmbsede.Text));
            sede.Idsede = int.Parse(valores1[0]);
            sede.nombre_sede = valores1[1];
            sede.direccion_sede = valores1[2];
            sede.estado = Convert.ToBoolean(valores1[3]);
            sede.telefono = valores1[4];

            DateTime fecha;
                
            fecha =dtpfecha.Value;


                DateTime fecha3 = Convert.ToDateTime(fecha.Date.ToString("dd-MM-yyyy"));
            int cupos = int.Parse(txtcupos.Text);

            cscuposxsede nuevo = new cscuposxsede(sede, fecha3, cupos);


            C_Datos.Agregarcupos(nuevo);
            MessageBox.Show("cupos agregados a la sede");
        }
            catch ( System.Data.SqlClient.SqlException )
            {

               MessageBox.Show("a esa sede ya le fueron agregados cupos en esa fecha"); ;
            }

            catch (FormatException)
            {

                MessageBox.Show("debe digitar valores numericos para el campo cupos"); ;
            }

        }

        private void frmcupos_Load(object sender, EventArgs e)
        {
         
        }
    }
}
