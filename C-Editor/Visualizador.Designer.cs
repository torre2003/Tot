/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 06-11-2016
 * Hora: 2:33
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CEditor
{
	partial class Visualizador
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizador));
			this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
			this.SuspendLayout();
			// 
			// gViewer
			// 
			this.gViewer.ArrowheadLength = 10D;
			this.gViewer.AsyncLayout = false;
			this.gViewer.AutoScroll = true;
			this.gViewer.BackwardEnabled = false;
			this.gViewer.BuildHitTree = true;
			this.gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
			this.gViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gViewer.EdgeInsertButtonVisible = true;
			this.gViewer.FileName = "";
			this.gViewer.ForwardEnabled = false;
			this.gViewer.Graph = null;
			this.gViewer.InsertingEdge = false;
			this.gViewer.LayoutAlgorithmSettingsButtonVisible = true;
			this.gViewer.LayoutEditingEnabled = true;
			this.gViewer.Location = new System.Drawing.Point(0, 0);
			this.gViewer.LooseOffsetForRouting = 0.25D;
			this.gViewer.MouseHitDistance = 0.05D;
			this.gViewer.Name = "gViewer";
			this.gViewer.NavigationVisible = true;
			this.gViewer.NeedToCalculateLayout = true;
			this.gViewer.OffsetForRelaxingInRouting = 0.6D;
			this.gViewer.PaddingForEdgeRouting = 8D;
			this.gViewer.PanButtonPressed = false;
			this.gViewer.SaveAsImageEnabled = true;
			this.gViewer.SaveAsMsaglEnabled = true;
			this.gViewer.SaveButtonVisible = true;
			this.gViewer.SaveGraphButtonVisible = true;
			this.gViewer.SaveInVectorFormatEnabled = true;
			this.gViewer.Size = new System.Drawing.Size(553, 302);
			this.gViewer.TabIndex = 0;
			this.gViewer.TightOffsetForRouting = 0.125D;
			this.gViewer.ToolBarIsVisible = true;
			this.gViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer.Transform")));
			this.gViewer.UndoRedoButtonsVisible = true;
			this.gViewer.WindowZoomButtonPressed = false;
			this.gViewer.ZoomF = 1D;
			this.gViewer.ZoomWindowThreshold = 0.05D;
			// 
			// C_Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gViewer);
			this.Name = "C_Editor";
			this.Size = new System.Drawing.Size(553, 302);
			this.ResumeLayout(false);

		}
	}
}
