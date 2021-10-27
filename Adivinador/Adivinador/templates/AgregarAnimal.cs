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
        public static String agregarAnimal, agregarPregunta, wu, sql, buscar;
        public static String idP, idA;
        public static bool agre;
        public static bool nodoIzquierdo, nodoDerecho;
        ConstructorDePreguntas agPregunta;
        ConstructorDeAnimales agAnimal;
        
        public AgregarAnimal()
        {
            InitializeComponent();
        }
        void declarar()
        {
            agPregunta = new ConstructorDePreguntas();
            agAnimal = new ConstructorDeAnimales();
            
            agAnimal.nombre = Convert.ToString(txtNombre.Text);
            agPregunta.pregunta = Convert.ToString(txtPregunta.Text);

        }
        
       
        void realizado()
        {
            Inicio ir = new Inicio();
            ir.Show();
            Visible = false;
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

        private void AgregarAnimal_Load(object sender, EventArgs e)
        {
            
            
        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            nodoIzquierdo = true;
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void vaciar()
        {
            txtNombre.Text = "";
            txtPregunta.Text = "";
            realizado();
        }
        

        private void btnPregunta_Click(object sender, EventArgs e)
        {
            if((txtNombre.Text == "") || (txtPregunta.Text == ""))
            {
                MessageBox.Show("DEBE DE INGRESAR TODOS LOS DATOS: ");
            }
            else
            {
                
                declarar();
                

                agregarPregunta = "INSERT INTO PreguntasPredeterminadas (pregunta)" +
                    "VALUES('"+agPregunta.pregunta+"')";

                agPregunta.agregar(agregarPregunta);

                agregarAnimal = "INSERT INTO PreguntasPredeterminadas (pregunta)" +
                    "VALUES('" + agAnimal.nombre + " ')";

                agAnimal.agregar(agregarAnimal);

                vaciar();

            }  
        }  
    }
}
