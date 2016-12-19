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
		private CEditor.CEditor c_Editor1;
		private CEditor.CEditorListaVariables listaVariables;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportarReglasToolStripMenuItem;
		
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.c_Editor1 = new CEditor.CEditor();
			this.listaVariables = new CEditor.CEditorListaVariables();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportarReglasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.c_Editor1);
			this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listaVariables);
			this.splitContainer1.Panel2MinSize = 100;
			this.splitContainer1.Size = new System.Drawing.Size(925, 550);
			this.splitContainer1.SplitterDistance = 700;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 3;
			// 
			// c_Editor1
			// 
			this.c_Editor1.AllowDrop = true;
			this.c_Editor1.AutoScroll = true;
			this.c_Editor1.AutoSize = true;
			this.c_Editor1.BaseConocimiento = null;
			this.c_Editor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c_Editor1.Location = new System.Drawing.Point(0, 24);
			this.c_Editor1.Name = "c_Editor1";
			this.c_Editor1.NombreContexto = "";
			this.c_Editor1.RutaCache = "DirEditorCache";
			this.c_Editor1.Size = new System.Drawing.Size(700, 526);
			this.c_Editor1.TabIndex = 2;
			// 
			// listaVariables
			// 
			this.listaVariables.BaseConocimiento = null;
			this.listaVariables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listaVariables.Location = new System.Drawing.Point(0, 0);
			this.listaVariables.Name = "listaVariables";
			this.listaVariables.Size = new System.Drawing.Size(217, 550);
			this.listaVariables.TabIndex = 2;
			this.listaVariables.VariableDoubleClick += new CEditor.ManejadorEventoDobleClickVariable(this.ListaVariablesVariableDoubleClick);
			this.listaVariables.EstablecerConsecuente += new CEditor.ManejadorEventoEstablecerConsecuente(this.ListaVariablesEstablecerConsecuente);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.archivoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(700, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.exportarReglasToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";
			// 
			// exportarReglasToolStripMenuItem
			// 
			this.exportarReglasToolStripMenuItem.Name = "exportarReglasToolStripMenuItem";
			this.exportarReglasToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.exportarReglasToolStripMenuItem.Text = "Exportar Reglas";
			this.exportarReglasToolStripMenuItem.Click += new System.EventHandler(this.ExportarReglasToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 550);
			this.Controls.Add(this.splitContainer1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "C-Editor_Test";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
