/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 13-12-2016
 * Hora: 16:54
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CEditor
{
	partial class CEditorListaVariables
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ContextMenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem establecerComoConcecuenteToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditorListaVariables));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.establecerComoConcecuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// images
			// 
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			this.images.Images.SetKeyName(0, "icoBin2.png");
			this.images.Images.SetKeyName(1, "icoList.png");
			this.images.Images.SetKeyName(2, "icoNum.png");
			// 
			// listView
			// 
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3});
			this.listView.ContextMenuStrip = this.menu;
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.LargeImageList = this.images;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(382, 412);
			this.listView.SmallImageList = this.images;
			this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListViewItemDrag);
			this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewMouseClick);
			this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewMouseDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Variable";
			this.columnHeader1.Width = 128;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ID";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Check";
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.editarToolStripMenuItem,
			this.establecerComoConcecuenteToolStripMenuItem});
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(235, 70);
			// 
			// editarToolStripMenuItem
			// 
			this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
			this.editarToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.editarToolStripMenuItem.Text = "Editar";
			this.editarToolStripMenuItem.Click += new System.EventHandler(this.EditarToolStripMenuItemClick);
			// 
			// establecerComoConcecuenteToolStripMenuItem
			// 
			this.establecerComoConcecuenteToolStripMenuItem.Name = "establecerComoConcecuenteToolStripMenuItem";
			this.establecerComoConcecuenteToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.establecerComoConcecuenteToolStripMenuItem.Text = "Establecer como Concecuente";
			this.establecerComoConcecuenteToolStripMenuItem.Click += new System.EventHandler(this.EstablecerComoConcecuenteToolStripMenuItemClick);
			// 
			// CEditorListaVariables
			// 
			this.Controls.Add(this.listView);
			this.Name = "CEditorListaVariables";
			this.Size = new System.Drawing.Size(382, 412);
			this.menu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
