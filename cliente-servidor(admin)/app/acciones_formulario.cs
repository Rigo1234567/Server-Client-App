using business.controladores;
using entities.modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public class acciones_formulario
    {

        Conexion C_Datos = new Conexion();

        public static string cadena_Conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=FITUNED;Integrated Security=True ;";




        public static string[] Buscarclientes(string vend)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from Cliente where IdCliente = '" + vend + "'", conex);

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
                    reader[5].ToString(),
                    reader[6].ToString()
                };
                resultado = valor;
            }
            conex.Close();


            return resultado;
        }

        public static string[] Buscarsede(int vend)
        {
            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from Sede where IdSede = '" + vend + "'", conex);

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
                  
                };
                resultado = valor;
            }
            conex.Close();


            return resultado;
        }


        public static void CargarComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from Cliente", conex);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox.Items.Add(reader[0].ToString());
            }

            conex.Close();
            comboBox.Items.Insert(0, "Seleccione un Cliente");
            comboBox.SelectedIndex = 0;
        }



        public static void CargarSedes(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            SqlConnection conex = new SqlConnection(cadena_Conexion);

            conex.Open();
            SqlCommand cmd = new SqlCommand("select * from Sede where Estado = 1", conex);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox.Items.Add(reader[0].ToString());
            }

            conex.Close();
            comboBox.Items.Insert(0, "Seleccione una Sede");
            comboBox.SelectedIndex = 0;
        }

        public static bool DataGridEstaVacio(DataGridView dg)
        {
            if (dg.Rows != null && dg.Rows.Count >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool SinSeleccion(DataGridView dg)
        {
            int posicion = dg.CurrentRow.Index;

            if (posicion < 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
