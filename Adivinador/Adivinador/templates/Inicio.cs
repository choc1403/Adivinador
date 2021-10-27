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
        public String sql, pregunta, nodo;
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
                    agregar();
                    contadorCorrecto = 0;
                    contadorIncorrecto = 0;
                    
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
        void sentenciaMostrarNodo(String sql)
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
                        nodo = reader.GetString(0);
                        
                    }
                }
                else
                {
                    MessageBox.Show("YA NO SE ENCUENTRAR PREGUNTAS");
                    Inicio ir = new Inicio();
                    ir.Show();
                    Visible = false;

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
        void agregar()
        {
            AgregarAnimal ir = new AgregarAnimal();
            ir.Show();
            Visible = false;
            btnIniciar.Enabled = true;
        }

        void cargador()
        {
            Cargador cargar = new Cargador();
            cargar.Show();
            btnSi.Visible = true;
            btnNo.Visible = true;
            btnIniciar.Enabled = false;
        }

        

        

        private void btnSi_Click(object sender, EventArgs e)
        {
            
            if (nodoDerechoInicio() == "2")
            {
                String irNodoDerecho = "SELECT pregunta FROM PreguntasPredeterminadas WHERE idPregunta ='2'";
                sentenciaMostrarNodo(irNodoDerecho);                    
                txtMostrarPregunta.Text = nodo;
                contadorCorrecto += 2;
            }
            if (contadorCorrecto %2 == 0)
            {

                nodoDerecho = contadorCorrecto;
                if (derecho(nodoDerecho) == "der")
                {
                    MessageBox.Show("Logrado");
                }
                else
                {
                    String irNodoIzquierdoo = "SELECT pregunta FROM PreguntasPredeterminadas WHERE idPregunta ='" + nodoDerecho + "'";
                    sentenciaMostrarPregunta(irNodoIzquierdoo);
                    txtMostrarPregunta.Text = pregunta;
                }
            }

        }

        string derecho(int x)
        {
            string right;
            String irNodoDerecho = "SELECT nodoDerecho FROM PreguntasPredeterminadas WHERE idPregunta ='" + x + "'";
            sentenciaMostrarNodo(irNodoDerecho);
            right = nodo;
            
            return right;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            btnSi.Tag = false;
            btnSi.Tag = true;
            btnSi.Visible = false;
            btnNo.Visible = false;

        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (nodoIzquierdoInicio() == "3")
            {
                String irNodoIzquierdo = "SELECT pregunta FROM PreguntasPredeterminadas WHERE idPregunta ='3'";
                sentenciaMostrarNodo(irNodoIzquierdo);
                txtMostrarPregunta.Text = nodo;
                contadorIncorrecto += 2;
            }

            if (contadorIncorrecto % 2 == 0)
            {
                contadorIncorrecto++;
                if (contadorIncorrecto % 2 != 0)
                {
                    nodoIzquierdo = contadorIncorrecto;
                }

            }
            else
            {
                nodoIzquierdo = contadorIncorrecto;
            }
            MessageBox.Show("" + nodoIzquierdo);
            izquierdo(nodoIzquierdo);


        }
        void izquierdo(int x)
        {
            
            String irNodoIzquierdoo = "SELECT pregunta FROM PreguntasPredeterminadas WHERE idPregunta ='" + x + "'";
            sentenciaMostrarPregunta(irNodoIzquierdoo);
            txtMostrarPregunta.Text = pregunta;
           
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            sql = "SELECT pregunta FROM PreguntasPredeterminadas LIMIT 1";
            sentenciaMostrarPregunta(sql);
            cargador();            
            txtMostrarPregunta.Text = ""+pregunta;
            
        }

        string nodoDerechoInicio()
        {
            String irNodoDerecho = "SELECT nodoDerecho FROM PreguntasPredeterminadas WHERE idPregunta ='" + 1 + "'";
            sentenciaMostrarNodo(irNodoDerecho);
            
            String nodoPadre = nodo;
            return nodoPadre;
        }
        string nodoIzquierdoInicio()
        {
            String irNodoIzquierdo = "SELECT nodoIzquierdo FROM PreguntasPredeterminadas WHERE idPregunta ='" + 1 + "'";
            sentenciaMostrarNodo(irNodoIzquierdo);

            String nodoPadre = nodo;
            return nodoPadre;
        }


    }
}
