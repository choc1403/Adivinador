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
        public static bool correcto;
        public static bool incorrecto;
        public static int contadorCorrecto;
        public static int contadorIncorrecto;
        public static int nodoDerecho, nodoIzquierdo;
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

        private void txtPrueba_Click(object sender, EventArgs e)
        {

        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            contadorCorrecto++;
            if (sender is Button)
            {
                Button boton = (Button)sender;
                correcto = Convert.ToBoolean(boton.Tag);
                if (correcto)
                {
                    contadorCorrecto++;
                    if(contadorCorrecto%2 == 0)
                    {
                        contadorCorrecto++;
                        if (contadorCorrecto % 2 != 0)
                        {
                            MessageBox.Show("CORRECTO " + contadorCorrecto);
                            nodoDerecho = contadorCorrecto;

                        }

                    }
                    else
                    {
                        MessageBox.Show("CORRECTO " + contadorCorrecto);
                        nodoDerecho = contadorCorrecto;
                    }
                    sql = "SELECT pregunta FROM PreguntasPredeterminadas WHERE idPregunta ='" + nodoDerecho + "'";
                    sentenciaMostrarPregunta(sql);
                    cargador();
                    txtMostrarPregunta.Text = pregunta;

                }
                else
                {
                    MessageBox.Show("FALSO");
                }
            }
            
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            btnSi.Tag = false;
            btnSi.Tag = true;

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            contadorIncorrecto++;
            if (sender is Button)
            {
                Button boton = (Button)sender;
                incorrecto = Convert.ToBoolean(boton.Tag);
                if (incorrecto)
                {
                    MessageBox.Show("CORRECTO");
                }
                else
                {
                    contadorIncorrecto++;
                    if (contadorIncorrecto % 2 == 0)
                    {
                        MessageBox.Show("FALSO " + contadorIncorrecto + " )");
                        nodoIzquierdo = contadorIncorrecto;
                    }
                    sql = "SELECT pregunta FROM PreguntasPredeterminadas WHERE idPregunta ='" + nodoIzquierdo + "'";
                    sentenciaMostrarPregunta(sql);
                    cargador();
                    txtMostrarPregunta.Text = pregunta;

                }
            }
            
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
