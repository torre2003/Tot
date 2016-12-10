using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot
{
    public partial class FormVentanaConfiguracionLogInferencia : Form
    {
        public FormVentanaConfiguracionLogInferencia()
        {
            InitializeComponent();
            inicializarComponentes();
        }



        /* ejemplo con tres texbox
          
            private System.Windows.Forms.Panel panel_x;
            private System.Windows.Forms.Label label_x_3;
            private System.Windows.Forms.Label label_tipo_x;
            private System.Windows.Forms.TextBox textBox_medio_x;
            private System.Windows.Forms.TextBox textBox_inicial_x;
            private System.Windows.Forms.Label label_x_2;
            private System.Windows.Forms.Label label_x_1;
            private System.Windows.Forms.Label label_formato_x;
            private System.Windows.Forms.CheckBox checkBox_x;
            private System.Windows.Forms.TextBox textBox_final_x;
            private System.Windows.Forms.Label label_x_4;
         
            void inicializar_x()
            {
            this.panel_x = new System.Windows.Forms.Panel();
            this.checkBox_x = new System.Windows.Forms.CheckBox();
            this.label_formato_x = new System.Windows.Forms.Label();
            this.label_x_1 = new System.Windows.Forms.Label();
            this.label_x_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_x = new System.Windows.Forms.TextBox();
            this.textBox_medio_x = new System.Windows.Forms.TextBox();
            this.label_tipo_x = new System.Windows.Forms.Label();
            this.label_x_3 = new System.Windows.Forms.Label();
            this.textBox_final_x = new System.Windows.Forms.TextBox();
            this.label_x_4 = new System.Windows.Forms.Label();
            this.panel_x.SuspendLayout();
            
            // 
            // panel_x
            // 
            this.panel_x.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_x.Controls.Add(this.textBox_final_x);
            this.panel_x.Controls.Add(this.label_x_4);
            this.panel_x.Controls.Add(this.label_x_3);
            this.panel_x.Controls.Add(this.label_tipo_x);
            this.panel_x.Controls.Add(this.textBox_medio_x);
            this.panel_x.Controls.Add(this.textBox_inicial_x);
            this.panel_x.Controls.Add(this.label_x_2);
            this.panel_x.Controls.Add(this.label_x_1);
            this.panel_x.Controls.Add(this.label_formato_x);
            this.panel_x.Controls.Add(this.checkBox_x);
            this.panel_x.Location = new System.Drawing.Point(12, 12);
            this.panel_x.Name = "panel_x";
            this.panel_x.Size = new System.Drawing.Size(550, 140);
            this.panel_x.TabIndex = 0;
            // 
            // checkBox_x
            // 
            this.checkBox_x.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_x.Location = new System.Drawing.Point(15, 34);
            this.checkBox_x.Name = "checkBox_x";
            this.checkBox_x.Size = new System.Drawing.Size(81, 24);
            this.checkBox_x.TabIndex = 0;
            this.checkBox_x.Text = "Mostrar";
            this.checkBox_x.UseVisualStyleBackColor = true;
            // 
            // label_formato_x
            // 
            this.label_formato_x.Location = new System.Drawing.Point(102, 32);
            this.label_formato_x.Name = "label_formato_x";
            this.label_formato_x.Size = new System.Drawing.Size(395, 23);
            this.label_formato_x.TabIndex = 1;
            this.label_formato_x.Text = "formato";
            this.label_formato_x.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_x_1
            // 
            this.label_x_1.AutoSize = true;
            this.label_x_1.Location = new System.Drawing.Point(12, 61);
            this.label_x_1.Name = "label1";
            this.label_x_1.Size = new System.Drawing.Size(66, 13);
            this.label_x_1.TabIndex = 2;
            this.label_x_1.Text = "Texto inicial:";
            // 
            // label_x_2
            // 
            this.label_x_2.AutoSize = true;
            this.label_x_2.Location = new System.Drawing.Point(12, 87);
            this.label_x_2.Name = "label2";
            this.label_x_2.Size = new System.Drawing.Size(68, 13);
            this.label_x_2.TabIndex = 3;
            this.label_x_2.Text = "Texto medio:";
            // 
            // textBox_inicial_x
            // 
            this.textBox_inicial_x.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_x.Name = "textBox_inicial_x";
            this.textBox_inicial_x.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_x.TabIndex = 4;
            // 
            // textBox_medio_x
            // 
            this.textBox_medio_x.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_x.Name = "textBox_medio_x";
            this.textBox_medio_x.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_x.TabIndex = 5;
            // 
            // label_tipo_x
            // 
            this.label_tipo_x.AutoSize = true;
            this.label_tipo_x.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_x.Name = "label_tipo_x";
            this.label_tipo_x.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_x.TabIndex = 6;
            this.label_tipo_x.Text = "LOG_TIPO";
            // 
            // label_x_3
            // 
            this.label_x_3.AutoSize = true;
            this.label_x_3.Location = new System.Drawing.Point(15, 15);
            this.label_x_3.Name = "label3";
            this.label_x_3.Size = new System.Drawing.Size(48, 13);
            this.label_x_3.TabIndex = 7;
            this.label_x_3.Text = "Tipo log:";
            // 
            // textBox_final_x
            // 
            this.textBox_final_x.Location = new System.Drawing.Point(84, 110);
            this.textBox_final_x.Name = "textBox_final_x";
            this.textBox_final_x.Size = new System.Drawing.Size(413, 20);
            this.textBox_final_x.TabIndex = 9;
            // 
            // label_x_4
            // 
            this.label_x_4.AutoSize = true;
            this.label_x_4.Location = new System.Drawing.Point(12, 113);
            this.label_x_4.Name = "label4";
            this.label_x_4.Size = new System.Drawing.Size(59, 13);
            this.label_x_4.TabIndex = 8;
            this.label_x_4.Text = "Texto final:";
            }
            
           //agregando a form
            this.Controls.Add(panel_x);
        //-----------------------------------------------------------------------------------
         * ejemplo con 2 
         
            private System.Windows.Forms.Panel panel_x;
            private System.Windows.Forms.Label label_x_3;
            private System.Windows.Forms.Label label_tipo_x;
            private System.Windows.Forms.TextBox textBox_medio_x;
            private System.Windows.Forms.TextBox textBox_inicial_x;
            private System.Windows.Forms.Label label_x_2;
            private System.Windows.Forms.Label label_x_1;
            private System.Windows.Forms.Label label_formato_x;
            private System.Windows.Forms.CheckBox checkBox_x;
            
            void inicializar_x()
            {
            this.panel_x = new System.Windows.Forms.Panel();
            this.checkBox_x = new System.Windows.Forms.CheckBox();
            this.label_formato_x = new System.Windows.Forms.Label();
            this.label_x_1 = new System.Windows.Forms.Label();
            this.label_x_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_x = new System.Windows.Forms.TextBox();
            this.textBox_medio_x = new System.Windows.Forms.TextBox();
            this.label_tipo_x = new System.Windows.Forms.Label();
            this.label_x_3 = new System.Windows.Forms.Label();
            this.panel_x.SuspendLayout();
            
            // 
            // panel_x
            // 
            this.panel_x.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_x.Controls.Add(this.label_x_3);
            this.panel_x.Controls.Add(this.label_tipo_x);
            this.panel_x.Controls.Add(this.textBox_medio_x);
            this.panel_x.Controls.Add(this.textBox_inicial_x);
            this.panel_x.Controls.Add(this.label_x_2);
            this.panel_x.Controls.Add(this.label_x_1);
            this.panel_x.Controls.Add(this.label_formato_x);
            this.panel_x.Controls.Add(this.checkBox_x);
            this.panel_x.Location = new System.Drawing.Point(12, 12);
            this.panel_x.Name = "panel_x";
            this.panel_x.Size = new System.Drawing.Size(550, 110);
            this.panel_x.TabIndex = 0;
            // 
            // checkBox_x
            // 
            this.checkBox_x.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_x.Location = new System.Drawing.Point(15, 34);
            this.checkBox_x.Name = "checkBox_x";
            this.checkBox_x.Size = new System.Drawing.Size(81, 24);
            this.checkBox_x.TabIndex = 0;
            this.checkBox_x.Text = "Mostrar";
            this.checkBox_x.UseVisualStyleBackColor = true;
            // 
            // label_formato_x
            // 
            this.label_formato_x.Location = new System.Drawing.Point(102, 32);
            this.label_formato_x.Name = "label_formato_x";
            this.label_formato_x.Size = new System.Drawing.Size(395, 23);
            this.label_formato_x.TabIndex = 1;
            this.label_formato_x.Text = "formato";
            this.label_formato_x.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_x_1
            // 
            this.label_x_1.AutoSize = true;
            this.label_x_1.Location = new System.Drawing.Point(12, 61);
            this.label_x_1.Name = "label1";
            this.label_x_1.Size = new System.Drawing.Size(66, 13);
            this.label_x_1.TabIndex = 2;
            this.label_x_1.Text = "Texto inicial:";
            // 
            // label_x_2
            // 
            this.label_x_2.AutoSize = true;
            this.label_x_2.Location = new System.Drawing.Point(12, 87);
            this.label_x_2.Name = "label2";
            this.label_x_2.Size = new System.Drawing.Size(68, 13);
            this.label_x_2.TabIndex = 3;
            this.label_x_2.Text = "Texto medio:";
            // 
            // textBox_inicial_x
            // 
            this.textBox_inicial_x.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_x.Name = "textBox_inicial_x";
            this.textBox_inicial_x.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_x.TabIndex = 4;
            // 
            // textBox_medio_x
            // 
            this.textBox_medio_x.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_x.Name = "textBox_medio_x";
            this.textBox_medio_x.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_x.TabIndex = 5;
            // 
            // label_tipo_x
            // 
            this.label_tipo_x.AutoSize = true;
            this.label_tipo_x.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_x.Name = "label_tipo_x";
            this.label_tipo_x.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_x.TabIndex = 6;
            this.label_tipo_x.Text = "LOG_TIPO";
            // 
            // label_x_3
            // 
            this.label_x_3.AutoSize = true;
            this.label_x_3.Location = new System.Drawing.Point(15, 15);
            this.label_x_3.Name = "label3";
            this.label_x_3.Size = new System.Drawing.Size(48, 13);
            this.label_x_3.TabIndex = 7;
            this.label_x_3.Text = "Tipo log:";
            
            //agregando a form
            this.Controls.Add(panel_x);
            }
        
         
          
         * -------------------------------------------------------------------
         * 1 combo 
          
         private System.Windows.Forms.Panel panel_x;
        private System.Windows.Forms.Label label_x_3;
        private System.Windows.Forms.Label label_tipo_x;
        private System.Windows.Forms.TextBox textBox_inicial_x;
        private System.Windows.Forms.Label label_x_1;
        private System.Windows.Forms.Label label_formato_x;
        private System.Windows.Forms.CheckBox checkBox_x;

        void inicializar_x()
        {
            this.panel_x = new System.Windows.Forms.Panel();
            this.checkBox_x = new System.Windows.Forms.CheckBox();
            this.label_formato_x = new System.Windows.Forms.Label();
            this.label_x_1 = new System.Windows.Forms.Label();
            this.textBox_inicial_x = new System.Windows.Forms.TextBox();
            this.label_tipo_x = new System.Windows.Forms.Label();
            this.label_x_3 = new System.Windows.Forms.Label();
            this.panel_x.SuspendLayout();

            // 
            // panel_x
            // 
            this.panel_x.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_x.Controls.Add(this.label_x_3);
            this.panel_x.Controls.Add(this.label_tipo_x);
            this.panel_x.Controls.Add(this.textBox_inicial_x);
            this.panel_x.Controls.Add(this.label_x_1);
            this.panel_x.Controls.Add(this.label_formato_x);
            this.panel_x.Controls.Add(this.checkBox_x);
            this.panel_x.Location = new System.Drawing.Point(12, 12);
            this.panel_x.Name = "panel_x";
            this.panel_x.Size = new System.Drawing.Size(550, 85);
            this.panel_x.TabIndex = 0;
            // 
            // checkBox_x
            // 
            this.checkBox_x.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_x.Location = new System.Drawing.Point(15, 34);
            this.checkBox_x.Name = "checkBox_x";
            this.checkBox_x.Size = new System.Drawing.Size(81, 24);
            this.checkBox_x.TabIndex = 0;
            this.checkBox_x.Text = "Mostrar";
            this.checkBox_x.UseVisualStyleBackColor = true;
            // 
            // label_formato_x
            // 
            this.label_formato_x.Location = new System.Drawing.Point(102, 32);
            this.label_formato_x.Name = "label_formato_x";
            this.label_formato_x.Size = new System.Drawing.Size(395, 23);
            this.label_formato_x.TabIndex = 1;
            this.label_formato_x.Text = "formato";
            this.label_formato_x.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_x_1
            // 
            this.label_x_1.AutoSize = true;
            this.label_x_1.Location = new System.Drawing.Point(12, 61);
            this.label_x_1.Name = "label1";
            this.label_x_1.Size = new System.Drawing.Size(66, 13);
            this.label_x_1.TabIndex = 2;
            this.label_x_1.Text = "Texto inicial:";
            // 
            // textBox_inicial_x
            // 
            this.textBox_inicial_x.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_x.Name = "textBox_inicial_x";
            this.textBox_inicial_x.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_x.TabIndex = 4;
            // 
            // label_tipo_x
            // 
            this.label_tipo_x.AutoSize = true;
            this.label_tipo_x.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_x.Name = "label_tipo_x";
            this.label_tipo_x.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_x.TabIndex = 6;
            this.label_tipo_x.Text = "LOG_TIPO";
            // 
            // label_x_3
            // 
            this.label_x_3.AutoSize = true;
            this.label_x_3.Location = new System.Drawing.Point(15, 15);
            this.label_x_3.Name = "label3";
            this.label_x_3.Size = new System.Drawing.Size(48, 13);
            this.label_x_3.TabIndex = 7;
            this.label_x_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_x);
        }
          
          
        /**/
    }
}
