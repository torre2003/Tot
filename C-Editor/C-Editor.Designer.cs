/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 24-11-2016
 * Hora: 23:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using Microsoft.Msagl.GraphViewerGdi;
namespace CEditor
{
	partial class C_Editor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		private GViewer viewer;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_Editor));
			this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
			this.SuspendLayout();
			// 
			// viewer
			// 
			this.viewer.ArrowheadLength = 10D;
			this.viewer.AsyncLayout = false;
			this.viewer.AutoScroll = true;
			this.viewer.BackColor = System.Drawing.Color.White;
			this.viewer.BackwardEnabled = false;
			this.viewer.BuildHitTree = true;
			this.viewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.SugiyamaScheme;
			this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewer.EdgeInsertButtonVisible = true;
			this.viewer.FileName = "";
			this.viewer.ForwardEnabled = true;
			this.viewer.Graph = null;
			this.viewer.InsertingEdge = false;
			this.viewer.LayoutAlgorithmSettingsButtonVisible = false;
			this.viewer.LayoutEditingEnabled = true;
			this.viewer.Location = new System.Drawing.Point(0, 0);
			this.viewer.LooseOffsetForRouting = 0.25D;
			this.viewer.MouseHitDistance = 0.05D;
			this.viewer.Name = "viewer";
			this.viewer.NavigationVisible = true;
			this.viewer.NeedToCalculateLayout = true;
			this.viewer.OffsetForRelaxingInRouting = 0.6D;
			this.viewer.PaddingForEdgeRouting = 8D;
			this.viewer.PanButtonPressed = false;
			this.viewer.SaveAsImageEnabled = false;
			this.viewer.SaveAsMsaglEnabled = true;
			this.viewer.SaveButtonVisible = true;
			this.viewer.SaveGraphButtonVisible = true;
			this.viewer.SaveInVectorFormatEnabled = false;
			this.viewer.Size = new System.Drawing.Size(725, 426);
			this.viewer.TabIndex = 0;
			this.viewer.TightOffsetForRouting = 0.125D;
			this.viewer.ToolBarIsVisible = true;
			this.viewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("viewer.Transform")));
			this.viewer.UndoRedoButtonsVisible = true;
			this.viewer.WindowZoomButtonPressed = false;
			this.viewer.ZoomF = 1D;
			this.viewer.ZoomWindowThreshold = 0.05D;
			// 
			// C_Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.viewer);
			this.Name = "C_Editor";
			this.Size = new System.Drawing.Size(725, 426);
			this.ResumeLayout(false);

		}
	}
}
