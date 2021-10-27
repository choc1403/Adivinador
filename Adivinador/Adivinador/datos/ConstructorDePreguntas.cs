using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivinador.datos
{
    class ConstructorDePreguntas
    {
        public string id { get; set; }
        public String pregunta { get; set; }
        
        public ConstructorDePreguntas()
        {

        }

        public void agregar(String sql)
        {
            MySqlConnection conexion = ConexionBD.conexion();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("SENTENCIA REALIZADA");



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex);

            }
            finally
            {
                conexion.Close();
            }

        }
        public void actualizar(String sql)
        {
            MySqlConnection conexion = ConexionBD.conexion();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();

                //MessageBox.Show("Agregado");



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex);

            }
            finally
            {
                conexion.Close();
            }

        }

        public void eliminar(String sql)
        {
            MySqlConnection conexion = ConexionBD.conexion();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();

                //MessageBox.Show("Agregado");



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex);

            }
            finally
            {
                conexion.Close();
            }

        }
        public void seleccionar(String sql)
        {
            MySqlDataReader reader = null;
            MySqlConnection conexion = ConexionBD.conexion();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetString(0);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado ninguna pregunta");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
