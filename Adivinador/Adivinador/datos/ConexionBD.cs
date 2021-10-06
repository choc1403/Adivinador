using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivinador.datos
{
    class ConexionBD
    {
        public MySqlConnection conexion()
        {
            String server, database, uid, pwd, info;
            server = "localhost";
            database = "bdAdivinador";
            uid = "root";
            pwd = "admin";

            info = "Server = " + server + "; Database = " + database +
                "; Uid = "+uid+"; Pwd = "+pwd;            

            try
            {
                MySqlConnection conexion = new MySqlConnection(info);
                Console.WriteLine("SE LOGRO LA CONEXION A LA BASE DE DATOS");
                return conexion;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR: " + e.Message);
                return null;
            }
        }
    }
}
