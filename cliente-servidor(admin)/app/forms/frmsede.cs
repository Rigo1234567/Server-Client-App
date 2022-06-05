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
using static business.funciones.functions;
using business;
using business.controladores;
using servidor_datos;

namespace app.forms
{
    public partial class frmsede : Form
    {
        Cone C_Datos = new Cone();
        public frmsede()
        {
            InitializeComponent();
        }


       

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            try
            {
                sede NuevoVendedor = new sede();

                bool checkeado;
                int idDigitada = int.Parse(txtide.Text);


                int IdExiste = C_Datos.BuscarId("Sede", "IdSede", idDigitada, 0);
                if (IdExiste == idDigitada)
                {
                    MessageBox.Show("Ese Id ya existe en la base de datos");
                    return;
                }


                if (txtide.Text.Length == 0 || txtnombre.Text.Length == 0 || txttelefono.Text.Length == 0 || txtdireccion.Text.Length == 0)
                {
                    MessageBox.Show("no puede dejar espacios en blanco");
                    return;

                }

                if (cmbestado.SelectedIndex == -1)
                {
                    MessageBox.Show("debe marcar si la sede está activa o inactiva");
                    return;

                }

                NuevoVendedor.Idsede = int.Parse(txtide.Text);
                NuevoVendedor.nombre_sede = txtnombre.Text;

                NuevoVendedor.direccion_sede = txtdireccion.Text;
                if (cmbestado.SelectedIndex == 0)
                {
                    checkeado = true;
                }
                else
                {
                    checkeado = false;
                }


                NuevoVendedor.estado = checkeado;

                NuevoVendedor.telefono = txttelefono.Text;



                //Se agrega el objeto
                // Program.A_Vendedores[0] = NuevoVendedor;

                //Se envía a Base de Datos
                
                C_Datos.Agregarsede(NuevoVendedor);
                MessageBox.Show("Sede agregada");
            }
            catch (Exception)
            {
                MessageBox.Show("debe digitar valores numéricos para el campo ID");

            }

            
            



        }

        private void rbtactiva_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtinactiva_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvsedes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtide_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmsede_Load(object sender, EventArgs e)
        {

        }
    }
    }


