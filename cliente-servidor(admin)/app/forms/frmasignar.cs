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
using static business.controladores.controladorsede;
using static business.controladores.controladorclientesede;
using static business.controladores.controladorafiliacion;
using entities.modelos;
using System.Reflection;
using business.controladores;
using servidor_datos;

namespace app.forms
{
    public partial class frmasignar : Form
    {
         
        Cone c = new Cone();

        private sede[] aux = new sede[20];
        public frmasignar()
        {
            InitializeComponent();
            acciones_formulario.CargarComboBox(cmbclientes);
            acciones_formulario.CargarSedes(cmbsede);
        }



        private void vaciar()
        {
            for (int i = 0; i < aux.Length; i++)
            {
                if (aux[i] != null)
                {
                    aux[i] = null;
                }
                
            }
        }
       

        private bool llenoaux()
        {
            return Array.IndexOf(aux, null) == -1;
            
        }

        //private bool vacioaux()
        //{
        //    bool busca;

        //    if (dgvsedesaux.Rows.Count > 1)
        //    {
        //        busca = true;
        //    }
        //    else
        //    {
        //        busca = false;

        //    }



        //    return busca;

        //}







        private void cargar()
        {
            //dgvcliente.DataSource = null;
            //dgvcliente.DataSource = listarclientes();

            //dgvsede.DataSource = null;
            /// dgvsede.DataSource = listarsedes();
            /// 




            //dgvasignaciones.DataSource = null;
            // dgvasignaciones.DataSource = listarsedesafiliaciones();


            cmbclientes.ValueMember = "Id";
            cmbclientes.DisplayMember = "nombre";
            cmbclientes.DataSource = listarclientes();

            cmbsede.ValueMember = "Idsede";
            cmbsede.DisplayMember = "nombre_sede";
            cmbsede.DataSource = listarsedes();



        }

        private bool buscarenaux(sede sede)
        {
            bool buscar = false;
            foreach (var item in aux.Where(x => x != null))
            {
                if (item.Idsede.Equals(sede.Idsede))
                {
                    return true;

                };
            }
            return false;
        }

        //private void cargaraux()
        //{

        //    dgvsedesaux.Rows.Clear();

        //    foreach (var item in aux.Where(x => x != null))
        //    {


        //        object[] row = new object[]
        //        {
        //            item.Idsede,
        //            item.nombre_sede,
        //            item.estado
        //        };

        //        dgvsedesaux.Rows.Add(row);
        //    }



        //}

        private void frmasignar_Load(object sender, EventArgs e)
        {
            //cargar();



        }

        private void btnseleccionar_Click(object sender, EventArgs e)
        {


            //cliente cliente = BuscarId(txtcliente.Text);
            if (llenoafi())
            {
                MessageBox.Show("ya no hay mas campos disponibles");
                return;
            }

      





            Random r = new Random();
            int id_afi = r.Next(1, 101);
            DateTime fecha = DateTime.Now;
            //cliente clientes = BuscarId(txtcliente.Text);





            afiliacionSede nuevo = new afiliacionSede();
            nuevo.id_afiliacion = id_afi;
            nuevo.fecha_afiliacion = fecha;
            nuevo.cliente = (cliente)cmbclientes.SelectedItem;

            // idclienteelegido = BuscarId(txtcliente.Text);
            //  nuevo.cliente = idclienteelegido;

            afiliacionclientesede nuevoaf = new afiliacionclientesede();


            if (llenoclientesede())
            {

                MessageBox.Show("ya no hay mas campo disponible");
                return;
            }

            sede id = (sede)cmbsede.SelectedItem;
            cliente ide = (cliente)cmbclientes.SelectedItem;

            if (BuscarIdaux(id, ide) == true)
            {
                MessageBox.Show("esa sede ya fue agregada");
                return;
            }



            // sede sedes = (BuscarId(id));
            // nuevo.sede= (BuscarId(id));
            // nuevoaf.sede = sedes;

            // agregarsede(nuevoaf);
            ////  nuevo.sede = sedes;
            //if (vacioaux() == false)
            //{
            //    MessageBox.Show("primero debe agregar sedes");
            //    return;
            //}


            foreach (var item in aux.Where(x => x != null))
            {
                nuevoaf.sede.Idsede = item.Idsede;
                nuevoaf.sede.nombre_sede = item.nombre_sede;
                nuevoaf.sede.direccion_sede = item.direccion_sede;
                nuevoaf.sede.estado = item.estado;
                nuevoaf.sede.telefono = item.telefono;

            }

            agregarsede(nuevoaf);



            if (cmbclientes.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar un cliente");
                return;
            }


            if (cmbsede.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar una sede");
                return;
            }











          //  nuevo.afi = listarafisedes();
            agregarafisede(nuevo);
            //cargar();
            MessageBox.Show("sede agregada");


            //dgvsedesaux.Rows.Clear();

            vaciar();
















        }



        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void btnagregar_Click(object sender, EventArgs e)
        {
            //if (cmbclientes.SelectedIndex == -1)
            //{
            //    MessageBox.Show("debe seleccionar un cliente");
            //    return;
            //}


            //if (cmbsede.SelectedIndex == -1)
            //{
            //    MessageBox.Show("debe seleccionar una sede");
            //    return;
            //}

            //if (buscarenaux((sede)cmbsede.SelectedItem) == true)
            //{
            //    MessageBox.Show("esa sede ya esta agregada");
            //    return;
            //}

            //if (llenoaux() == true)
            //{
            //    MessageBox.Show("ya no hay mas campo");
            //    return;
            //}

            //if (BuscarIdaux(((sede)cmbsede.SelectedItem), (cliente)cmbclientes.SelectedItem) == true)
            //{
            //    MessageBox.Show("esa sede ya fue agregada");
            //    return;
            //}

            //if (!BuscarIdactivo((sede)cmbsede.SelectedItem))
            //{
            //    MessageBox.Show("esa sede no está activa");
            //    return;
            //}


            //aux[Array.IndexOf(aux, null)] = (sede)cmbsede.SelectedItem;


            //cargaraux();
        }

        private void dgvasignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbsede_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvcliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            try
            {
               
               
                if(c.Obtenerafiliaciones(cmbclientes.SelectedItem.ToString(), int.Parse(cmbsede.SelectedItem.ToString())) == true)
                {

                    MessageBox.Show("ese cliente ya contiene una afilaicion con esa sede");
                    return;
                }
                
                
                afiliacionSede nuevaAfiliacion = new afiliacionSede();
                afiliacionclientesede nuevaAfiliciacionDetalle = new afiliacionclientesede();
                int posibleId = int.Parse(txtidafiliacion.Text);
                

                int ExistArt = c.BuscarId("AfiliacionSede", "IdAfiliacion", posibleId, 0);

                if (txtidafiliacion.Text.Length == 0)
                {
                    MessageBox.Show("no puede dejar campos vacíos");
                    return;
                }

                if (ExistArt == posibleId)
                {
                    MessageBox.Show("El Id de afiliación digitado ya está registrado!");
                    return;
                }



                if (cmbclientes.SelectedIndex > 0)
                {
                    cliente cliente = new cliente();
                    string[] valores = acciones_formulario.Buscarclientes(cmbclientes.Text);

                    cliente.Id = valores[0];
                    cliente.nombre = valores[1];
                    cliente.primer_apellido = valores[2];
                    cliente.segundo_apellido = valores[3];
                    cliente.fecha_nacimiento = Convert.ToDateTime(valores[4]);
                    cliente.genero = Convert.ToChar(valores[5]);
                    cliente.fecha_ingreso = Convert.ToDateTime(valores[6]);

                    nuevaAfiliacion.id_afiliacion = int.Parse(txtidafiliacion.Text);
                    nuevaAfiliacion.cliente = cliente;
                    nuevaAfiliacion.fecha_afiliacion = dtp1.Value;

                    sede sede = new sede();
                    string[] valores1 = acciones_formulario.Buscarsede(int.Parse(cmbsede.Text));
                    sede.Idsede = int.Parse(valores1[0]);
                    sede.nombre_sede = valores1[1];
                    sede.direccion_sede = valores1[2];
                    sede.estado = Convert.ToBoolean(valores1[3]);
                    sede.telefono = valores1[4];


                    c.AgregarOrdenCompraBD(nuevaAfiliacion.id_afiliacion, nuevaAfiliacion.fecha_afiliacion, cliente.Id, sede.Idsede);






                    MessageBox.Show("Se ha registrado la Afiliación correctamente", "Proceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("debe digitar valores numéricos para Id Afilaición");
            }
           


                }
            }
        }
    

