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
    }
}
