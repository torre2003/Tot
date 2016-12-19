namespace Tot
{
    partial class ButtonInformación
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonInformación));
            this.pictureBox_boton = new System.Windows.Forms.PictureBox();
            this.imageList_boton = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_boton)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_boton
            // 
            this.pictureBox_boton.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_boton.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_boton.Name = "pictureBox_boton";
            this.pictureBox_boton.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_boton.TabIndex = 0;
            this.pictureBox_boton.TabStop = false;
            this.pictureBox_boton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_boton_MouseClick);
            this.pictureBox_boton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_boton_MouseDown);
            this.pictureBox_boton.MouseEnter += new System.EventHandler(this.pictureBox_boton_MouseEnter);
            this.pictureBox_boton.MouseLeave += new System.EventHandler(this.pictureBox_boton_MouseLeave);
            this.pictureBox_boton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_boton_MouseUp);
            // 
            // imageList_boton
            // 
            this.imageList_boton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_boton.ImageStream")));
            this.imageList_boton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_boton.Images.SetKeyName(0, "1481795762_Help_book - closed.png");
            this.imageList_boton.Images.SetKeyName(1, "1481877395_Help_book - open.png");
            this.imageList_boton.Images.SetKeyName(2, "1481795762_Help_book - over.png");
            // 
            // ButtonInformción
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_boton);
            this.Name = "ButtonInformción";
            this.Size = new System.Drawing.Size(32, 32);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_boton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_boton;
        private System.Windows.Forms.ImageList imageList_boton;
    }
}
