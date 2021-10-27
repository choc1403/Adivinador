using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivinador.datos
{
    class ConstructorDeAnimales
    {
        
        public string id { get; set; }
        public string nombre { get; set; }

        public ConstructorDeAnimales()
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

                MessageBox.Show("Agregado");



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

        public String pre()
        {
            
            return id;
        }
    }
}
