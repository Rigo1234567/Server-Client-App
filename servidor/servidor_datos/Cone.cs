using entities.modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace servidor_datos
{
    public class Cone
    {

        public static string cadena_Conexion;

        public Cone()
        {
            //
            cadena_Conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=FITUNED;Integrated Security=True ;";



        }

        public List<cliente> Obtenercliente(string vend)
        {
            List<cliente> listaVendedores = new List<cliente>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;
            datos = " Select " +
                        "IdCliente, " +
                        "Nombre, " +
                        "PrimerApellido, " +
                        "SegundoApellido, " +
                        "FechaNacimiento, " +
                        "Genero, " +
                        "FechaIngreso " +
                        " From Cliente with (nolock) " +
                        " Where IdCliente = '" + vend + "'";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cliente pVendedor = new cliente();
                    pVendedor.Id = reader.GetString(0);
                    pVendedor.nombre = reader.GetString(1);
                    pVendedor.primer_apellido = reader.GetString(2);
                    pVendedor.segundo_apellido = reader.GetString(3);
                    pVendedor.fecha_nacimiento = reader.GetDateTime(4);
                    pVendedor.genero = Convert.ToChar(reader.GetString(5));
                    pVendedor.fecha_ingreso = reader.GetDateTime(6);

                    listaVendedores.Add(pVendedor);
                }
            }
            conex.Close();
            return listaVendedores;
        }






        public void AgregarOrdenCompraBD(int id, DateTime fecha, string identV, int idsede)
        {
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;

            conex = new SqlConnection(cadena_Conexion);
            datos = " Insert	Into	AfiliacionSede (" +
                        "IdAfiliacion, " +
                        "FechaAfiliacion, " +
                        "IdCliente, " +
                        "IdSede ) " +
                        " Values (" +

                                    "@IdAfiliacion," +
                                    "@FechaAfiliacion, " +
                                     "@IdCliente, " +
                                    "@IdSede)";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;
            cmd.Parameters.AddWithValue("@IdAfiliacion", id);
            cmd.Parameters.AddWithValue("@FechaAfiliacion", fecha);
            cmd.Parameters.AddWithValue("@IdCliente", identV);
            cmd.Parameters.AddWithValue("@IdSede", idsede);

            conex.Open();

            cmd.ExecuteNonQuery();

            conex.Close();
        }
        public void Agregarcliente(cliente cliente)
        {
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;

            conex = new SqlConnection(cadena_Conexion);
            datos = " Insert	Into	Cliente (" +
                        "IdCliente, " +
                        "Nombre, " +
                        "PrimerApellido, " +
                        "SegundoApellido, " +
                        "FechaNacimiento, " +
                        "Genero, " +
                        "FechaIngreso)" +
                        " Values (" +
                                    "@IdCliente, " +
                                    "@Nombre, " +
                                    "@PrimerApellido, " +
                                    "@SegundoApellido, " +
                                    "@FechaNacimiento, " +
                                    "@Genero, " +
                                    "@FechaIngreso)";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;
            cmd.Parameters.AddWithValue("@IdCliente", cliente.Id);
            cmd.Parameters.AddWithValue("@Nombre", cliente.nombre);
            cmd.Parameters.AddWithValue("@PrimerApellido", cliente.primer_apellido);
            cmd.Parameters.AddWithValue("@SegundoApellido", cliente.segundo_apellido);
            cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@Genero", cliente.genero);
            cmd.Parameters.AddWithValue("@FechaIngreso", cliente.fecha_ingreso);

            conex.Open();

            cmd.ExecuteNonQuery();

            conex.Close();
        }

        public void Agregarsede(sede sede)
        {
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;

            conex = new SqlConnection(cadena_Conexion);
            datos = " Insert	Into	Sede (" +
                        "IdSede, " +
                        "Nombre, " +
                        "Direccion, " +
                        "Estado, " +
                        "Telefono)" +

                        " Values (" +
                                    "@IdSede, " +
                                    "@Nombre, " +
                                    "@Direccion, " +
                                    "@Estado, " +
                                    "@Telefono) ";


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;
            cmd.Parameters.AddWithValue("@IdSede", sede.Idsede);
            cmd.Parameters.AddWithValue("@Nombre", sede.nombre_sede);
            cmd.Parameters.AddWithValue("@Direccion", sede.direccion_sede);
            cmd.Parameters.AddWithValue("@Estado", sede.estado);
            cmd.Parameters.AddWithValue("@Telefono", sede.telefono);

            conex.Open();

            cmd.ExecuteNonQuery();

            conex.Close();
        }

        public void Agregarcupos(cscuposxsede sede)
        {
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;

            conex = new SqlConnection(cadena_Conexion);
            datos = " Insert	Into	CupoSede (" +
                        "IdSede, " +
                        "FechaCupo, " +
                        "Cupos )" +
                        " Values (" +
                                    "@IdSede, " +
                                    "@FechaCupo, " +
                                    "@Cupos) ";


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;
            cmd.Parameters.AddWithValue("@IdSede", sede.sede.Idsede);
            cmd.Parameters.AddWithValue("@FechaCupo", sede.fecha);
            cmd.Parameters.AddWithValue("@Cupos", sede.cupos);


            conex.Open();

            cmd.ExecuteNonQuery();

            conex.Close();
        }



        public bool BuscarIdreservacion(reserva reser)
        {
            bool resultado = true;
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("SELECT CASE WHEN exists(SELECT * FROM Reserva WHERE IdReserva = )" + reser.idreserva + " THEN 'TRUE' ELSE 'FALSE' END", conex);

            string lastId = Convert.ToString(cmd.ExecuteScalar());

            if (lastId == "TRUE")
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }


            conex.Close();

            return resultado;
        }






        public static string[] BuscarDetalle(string idO)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from Reserva where IdReserva = '" + idO + "'", conex);

            SqlDataReader reader = cmd.ExecuteReader();

            string[] resultado = null;

            while (reader.Read())
            {
                string[] valor =
                {
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString()
                };
                resultado = valor;
            }
            conex.Close();


            return resultado;
        }

        public int BuscarId(string nombBD, string nombId, int id, int posDeseada)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from " + nombBD + " where " + nombId + " = '" + id + "'"  , conex);

            SqlDataReader reader = cmd.ExecuteReader();

            int resultado = 0;

            while (reader.Read())
            {
                resultado = int.Parse(reader[posDeseada].ToString());
            }
            conex.Close();


            return resultado;
        }

        public DateTime Buscarfecha(string nombBD, string nombId, DateTime fecha, int posDeseada)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from " + nombBD + " where " + nombId + " = '" + fecha + "'" , conex);

            SqlDataReader reader = cmd.ExecuteReader();

            DateTime resultado = DateTime.MinValue;

            while (reader.Read())
            {
                resultado = DateTime.Parse(reader[posDeseada].ToString());
            }
            conex.Close();


            return resultado;
        }
        public string BuscarIdcliente(string nombBD, string nombId, string id, int posDeseada)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from " + nombBD + " where " + nombId + " = '" + id + "'", conex);

            SqlDataReader reader = cmd.ExecuteReader();

            string resultado = null;

            while (reader.Read())
            {
                resultado = reader[posDeseada].ToString();
            }
            conex.Close();


            return resultado;
        }

        public  bool Obtenerafiliaciones(string cliente, int id)
        {
            List<afiliacionSede> listaclientes = new List<afiliacionSede>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;
            datos = " Select " +
                        "IdAfiliacion, " +
                        "FechaAfiliacion, " +
                        "IdCliente, " +
                        "IdSede " +
                        " From AfiliacionSede with (nolock) ";


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    afiliacionSede clientes = new afiliacionSede();
                    clientes.id_afiliacion = reader.GetInt32(0);
                    clientes.fecha_afiliacion = reader.GetDateTime(1);
                    clientes.cliente.Id = reader.GetString(2);
                    clientes.sede.Idsede = reader.GetInt32(3);




                    listaclientes.Add(clientes);
                }
            }
            conex.Close();


            if (listaclientes.Exists(x => x.cliente.Id.Equals(cliente) && x.sede.Idsede.Equals(id) ))
            {
                return true;


            }

            return false;



        }

        public List<sede> ObtenerSedes()
        {
            List<sede> listaArticulos = new List<sede>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;

            datos = " Select " +
                            "IdSede, " +
                            "Nombre, " +
                            "Direccion, " +
                            "Estado, " +
                            "Telefono " +
                        " From Sede";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sede pArticulo = new sede();
                    pArticulo.Idsede = int.Parse(reader.GetInt32(0).ToString());
                    pArticulo.nombre_sede = reader.GetString(1);
                    pArticulo.direccion_sede = reader.GetString(2);
                    pArticulo.estado = reader.GetBoolean(3);
                    pArticulo.telefono = reader.GetString(4);


                    listaArticulos.Add(pArticulo);
                }
            }

            conex.Close();

            return listaArticulos;
        }



        public void realizarreserva(reserva nueva)
        {
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;

            conex = new SqlConnection(cadena_Conexion);
            datos = " Insert	Into	Reserva (" +
                        "IdReserva, " +
                        "IdSede, " +
                        "IdCliente, " +
                        "Fecha ) " +
                        " Values (" +
                                    //"(SELECT COALESCE(MAX(IDOrden),0)+1 FROM ORDENCOMPRA)," +
                                    "@IdReserva," +
                                    "@IdSede, " +
                                    "@IdCliente, " +
                                    "@Fecha)";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;
            cmd.Parameters.AddWithValue("@IdReserva", nueva.idreserva);
            cmd.Parameters.AddWithValue("@IdSede", nueva.sede.Idsede);
            cmd.Parameters.AddWithValue("@IdCliente", nueva.cliente.Id);
            cmd.Parameters.AddWithValue("@Fecha", nueva.fecha);

            conex.Open();

            cmd.ExecuteNonQuery();

            conex.Close();
        }

        public List<cliente> ObtenerClientes()
        {
            List<cliente> listaArticulos = new List<cliente>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;

            datos = " Select " +
                            "IdCliente, " +
                            "Nombre, " +
                            "PrimerApellido, " +
                            "SegundoApellido, " +
                            "FechaNacimiento, " +
                            "Genero, " +
                            "FechaIngreso " +
                        " From Cliente";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cliente pArticulo = new cliente();
                    pArticulo.Id = reader.GetString(0);
                    pArticulo.nombre = reader.GetString(1);
                    pArticulo.primer_apellido = reader.GetString(2);
                    pArticulo.segundo_apellido = reader.GetString(3);
                    pArticulo.fecha_nacimiento = reader.GetDateTime(4);
                    pArticulo.genero = Convert.ToChar(reader.GetString(5));
                    pArticulo.fecha_ingreso = reader.GetDateTime(6);



                    listaArticulos.Add(pArticulo);
                }
            }

            conex.Close();

            return listaArticulos;
        }

        public List<cscuposxsede> ObtenerCuposSede()
        {
            List<cscuposxsede> listaArticulos = new List<cscuposxsede>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;

            datos = " Select " +
                            "IdSede, " +
                            "FechaCupo, " +
                            "Cupos " +
                        " From CupoSede";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cscuposxsede pArticulo = new cscuposxsede();
                    pArticulo.sede.Idsede = reader.GetInt32(0);
                    pArticulo.fecha = reader.GetDateTime(1);
                    pArticulo.cupos = reader.GetInt32(2);




                    listaArticulos.Add(pArticulo);
                }
            }

            conex.Close();

            return listaArticulos;
        }


        public List<cscuposxsede> ObtenerCuposDisponibles(string id)
        {
            List<cscuposxsede> listaArticulos = new List<cscuposxsede>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;
            

            datos = "select distinct c.IdSede,FechaCupo,Cupos from CupoSede as c join AfiliacionSede as p on p.IdCliente = '"+id+ "' and Cupos > 0 where datediff(day,cast(getdate() as date) ,cast(FechaCupo as date)) in (0,1,2,3) ";






            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cscuposxsede pArticulo = new cscuposxsede();
                    pArticulo.sede.Idsede = reader.GetInt32(0);
                    pArticulo.fecha =   Convert.ToDateTime(reader.GetDateTime(1).Date.ToString("dd-MM-yyyy"));
                    pArticulo.cupos = reader.GetInt32(2);




                    listaArticulos.Add(pArticulo);
                }
            }

            conex.Close();

            return listaArticulos;
        }




        public void actualizar()
        {
            SqlConnection conex;
            conex = new SqlConnection(cadena_Conexion);
            conex.Open();

            string query = "select IdAfilaicion, FechaAfiliacion, IdCliente, IdSede from Afiliacionsede";

            SqlCommand cm = new SqlCommand(query, conex);

            SqlDataReader raeder = cm.ExecuteReader();

            while (raeder.Read())
            {
                //afiliacionSede m = new afiliacionSede()
                //{
                //    id_afiliacion= int.Parse(raeder["IdAfiliacion"].ToString()),
                //    fecha_afiliacion = DateTime.Parse(raeder["IdAfiliacion"].ToString()),
                //     = int.Parse(raeder["IdCliente"].ToString()),


                //}
            }

        }

        public List<reserva> obtenereservas(string id)
        {
            List<reserva> listaArticulos = new List<reserva>();
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;


            datos = " Select " +
                            "IdReserva, " +
                            "IdSede, " +
                            "IdCliente, " +
                            "Fecha" +
                        " From Reserva where IdCliente = " + id;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reserva pArticulo = new reserva();
                    pArticulo.idreserva = reader.GetInt32(0);
                    pArticulo.sede.Idsede = reader.GetInt32(1);
                    pArticulo.cliente.Id = reader.GetString(2);
                    pArticulo.fecha = reader.GetDateTime(3);


                    listaArticulos.Add(pArticulo);
                }
            }

            conex.Close();

            return listaArticulos;
        }


        public sede obtenersede(int id)
        {

            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;


            datos = " Select " +
                            "IdSede, " +
                            "Nombre, " +
                            "Direccion, " +
                            "Fecha," +
                            "Estado," +
                            "Telefono" +
                        " From Sede where IdSede = " + id;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();


            sede pArticulo = new sede();
            pArticulo.Idsede = reader.GetInt32(0);
            pArticulo.nombre_sede = reader.GetString(1);
            pArticulo.direccion_sede = reader.GetString(2);
            pArticulo.estado = reader.GetBoolean(3);
            pArticulo.telefono = reader.GetString(4);




            conex.Close();

            return pArticulo;
        }

        public reserva obtenerreser(int id)
        {

            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;
            conex = new SqlConnection(cadena_Conexion);

            SqlDataReader reader;


            datos = " Select " +
                            "IdReserva, " +
                            "IdSede, " +
                            "IdCliente, " +
                            "Fecha" +

                        " From Sede where IdReserva = " + id;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();
            reader = cmd.ExecuteReader();


            reserva pArticulo = new reserva();
            pArticulo.idreserva = reader.GetInt32(0);
            pArticulo.sede.Idsede = reader.GetInt32(1);
            pArticulo.cliente.Id = reader.GetString(2);
            pArticulo.fecha = reader.GetDateTime(3);





            conex.Close();

            return pArticulo;
        }




        public void ActCupos(cscuposxsede art)
        {
            SqlConnection conex;
            SqlCommand cmd = new SqlCommand();
            string datos;

            conex = new SqlConnection(cadena_Conexion);
            datos = " UPDATE CupoSede " +
                        "SET " +
                        "Cupos = " + (art.cupos - 1) +
                        " WHERE IdSede =" + art.sede.Idsede + "";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = datos;
            cmd.Connection = conex;

            conex.Open();

            cmd.ExecuteNonQuery();

            conex.Close();
        }



        public void llenargridafiliacion(DataGridView dgv)
        {
            SqlConnection conex;
            conex = new SqlConnection(cadena_Conexion);

            SqlCommand cm = new SqlCommand("Select * from AfiliacionSede;", conex);

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dgv.DataSource = dt;

        }

        //public List<cliente> ObtenerAfiliaciones()
        //{
        //    List<afiliacionSede> listaArticulos = new List<afiliacionSede>();
        //    SqlConnection conex;
        //    SqlCommand cmd = new SqlCommand();
        //    string datos;
        //    conex = new SqlConnection(cadena_Conexion);

        //    SqlDataReader reader;

        //    datos = " Select " +
        //                    "IdAfiliacion, " +
        //                    "FechaAfiliacion, " +
        //                    "IdCliente, " +
        //                    "IdSede " +          
        //                " From Cliente";

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = datos;
        //    cmd.Connection = conex;

        //    conex.Open();
        //    reader = cmd.ExecuteReader();

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            afiliacionSede pArticulo = new afiliacionSede();
        //            afiliacionclientesede sed = new afiliacionclientesede();


        //            pArticulo.id_afiliacion = int.Parse(reader.GetString(0));
        //            pArticulo.fecha_afiliacion = reader.GetDateTime(1);
        //            pArticulo.cliente.Id = reader.GetString(2);
        //            sed.sede.Idsede = int.Parse(reader.GetString(3));




        //            listaArticulos.Add(pArticulo);
        //        }
        //    }

        //    conex.Close();

        //    //return listaArticulos;
        //}

    }


}

    