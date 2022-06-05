using business.controladores;
using entities.modelos;
using servidor_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static business.controladores.controladorcliente;
namespace app
{
    public partial class frmcliente : Form
    {
        Cone Datos = new Cone();
        public frmcliente()
        {
            InitializeComponent();
        }

      

        private void btningresar_Click(object sender, EventArgs e)
        {
            if(txtide.Text.Length==0 || txtnombre.Text.Length == 0 || txtprimerapellido.Text.Length == 0 || txtsegundoapellido.Text.Length == 0)
            {
                MessageBox.Show("no puede dejar campos vacíos ");
                return;
            }
            string idDigitada = txtide.Text;

            string IdExiste = Datos.BuscarIdcliente("cliente", "Idcliente", idDigitada, 0);

            if (IdExiste == idDigitada)
            {

                MessageBox.Show("ese ID ya existe en la base de datos ");
                return;
            }

            if (!rbtmasculino.Checked && !rbtfemenino.Checked)
            {
                MessageBox.Show("debe digitar el genero");
                return;
            }

            char checkeado;
            

            cliente NuevoVendedor = new cliente();

            NuevoVendedor.Id = idDigitada;
            NuevoVendedor.nombre = txtnombre.Text;
            NuevoVendedor.primer_apellido = txtprimerapellido.Text;
            NuevoVendedor.segundo_apellido = txtsegundoapellido.Text;
            NuevoVendedor.fecha_nacimiento = dtpnacimiento.Value;
            if (rbtmasculino.Checked)
            {
                checkeado = 'M';
            }
            else
            {
                checkeado = 'F';
            }
            NuevoVendedor.genero = checkeado;
            NuevoVendedor.fecha_ingreso= dtpingreso.Value;

            Datos.Agregarcliente(NuevoVendedor);
            //agregar(nuevo);
            MessageBox.Show("cliente ingresado");
            
        }

      

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmcliente_Load(object sender, EventArgs e)
        {

        }
    }
}
