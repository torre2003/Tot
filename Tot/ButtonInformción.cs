using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tot
{
    public partial class ButtonInformación : UserControl
    {
        public string ruta_rtf_ayuda { get; set; }

        public ButtonInformación()
        {
            InitializeComponent();
            this.pictureBox_boton.Image = imageList_boton.Images[0];
        }
        
        public ButtonInformación(string ruta_rtf)
        {
            InitializeComponent();
            this.pictureBox_boton.Image = imageList_boton.Images[0];
            ruta_rtf_ayuda = ruta_rtf;
        }

        private void pictureBox_boton_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox_boton.Image = imageList_boton.Images[1];
        }

        private void pictureBox_boton_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox_boton.Image = imageList_boton.Images[0];
        }

        private void pictureBox_boton_MouseClick(object sender, MouseEventArgs e)
        {
            FileInfo archivo_rtf = new FileInfo("c:\\a"); 
            if (ruta_rtf_ayuda != null)
                archivo_rtf = new FileInfo(ruta_rtf_ayuda);

            if (archivo_rtf.Exists && archivo_rtf != null)
            {
                Form_ventana_ayuda ayuda = new Form_ventana_ayuda();
                ayuda.mostrarRTFDescripcion(ruta_rtf_ayuda);
                ayuda.ShowDialog();
            }
            else
            {
                MessageBox.Show("Archivo de ayuda no encontrado...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void pictureBox_boton_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox_boton.Image = imageList_boton.Images[2];
        }

        private void pictureBox_boton_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox_boton.Image = imageList_boton.Images[0];
        }





    }

    class Form_ventana_ayuda : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public Form_ventana_ayuda()
        {
            InitializeComponent();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ventana_ayuda));
            this.richTextBox_texto = new System.Windows.Forms.RichTextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_texto
            // 
            this.richTextBox_texto.BackColor = System.Drawing.SystemColors.Window;
            //this.richTextBox_texto.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox_texto.Location = new System.Drawing.Point(-3, -1);
            this.richTextBox_texto.Name = "richTextBox_texto";
            this.richTextBox_texto.ReadOnly = true;
            this.richTextBox_texto.Size = new System.Drawing.Size(687, 535);
            this.richTextBox_texto.TabIndex = 0;
            this.richTextBox_texto.Text = "";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(350, 538);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 1;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // Form_ventana_ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.ControlBox = false;
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.richTextBox_texto);
            this.MaximumSize = new System.Drawing.Size(700, 600);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "Form_ventana_ayuda";
            this.Text = "Ayuda";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_texto;
        private System.Windows.Forms.Button button_aceptar;



        /// <summary>
        /// Metodo para mostrar el archivo rtf en la descripción del control
        /// </summary>
        public void mostrarRTFDescripcion(string ruta_richText)
        {
            richTextBox_texto.Clear();
            try
            {
                this.richTextBox_texto.Rtf = System.IO.File.ReadAllText(ruta_richText, System.Text.Encoding.Default);
            }
            catch (Exception e) //error occured, that means we loaded invalid RTF, so load as plain text
            {
                this.richTextBox_texto.Text = System.IO.File.ReadAllText(ruta_richText, System.Text.Encoding.Default);
            }
        }
    }


}
