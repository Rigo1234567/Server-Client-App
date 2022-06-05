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
namespace app.forms
{
    public partial class frmmostrarclientes : Form
    {
        Cone Datos = new Cone();
        public frmmostrarclientes()
        {
            
            InitializeComponent();
           
        }


        private void cargar()
        {
            dgvclientes.DataSource = null;
            dgvclientes.DataSource = listarclientes();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmmostrarclientes_Load(object sender, EventArgs e)
        {
            List<cliente> listaArticulos = new List<cliente>();
            dgvclientes.DataSource = Datos.ObtenerClientes();
        }
    }
}
