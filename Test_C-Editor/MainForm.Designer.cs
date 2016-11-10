/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 08-11-2016
 * Hora: 2:41
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Test_C_Editor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private CEditor.Visualizador visualizador1;
		
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
			this.visualizador1 = new CEditor.Visualizador();
			this.SuspendLayout();
			// 
			// visualizador1
			// 
			this.visualizador1.Location = new System.Drawing.Point(26, 23);
			this.visualizador1.Name = "visualizador1";
			this.visualizador1.Propiedad = 0;
			this.visualizador1.Size = new System.Drawing.Size(484, 386);
			this.visualizador1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 457);
			this.Controls.Add(this.visualizador1);
			this.Name = "MainForm";
			this.Text = "Test_C-Editor";
			this.ResumeLayout(false);

		}
	}
}
