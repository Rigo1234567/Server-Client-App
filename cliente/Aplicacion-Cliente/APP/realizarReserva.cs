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
    public partial class realizarReserva : Form
    {

      

        public static cliente vendAutenticad1 = null;
        public realizarReserva()
        {
            InitializeComponent();

            string NombreVend = vendAutenticad1.nombre.ToString() + " " + vendAutenticad1.primer_apellido.ToString() + " " + vendAutenticad1.segundo_apellido.ToString();
          
            try
            {
                List<cscuposxsede> listaArticulos = new List<cscuposxsede>();
                listaArticulos = ConexionTCP.ObtenerCupos(vendAutenticad1.Id);

                foreach (var item in listaArticulos.Where(x => x != null))
                {
                    Convert.ToDateTime(item.fecha.Date.ToString("dd-MM-yyyy"));
                }




                CB_Art.DataSource = listaArticulos;
                CB_Art.ValueMember = "sede";
                CB_Art.DisplayMember = "FullName";


            


            }
            catch (Exception)
            {
                MessageBox.Show("No se pudieron cargar los artículos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


      



        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void realizarReserva_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Nota: las Sedes que aparecen para su elección, son las sedes donde existen cupos disponibles y usted ha sido previamente asignado a la sede");





            List<reserva> listaOrdenes = new List<reserva>();
            //DG_COrdenes.DataSource = C_Datos.ObtenerOrdenes();






            try
            {
                List<reserva> listaOC = new List<reserva>();
                listaOC = ConexionTCP.ObtenerVentasVendedores(vendAutenticad1.Id);

                dgvreser.DataSource = ConexionTCP.ObtenerVentasVendedores(vendAutenticad1.Id);



            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un eror al realizar la acción solicitada, revise que el estado del servidor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("debe digitar valores numéricos para el campo ID reserva");

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("error ese Id de reserva ya existe en la base de datos");

            //}
        

        private void btnreserva_Click(object sender, EventArgs e)
        {



            

            //sede sede = (sede)CB_Art.SelectedValue;
            //if (dgvreser.RowCount > 0)
            //{
            //    // Primero averigua si el registro existe:
            //    bool existe = false;
            //    for (int i = 0; i < dgvreser.RowCount; i++)
            //    {
            //        if ((dgvreser.Rows[i].Cells["sede"].Value.ToString()) == (sede.ToString()))
            //        {
            //            MessageBox.Show("usted ya tiene esa id reservada");
            //            existe = true;
            //            return; // debes salirte del ciclo si encuentras el registro, no es necesario seguir dentro
            //        }
            //    }
            //}



                //reserva NuevaOrden = new reserva();

                //cliente NuevoVendedor = vendAutenticad1;
                //NuevaOrden.cliente = NuevoVendedor;
                //NuevaOrden.sede = (sede)CB_Art.SelectedValue;
                //NuevaOrden.idreserva = int.Parse(txtide.Text);
                //DateTime actual = DateTime.Now;
                //NuevaOrden.fecha = actual;




                //int idO = Convert.ToInt32(txtide.Text);

                //ConexionTCP.AgregarOrden(idO, NuevaOrden);
                //MessageBox.Show("sede reservada");

                //ConexionTCP.AgregarDetalle((cscuposxsede)CB_Art.SelectedItem);
                //MessageBox.Show("se han disminuido los cupos para esa sede");

                //this.Close();





            
        }

        private void btnreserva_Click_1(object sender, EventArgs e)
        {


            //try
            //{
                bool existe = false;
               



                sede sede = (sede)CB_Art.SelectedValue;

            string nuevo1 = CB_Art.Text;

            string [] nuevo = nuevo1.Split(',');
              DateTime actual = DateTime.ParseExact(nuevo[0].ToString(), "dd/MM/yyyy H:mm:ss", null);

           DateTime fecha = Convert.ToDateTime(actual.Date.ToString("dd-MM-yyyy"));
          


            if (dgvreser.RowCount > 0)
            {
                // Primero averigua si el registro existe:

                for (int i = 0; i < dgvreser.RowCount; i++)
                {
                    if ((dgvreser.Rows[i].Cells["fecha"].Value.ToString()) == (actual.ToString()))
                    {
                        MessageBox.Show("usted ya tiene esa fecha reservada, no puede tener dos reservas de fechas al mismo tiempo");
                        existe = true;
                        return; // debes salirte del ciclo si encuentras el registro, no es necesario seguir dentro
                    }
                }
            }

            Random idreserva = new Random();
            int randomNumber = idreserva.Next(0, 10001);


            reserva NuevaOrden = new reserva();

                cliente NuevoVendedor = vendAutenticad1;
                NuevaOrden.cliente = NuevoVendedor;
                NuevaOrden.sede = (sede)CB_Art.SelectedValue;
            NuevaOrden.idreserva = randomNumber;
           
                NuevaOrden.fecha = fecha;



 
             

                ConexionTCP.AgregarOrden(randomNumber, NuevaOrden);
                MessageBox.Show("sede reservada");

                ConexionTCP.AgregarDetalle((cscuposxsede)CB_Art.SelectedItem);
                MessageBox.Show("se han disminuido los cupos para esa sede");

                this.Close();
            
            //catch (Exception)
            //{

            //    MessageBox.Show("no puede poner letras en campos numéricos");
            //}
           



        }

        private void CB_Art_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


