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
    public partial class Cargador : Form
    {
        public static int carga;
        public Cargador()
        {
            InitializeComponent();
        }

        private void tmCargador_Tick(object sender, EventArgs e)
        {
            carga++;
            pbCargador.Value = carga;
            if(carga == 100)
            {
                tmCargador.Enabled = false;
                carga = 0;
                Visible = false;
            }
        }

        private void Cargador_Load(object sender, EventArgs e)
        {
            tmCargador.Enabled = true;
        }
    }
}
