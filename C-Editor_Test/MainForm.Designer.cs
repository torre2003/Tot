/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 24-11-2016
 * Hora: 23:31
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace C_Editor_Test
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private CEditor.C_Editor c_Editor1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.c_Editor1 = new CEditor.C_Editor();
			this.SuspendLayout();
			// 
			// c_Editor1
			// 
			this.c_Editor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c_Editor1.Location = new System.Drawing.Point(0, 0);
			this.c_Editor1.Name = "c_Editor1";
			this.c_Editor1.RutaCache = "\\cache\\";
			this.c_Editor1.Size = new System.Drawing.Size(761, 480);
			this.c_Editor1.TabIndex = 0;
			this.c_Editor1.Changed += new CEditor.EventHandler(this.C_Editor1Changed);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(761, 480);
			this.Controls.Add(this.c_Editor1);
			this.Name = "MainForm";
			this.Text = "C-Editor_Test";
			this.ResumeLayout(false);

		}
	}
}
