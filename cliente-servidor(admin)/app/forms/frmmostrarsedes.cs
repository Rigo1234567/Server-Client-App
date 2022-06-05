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
using static business.controladores.controladorsede;
namespace app.forms
{
    public partial class frmmostrarsedes : Form
    {

        Cone C_Datos = new Cone();
        public frmmostrarsedes()
        {
            InitializeComponent();
            
        }

        private void cargar()
        {
            dgvsedes.DataSource = null;
            dgvsedes.Rows.Clear();
            string estado;
            foreach (var item in listarsedes().Where(x => x != null))
            {
                if (item.estado == true)
                {
                    estado = "activa";
                }
                else
                {
                    estado = "inactiva";
                }




                dgvsedes.Rows.Add(item.Idsede, item.nombre_sede, item.direccion_sede, estado, item.telefono);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmmostrarsedes_Load(object sender, EventArgs e)
        {
            List<sede> listaArticulos = new List<sede>();
            dgvsedes.DataSource = C_Datos.ObtenerSedes();
          
        }
    }
}
