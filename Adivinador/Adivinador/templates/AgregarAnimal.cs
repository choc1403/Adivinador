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
        public static String tipoDeAnimal, agregarAnimal, agregarPregunta;
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
        void agregar(String sql)
        {
            MySqlConnection conexion = ConexionBD.conexion();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);                
                comando.ExecuteNonQuery();                

                MessageBox.Show("SENTENCIA REALIZADA");
                

            }catch(MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex);
            }
            finally
            {
                conexion.Close();
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
                    break;

                case "Anfibios":
                    agregarAnimal = "INSERT INTO Anfibios(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);
                    break;

                case "Aves":
                    agregarAnimal = "INSERT INTO Aves(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);
                    break;

                case "Mamiferos":
                    agregarAnimal = "INSERT INTO Mamiferos(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);
                    break;

                case "Reptiles":
                    agregarAnimal = "INSERT INTO Reptiles(idPregunta, nombre)" +
                    "VALUES('" + idPregunta + "','" + agAnimal.nombre + "')";

                    agregar(agregarAnimal);
                    break;
            }
        }
        void vaciar()
        {
            cbTipoAnimal.Text = "";
            txtNombre.Text = "";
            txtPregunta.Text = "";
        }

        private void btnPregunta_Click(object sender, EventArgs e)
        {
            if((cbTipoAnimal.Text == "")||(txtNombre.Text == "") || (txtPregunta.Text == ""))
            {
                MessageBox.Show("DEBE DE INGRESAR TODOS LOS DATOS: ");
            }
            else
            {
                int contador = 11;
                declarar();
                
                agregarPregunta = "INSERT INTO PreguntasPredeterminadas (idPregunta, pregunta)" +
                    "VALUES('"+contador+"', '"+agPregunta.pregunta+"')";

                agregar(agregarPregunta);

                clasificar(contador, tipoDeAnimal);
                vaciar();
                


            }
            
        }
    }
}
