
namespace Adivinador.templates
{
    partial class Cargador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbCargador = new System.Windows.Forms.ProgressBar();
            this.tmCargador = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbCargador
            // 
            this.pbCargador.BackColor = System.Drawing.Color.Chartreuse;
            this.pbCargador.ForeColor = System.Drawing.Color.Black;
            this.pbCargador.Location = new System.Drawing.Point(43, 80);
            this.pbCargador.Name = "pbCargador";
            this.pbCargador.Size = new System.Drawing.Size(545, 14);
            this.pbCargador.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbCargador.TabIndex = 0;
            // 
            // tmCargador
            // 
            this.tmCargador.Interval = 5;
            this.tmCargador.Tick += new System.EventHandler(this.tmCargador_Tick);
            // 
            // Cargador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(622, 180);
            this.Controls.Add(this.pbCargador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cargador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargador";
            this.Load += new System.EventHandler(this.Cargador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCargador;
        private System.Windows.Forms.Timer tmCargador;
    }
}