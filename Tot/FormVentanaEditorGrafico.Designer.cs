/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 19-12-2016
 * Hora: 2:40
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Tot
{
	partial class FormVentanaEditorGrafico
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private CEditor.CEditor c_Editor1;
		private System.Windows.Forms.TabControl tabArchivos;
		private System.Windows.Forms.TabPage tabVariables;
		private CEditor.CEditorListaVariables listaVariables;
		private System.Windows.Forms.TabPage tabContexto;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.ListView lstContextos;
		private System.Windows.Forms.Label lblContexto;
		private System.Windows.Forms.ContextMenuStrip menuContextos;
		private System.Windows.Forms.ToolStripMenuItem nuevoContextoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem renombrarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
		
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaEditorGrafico));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblContexto = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.c_Editor1 = new CEditor.CEditor();
            this.tabArchivos = new System.Windows.Forms.TabControl();
            this.tabContexto = new System.Windows.Forms.TabPage();
            this.lstContextos = new System.Windows.Forms.ListView();
            this.menuContextos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoContextoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renombrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabVariables = new System.Windows.Forms.TabPage();
            this.listaVariables = new CEditor.CEditorListaVariables();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabArchivos.SuspendLayout();
            this.tabContexto.SuspendLayout();
            this.menuContextos.SuspendLayout();
            this.tabVariables.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblContexto);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
            this.splitContainer1.Panel1.Controls.Add(this.c_Editor1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabArchivos);
            this.splitContainer1.Size = new System.Drawing.Size(923, 516);
            this.splitContainer1.SplitterDistance = 661;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblContexto
            // 
            this.lblContexto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblContexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContexto.Location = new System.Drawing.Point(256, 5);
            this.lblContexto.Name = "lblContexto";
            this.lblContexto.Size = new System.Drawing.Size(254, 20);
            this.lblContexto.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(516, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 21);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar Reglas";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.BtnExportarClick);
            // 
            // c_Editor1
            // 
            this.c_Editor1.AutoScroll = true;
            this.c_Editor1.BaseConocimiento = null;
            this.c_Editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_Editor1.Location = new System.Drawing.Point(0, 0);
            this.c_Editor1.Name = "c_Editor1";
            this.c_Editor1.NombreContexto = "";
            this.c_Editor1.RutaCache = null;
            this.c_Editor1.Size = new System.Drawing.Size(661, 516);
            this.c_Editor1.TabIndex = 0;
            // 
            // tabArchivos
            // 
            this.tabArchivos.Controls.Add(this.tabContexto);
            this.tabArchivos.Controls.Add(this.tabVariables);
            this.tabArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabArchivos.Location = new System.Drawing.Point(0, 0);
            this.tabArchivos.Multiline = true;
            this.tabArchivos.Name = "tabArchivos";
            this.tabArchivos.SelectedIndex = 0;
            this.tabArchivos.Size = new System.Drawing.Size(252, 516);
            this.tabArchivos.TabIndex = 0;
            // 
            // tabContexto
            // 
            this.tabContexto.Controls.Add(this.lstContextos);
            this.tabContexto.Location = new System.Drawing.Point(4, 22);
            this.tabContexto.Name = "tabContexto";
            this.tabContexto.Padding = new System.Windows.Forms.Padding(3);
            this.tabContexto.Size = new System.Drawing.Size(244, 490);
            this.tabContexto.TabIndex = 1;
            this.tabContexto.Text = "Contextos";
            this.tabContexto.UseVisualStyleBackColor = true;
            // 
            // lstContextos
            // 
            this.lstContextos.ContextMenuStrip = this.menuContextos;
            this.lstContextos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContextos.Location = new System.Drawing.Point(3, 3);
            this.lstContextos.MultiSelect = false;
            this.lstContextos.Name = "lstContextos";
            this.lstContextos.Size = new System.Drawing.Size(238, 484);
            this.lstContextos.TabIndex = 0;
            this.lstContextos.UseCompatibleStateImageBehavior = false;
            this.lstContextos.View = System.Windows.Forms.View.List;
            this.lstContextos.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.LstContextosAfterLabelEdit);
            this.lstContextos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstContextosMouseDoubleClick);
            // 
            // menuContextos
            // 
            this.menuContextos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoContextoToolStripMenuItem,
            this.toolStripSeparator1,
            this.renombrarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuContextos.Name = "menuContextos";
            this.menuContextos.Size = new System.Drawing.Size(161, 76);
            // 
            // nuevoContextoToolStripMenuItem
            // 
            this.nuevoContextoToolStripMenuItem.Name = "nuevoContextoToolStripMenuItem";
            this.nuevoContextoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.nuevoContextoToolStripMenuItem.Text = "Nuevo Contexto";
            this.nuevoContextoToolStripMenuItem.Click += new System.EventHandler(this.NuevoContextoToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // renombrarToolStripMenuItem
            // 
            this.renombrarToolStripMenuItem.Name = "renombrarToolStripMenuItem";
            this.renombrarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.renombrarToolStripMenuItem.Text = "Renombrar";
            this.renombrarToolStripMenuItem.Click += new System.EventHandler(this.RenombrarToolStripMenuItemClick);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.EliminarToolStripMenuItemClick);
            // 
            // tabVariables
            // 
            this.tabVariables.Controls.Add(this.listaVariables);
            this.tabVariables.Location = new System.Drawing.Point(4, 22);
            this.tabVariables.Name = "tabVariables";
            this.tabVariables.Padding = new System.Windows.Forms.Padding(3);
            this.tabVariables.Size = new System.Drawing.Size(244, 490);
            this.tabVariables.TabIndex = 0;
            this.tabVariables.Text = "Variables";
            this.tabVariables.UseVisualStyleBackColor = true;
            // 
            // listaVariables
            // 
            this.listaVariables.BaseConocimiento = null;
            this.listaVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaVariables.Location = new System.Drawing.Point(3, 3);
            this.listaVariables.Name = "listaVariables";
            this.listaVariables.Size = new System.Drawing.Size(238, 484);
            this.listaVariables.TabIndex = 0;
            this.listaVariables.VariableDoubleClick += new CEditor.ManejadorEventoDobleClickVariable(this.ListaVariablesVariableDoubleClick);
            this.listaVariables.EstablecerConsecuente += new CEditor.ManejadorEventoEstablecerConsecuente(this.ListaVariablesEstablecerConsecuente);
            this.listaVariables.EditarVariable += new CEditor.ManejadorEventoEditarVariable(this.ListaVariablesEditarVariable);
            // 
            // FormVentanaEditorGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 516);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVentanaEditorGrafico";
            this.Text = "Editor de Reglas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentanaEditorGraficoFormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabArchivos.ResumeLayout(false);
            this.tabContexto.ResumeLayout(false);
            this.menuContextos.ResumeLayout(false);
            this.tabVariables.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
