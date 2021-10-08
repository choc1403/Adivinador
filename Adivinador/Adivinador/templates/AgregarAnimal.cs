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
    public partial class AgregarAnimal : Form
    {
        public static String tipoDeAnimal, agregarAnimal, agregarPregunta, wu, sql;
        public static String id;
        public static bool agre;
        public static int nodoPadre;
        ConstructorDePreguntas agPregunta;
        ConstructorAnimales agAnimal;
        public AgregarAnimal()
        {
            InitializeComponent();
        }
        void declarar()
        {
            agPregunta = new ConstructorDePreguntas();
            agAnimal = new ConstructorAnimales();

            tipoDeAnimal = Convert.ToString(cbTipoAnimal.Text);            
            agAnimal.nombre = Convert.ToString(txtNombre.Text);
            agPregunta.pregunta = Convert.ToString(txtPregunta.Text);

        }
        bool agregar(String sql)
        {
            MySqlConnection conexion = ConexionBD.conexion();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);                
                comando.ExecuteNonQuery();

                //MessageBox.Show("SENTENCIA REALIZADA");
                agre = true;
                

            }catch(MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex);
                
            }
            finally
            {
                conexion.Close();
            }
            return agre;
        }
       
        void realizado()
        {
            if (agre)
            {
                MessageBox.Show("AGREGADO");
                Inicio ir = new Inicio();
                ir.Show();
                Visible = false;
            }
        }
        void clasificar(int idPregunta, String tipo)
        {
            
            switch (tipo)
            {
                case "Acuaticos":
                    
                    agregarAnimal = "INSERT INTO Acuaticos(idPregunta, nombre)" +
                    "VALUES('"+idPregunta+"','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);

                    nodoPadre = 2;
                    sql = "UPDATE PreguntasPredeterminadas" +
                    " SET nodoPadre = '" + nodoPadre + "'" +
                    " WHERE idPregunta = '" + idPregunta + "'";
                    agregar(sql);
                    realizado();
                    break;

                case "Anfibios":                    
                    agregarAnimal = "INSERT INTO Anfibios(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);

                    nodoPadre = 8;
                    sql = "UPDATE PreguntasPredeterminadas" +
                    " SET nodoPadre = '" + nodoPadre + "'" +
                    " WHERE idPregunta = '" + idPregunta + "'";
                    agregar(sql);
                    realizado();

                    break;

                case "Aves":
                    
                    agregarAnimal = "INSERT INTO Aves(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);

                    nodoPadre = 1;
                    sql = "UPDATE PreguntasPredeterminadas" +
                    " SET nodoPadre = '" + nodoPadre + "'" +
                    " WHERE idPregunta = '" + idPregunta + "'";
                    agregar(sql);
                    realizado();
                    break;

                case "Mamiferos":
                    
                    agregarAnimal = "INSERT INTO Mamiferos(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);

                    nodoPadre = 4;
                    sql = "UPDATE PreguntasPredeterminadas" +
                    " SET nodoPadre = '" + nodoPadre + "'" +
                    " WHERE idPregunta = '" + idPregunta + "'";
                    agregar(sql);
                    realizado();
                    break;

                case "Reptiles":
                    agregarAnimal = "INSERT INTO Reptiles(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);

                    nodoPadre = 6;

                    sql = "UPDATE PreguntasPredeterminadas" +
                    " SET nodoPadre = '" + nodoPadre + "'" +
                    " WHERE idPregunta = '" + idPregunta + "'";
                    agregar(sql);
                    realizado();
                    break;
            }
        }

        private void AgregarAnimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void AgregarAnimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void vaciar()
        {
            cbTipoAnimal.Text = "";
            txtNombre.Text = "";
            txtPregunta.Text = "";
        }
        void mostrarId(String sql)
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

        private void btnPregunta_Click(object sender, EventArgs e)
        {
            if((cbTipoAnimal.Text == "")||(txtNombre.Text == "") || (txtPregunta.Text == ""))
            {
                MessageBox.Show("DEBE DE INGRESAR TODOS LOS DATOS: ");
            }
            else
            {
                
                declarar();
                
                agregarPregunta = "INSERT INTO PreguntasPredeterminadas (pregunta)" +
                    "VALUES('"+agPregunta.pregunta+"')";

                agregar(agregarPregunta);
                
                String hora = DateTime.Now.ToString("HH:mm:ss");
                String fecha = DateTime.Now.ToString("yyyy-MM-dd");

                wu = fecha+" "+hora;
                
                
                

                
                String buscar = "SELECT idPregunta " +
                    "FROM PreguntasPredeterminadas " +
                    "WHERE fecha_creacion = '"+wu+"'";

                mostrarId(buscar);


                

                int idPregunta = Convert.ToInt32(id);

                clasificar(idPregunta, tipoDeAnimal);

                vaciar();
                


            }
            
        }
    }
}
