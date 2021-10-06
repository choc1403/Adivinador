using Adivinador.datos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivinador.templates
{
    public partial class Inicio : Form
    {
        public String sql, pregunta;
        public Inicio()
        {
            InitializeComponent();
        }
        void sentenciaMostrarPregunta(String sql)
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
                        pregunta = reader.GetString(0);
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

        void cargador()
        {
            Cargador cargar = new Cargador();
            cargar.Show();
        }

        private void txtMostrarPregunta_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            sql = "SELECT pregunta FROM PreguntasPredeterminadas LIMIT 1";
            sentenciaMostrarPregunta(sql);
            cargador();
            txtMostrarPregunta.Text = pregunta;
        }
    }
}
