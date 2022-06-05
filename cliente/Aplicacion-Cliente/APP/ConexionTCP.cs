using entities.modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public class ConexionTCP
    {
        private static IPAddress ipServidor;
        private static TcpClient cliente;
        private static IPEndPoint serverEndPoint;
        private static StreamWriter clienteStreamWriter;
        private static StreamReader clienteStreamReader;


        /// <summary>
        /// Conecta el cliente tcp con el servidor
        /// </summary>
        /// <param name="pIdentificadorCliente">Identificador o nombre del cliente</param>
        /// <returns>Retorna true si se conecta con el servidor</returns>
        public static bool Conectar(string pIdentificadorCliente)
        {
            try
            {
                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, 15810);
                cliente.Connect(serverEndPoint);
                
                MensajeSocket<string> mensajeConectar = new MensajeSocket<string> { Metodo = "Conectar", Entidad = pIdentificadorCliente };

                clienteStreamReader = new StreamReader(cliente.GetStream());
                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeConectar));
                clienteStreamWriter.Flush();


            }
            catch (SocketException)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Desconecta el cliente del servidor
        /// </summary>
        /// <param name="pIdentificadorCliente">Identificador o nombre del cliente</param>
        public static void Desconectar(string pIdentificadorCliente)
        {
            try
            {
                MensajeSocket<string> mensajeDesconectar = new MensajeSocket<string> { Metodo = "Desconectar", Entidad = pIdentificadorCliente };

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeDesconectar));
                clienteStreamWriter.Flush();
                cliente.Close();
            }
            catch (SocketException e)
            {
                MessageBox.Show("ha ocurrido un error de conexión");
                return;
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("ha ocurrido un error con el servidor");
                return;
            }

        }

        //public static List<OrdenCompra> ObtenerVentasVendedores(string idVend)
        //{
        //    List<OrdenCompra> listaVentas = new List<OrdenCompra>();
        //    MensajeSocket<string> msjObtVent = new MensajeSocket<string> { Metodo = "ObtenerVentasVendedores", Entidad = idVend };

        //    clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(msjObtVent));
        //    clienteStreamWriter.Flush();

        //    var mensaje = clienteStreamReader.ReadLine();
        //    listaVentas = JsonConvert.DeserializeObject<List<OrdenCompra>>(mensaje);

        //    return listaVentas;
        //}

        public static List<cscuposxsede> ObtenerCupos(string id)
        {
            try
            {
                List<cscuposxsede> listaArticulos = new List<cscuposxsede>();
                MensajeSocket<string> msjObtArt = new MensajeSocket<string> { Metodo = "ObtenerCupos" ,Entidad = id };

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(msjObtArt));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                listaArticulos = JsonConvert.DeserializeObject<List<cscuposxsede>>(mensaje);

                return listaArticulos;
            }
            catch (SocketException e)
            {
                MessageBox.Show("ha ocurrido un error de conexión");
                return null;
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("ha ocurrido un error con el servidor");
                return null;
            }

        }

        public static bool AgregarOrden(int id, reserva nuevaOrden)
        {
            try
            {
                MensajeSocket<reserva> mensajeOrden = new MensajeSocket<reserva> { Metodo = "RealizarReserva", Entidad = nuevaOrden };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeOrden));
                clienteStreamWriter.Flush();
                return true;

            }
            catch (SocketException e)
            {
                MessageBox.Show("ha ocurrido un error de conexión");
                return false;
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("ha ocurrido un error con el servidor");
                return false;
            }


        }

        public static bool buscarReserva(int id, reserva nuevaOrden)
        {
            try
            {
                MensajeSocket<reserva> mensajeOrden = new MensajeSocket<reserva> { Metodo = "BuscarReserva", Entidad = nuevaOrden };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeOrden));
                clienteStreamWriter.Flush();
                return true;

            }
            catch (SocketException e)
            {
                MessageBox.Show("ha ocurrido un error de conexión");
                return false;
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("ha ocurrido un error con el servidor");
                return false;
            }


        }

        public static List<cliente> ObtenerVendedor(string idVend)
        {
            List<cliente> vend = new List<cliente>();
            MensajeSocket<object> msjObtVendedor1 = new MensajeSocket<object> { Metodo = "ObtenerCliente", Entidad = idVend };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(msjObtVendedor1));
            clienteStreamWriter.Flush();
            try
            {
                var mensaje = clienteStreamReader.ReadLine();
                vend = JsonConvert.DeserializeObject<List<cliente>>(mensaje);
            }
            catch (Exception ev)
            {
                MessageBox.Show("Error:" + ev, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return vend;
        }

        public static List<reserva> ObtenerVentasVendedores(string idVend)
        {
            List<reserva> listaVentas = new List<reserva>();
            MensajeSocket<string> msjObtVent = new MensajeSocket<string> { Metodo = "ObtenerVentasVendedores", Entidad = idVend };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(msjObtVent));
            clienteStreamWriter.Flush();

            var mensaje = clienteStreamReader.ReadLine();
            listaVentas = JsonConvert.DeserializeObject<List<reserva>>(mensaje);

            return listaVentas;
        }

        
        //public static List<Vendedor> ObtenerVendedores()
        //{
        //    List<Vendedor> listaVendedores = new List<Vendedor>();

        //    try
        //    {
        //        MensajeSocket<string> mensajeObtenerAutores = new MensajeSocket<string> { Metodo = "ObtenerAutores" };

        //        clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerAutores));
        //        clienteStreamWriter.Flush();

        //        var mensaje = clienteStreamReader.ReadLine();
        //        listaVendedores = JsonConvert.DeserializeObject<List<Vendedor>>(mensaje);

        //        return listaVendedores;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static bool AgregarOrden(int id, OrdenCompra nuevaOrden)
        //{
        //    try
        //    {
        //        MensajeSocket<OrdenCompra> mensajeOrden = new MensajeSocket<OrdenCompra> { Metodo = "AgregarOrden", Entidad = nuevaOrden };
        //        clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeOrden));
        //        clienteStreamWriter.Flush();
        //        return true;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public static bool AgregarDetalle(cscuposxsede nuevoDetalle)
        {
            try
            {
                MensajeSocket<cscuposxsede> msjDetalle = new MensajeSocket<cscuposxsede> { Metodo = "AgregarDetalle", Entidad = nuevoDetalle };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(msjDetalle));
                clienteStreamWriter.Flush();
                return true;
            }
            catch (SocketException e )
            {
                MessageBox.Show("ha ocurrido un error de conexión");
                return false;

               
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("ha ocurrido un error con el servidor");
                return false;
            }
        }



       
        //public static bool AlcanzaCant(int cant, int cantDisp)//Este método devuelve si la cantidad existe en inventario
        //{
        //    int cantD = Convert.ToInt32(cantDisp);

        //    return (C_Metodos.CantValido(cant, cantD));
        //}

    }
}

