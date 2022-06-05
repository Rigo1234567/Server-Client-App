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
    public partial class Form1 : Form
    {
        cliente vend = null;
        string idVend = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void B_Conectar_Click(object sender, EventArgs e)
        {
            idVend = MTB_IdVend.Text;
            if (!idVend.Equals(string.Empty))
            {
                if (ConexionTCP.Conectar(idVend))
                {
                    List<cliente> vendE = ConexionTCP.ObtenerVendedor(idVend);

                    if (vendE.Count > 0)
                    {
                        vend = vendE.First();

                        Form2.vendAutenticado = vend;
                        using (Form2 fVent = new Form2())
                            fVent.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("cliente no encontrado", "No es posible conectarse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MTB_IdVend.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Verifique la conexión con el servidor", "No es posible conectarse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar el identificador del cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void L_TAccion_Click(object sender, EventArgs e)
        {

        }

        private void MTB_IdVend_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
