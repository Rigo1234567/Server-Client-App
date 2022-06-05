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

namespace APP
{
    public partial class Form2 : Form
    {
        public static cliente vendAutenticado = null;
        public Form2()
        {
            InitializeComponent();
            string NombreVend = vendAutenticado.nombre.ToString() + " " + vendAutenticado.primer_apellido.ToString() + " " + vendAutenticado.segundo_apellido.ToString();
            L_NombreVendedor.Text = NombreVend;

            // L_User.Text = NombreVend;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizarReserva.vendAutenticad1 = vendAutenticado;
            using (realizarReserva fRVent = new realizarReserva())
                fRVent.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ConsultarReservas.vendAutenticado = vendAutenticado;
            using (ConsultarReservas fCVent = new ConsultarReservas())
                fCVent.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConexionTCP.Desconectar(vendAutenticado.Id);
            btnconsultar.Enabled = false;
            btnrealizarreserva.Enabled = false;
            this.Close();
        }
    }
}
