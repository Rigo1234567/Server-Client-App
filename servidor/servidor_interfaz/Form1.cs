
using entities.modelos;
using Newtonsoft.Json;
using servidor_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace servidor_interfaz
{
    public partial class Form1 : Form
    {

        TcpListener tcpListener;
        Thread subprocesoEscuchaClientes;
        EscribirEnTextboxDelegado modificarTextotxtBitacora;
        ModoficarListBoxDelegado modificarListBoxClientes;
        Cone accesoDatos;
        bool servidorIniciado;

        

        public Form1()
        {
            InitializeComponent();
            accesoDatos = new Cone();
            modificarTextotxtBitacora = new EscribirEnTextboxDelegado(EscribirEnTextbox);
            modificarListBoxClientes = new ModoficarListBoxDelegado(ModificarListBox);
            label2.ForeColor = Color.Red;
            btndetener.Enabled = false;
        }

        private void EscribirEnTextbox(string texto)
        {
            TB_Bit.AppendText(DateTime.Now.ToString() + " - " + texto);
            TB_Bit.AppendText(Environment.NewLine);
        }

        private void ModificarListBox(string texto, bool agregar)
        {
            if (agregar)
            {
                lB_Clientes.Items.Add(texto);
            }
            else
            {
                lB_Clientes.Items.Remove(texto);
            }

        }



        private delegate void EscribirEnTextboxDelegado(string texto);
        private delegate void ModoficarListBoxDelegado(string texto, bool agregar);


        private void btniniciar_Click(object sender, EventArgs e)
        {
            IPAddress local = IPAddress.Parse("127.0.0.1");
            tcpListener = new TcpListener(local, 15810);
            servidorIniciado = true;

            subprocesoEscuchaClientes = new Thread(new ThreadStart(EscucharClientes));
            subprocesoEscuchaClientes.Start();
            subprocesoEscuchaClientes.IsBackground = true;
            label2.Text = "Escuchando clientes... en (127.0.0.1, 15810)";
            label2.ForeColor = Color.Green;
            btniniciar.Enabled = false;
            btndetener.Enabled = true;

            TB_Bit.Invoke(modificarTextotxtBitacora, new object[] { "Servidor iniciado..." });

            this.timer1.Start();
        }

        private void btndetener_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            PB_Server.Value = 0;

            servidorIniciado = false;
            tcpListener.Stop();
            subprocesoEscuchaClientes.Abort();


            label2.ForeColor = Color.Red;
            label2.Text = "Sin iniciar";
            btniniciar.Enabled = true;
            btndetener.Enabled = false;

            TB_Bit.Invoke(modificarTextotxtBitacora, new object[] { "Servidor detenido" });
        }


        private void EscucharClientes()
        {
            tcpListener.Start();
            while (servidorIniciado)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(ComunicacionCliente));
                    clientThread.Start(client);
                }
                catch (Exception)
                {
                    throw;
                }

            }


        }


        private void ComunicacionCliente(object cliente)
        {
            TcpClient tcCliente = (TcpClient)cliente;
            StreamReader reader = new StreamReader(tcCliente.GetStream());
            StreamWriter servidorStreamWriter = new StreamWriter(tcCliente.GetStream());

            while (servidorIniciado)
            {
                try
                {
                    var mensaje = reader.ReadLine();
                    MensajeSocket<object> mensajeRecibido = JsonConvert.DeserializeObject<MensajeSocket<object>>(mensaje);
                    SeleccionarMetodo(mensajeRecibido.Metodo, mensaje, ref servidorStreamWriter);
                }
                catch (Exception e)
                {
                    break;
                }
            }
            tcCliente.Close();
        }

        private void Conectar(string idVendedor)
        {
            TB_Bit.Invoke(modificarTextotxtBitacora, new object[] { idVendedor + " se ha conectado..." });
            lB_Clientes.Invoke(modificarListBoxClientes, new object[] { idVendedor, true });
        }

        private void Desconectar(string idVendedor)
        {
            TB_Bit.Invoke(modificarTextotxtBitacora, new object[] { idVendedor + " se ha desconectado!" });
            lB_Clientes.Invoke(modificarListBoxClientes, new object[] { idVendedor, false });
        }


        private List<cliente> ObtenerLVendedor(string idVend, ref StreamWriter servidorStreamWriter)
        {
            List<cliente> NuevoVendedor = new List<cliente>();
            NuevoVendedor = accesoDatos.Obtenercliente(idVend);


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(NuevoVendedor));
            servidorStreamWriter.Flush();

            return NuevoVendedor;
        }


      




        private List<reserva> Obtenerreservas(string id, ref StreamWriter servidorStreamWriter)
        {
            List<reserva> listaarticulos = new List<reserva>();

            listaarticulos = accesoDatos.obtenereservas(id);

            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaarticulos));
            servidorStreamWriter.Flush();

            return listaarticulos;
        }

        private void AgregarOrden(reserva nuevaOrden)
        {
            accesoDatos.realizarreserva(nuevaOrden);
        }



        private void ActCupo(cscuposxsede nuevaOrden)
        {
            accesoDatos.ActCupos(nuevaOrden);
        }

   



        private List<cscuposxsede> ObtenerLArticulos(string id, ref StreamWriter servidorStreamWriter)
        {
            List<cscuposxsede> listaArticulos = new List<cscuposxsede>();

            listaArticulos = accesoDatos.ObtenerCuposDisponibles(id);

            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaArticulos));
            servidorStreamWriter.Flush();

            return listaArticulos;
        }

        public void SeleccionarMetodo(string pMetodo, string pMensaje, ref StreamWriter servidorStreamWriter)
        {
            switch (pMetodo)
            {
                case "Conectar":
                    MensajeSocket<string> mensajeConectar = JsonConvert.DeserializeObject<MensajeSocket<string>>(pMensaje);// Se deserializa el objeto recibido mediante json
                    Conectar(mensajeConectar.Entidad);
                    break;
                case "ObtenerCliente":
                    MensajeSocket<string> msjObtVend = JsonConvert.DeserializeObject<MensajeSocket<string>>(pMensaje);
                    ObtenerLVendedor(msjObtVend.Entidad, ref servidorStreamWriter);
                    break;
                case "ObtenerCupos":
                    MensajeSocket<string> msjObtArticulos = JsonConvert.DeserializeObject<MensajeSocket<string>>(pMensaje);
                    ObtenerLArticulos(msjObtArticulos.Entidad,ref servidorStreamWriter);
                    break;
                case "Desconectar":
                    MensajeSocket<string> mensajeDesconectar = JsonConvert.DeserializeObject<MensajeSocket<string>>(pMensaje);
                    Desconectar(mensajeDesconectar.Entidad);
                    break;

                case "ObtenerVentasVendedores":
                    MensajeSocket<string> mensajeCrearAutor = JsonConvert.DeserializeObject<MensajeSocket<string>>(pMensaje);// Se deserializa el objeto recibido mediante json
                    Obtenerreservas(mensajeCrearAutor.Entidad, ref servidorStreamWriter);
                    
                    break;

                case "AgregarDetalle":
                    MensajeSocket<cscuposxsede> mensajes2CrearAutor = JsonConvert.DeserializeObject<MensajeSocket<cscuposxsede>>(pMensaje);// Se deserializa el objeto recibido mediante json
                    ActCupo(mensajes2CrearAutor.Entidad);

                    break;      

                case "RealizarReserva":
                    MensajeSocket<reserva> mensajesCrearAutor = JsonConvert.DeserializeObject<MensajeSocket<reserva>>(pMensaje);// Se deserializa el objeto recibido mediante json
                   AgregarOrden(mensajesCrearAutor.Entidad);

                    break;

                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.PB_Server.Increment(1);
            if (PB_Server.Value == 100)
            {
                PB_Server.Value = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

      
    }
}
