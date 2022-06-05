using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entities.modelos;
namespace APP
{
    public partial class ConsultarReservas : Form
    {
        public static cliente vendAutenticado = null;
        public ConsultarReservas()
        {
            
        InitializeComponent();

        }

        private void ConsultarReservas_Load(object sender, EventArgs e)
        {
            List<reserva> listaOrdenes = new List<reserva>();
            //DG_COrdenes.DataSource = C_Datos.ObtenerOrdenes();

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvreservas.Columns.Add(btn);
            
            

            try
            {
                List<reserva> listaOC = new List<reserva>();
                listaOC = ConexionTCP.ObtenerVentasVendedores(vendAutenticado.Id);

               dgvreservas.DataSource = ConexionTCP.ObtenerVentasVendedores(vendAutenticado.Id);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un eror al realizar la acción solicitada, revise que el estado del servidor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

