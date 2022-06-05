using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using entities.modelos;
using static business.controladores.controladorclientesede;
using static business.controladores.controladorafiliacion;
using System.Windows.Forms;

namespace business.controladores
{
    public class Conexion
    {
        public static string cadena_Conexion;
        public Conexion()
        {
            //
            cadena_Conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=FITUNED;Integrated Security=True ;";



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

        public void Agregarcupos( cscuposxsede sede)
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



        public int BuscarId(string nombBD, string nombId, int id, int posDeseada)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from " + nombBD + " where " + nombId + " = '" + id + "'", conex);

            SqlDataReader reader = cmd.ExecuteReader();

            int resultado = 0;

            while (reader.Read())
            {
                resultado = int.Parse(reader[posDeseada].ToString());
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
                resultado =reader[posDeseada].ToString();
            }
            conex.Close();


            return resultado;
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
