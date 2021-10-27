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
        public int id { get; set; }
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

                //MessageBox.Show("SENTENCIA REALIZADA");



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
    }
}
