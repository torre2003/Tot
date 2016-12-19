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
	partial class CEditor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		private GViewer gViewer;
		private System.Windows.Forms.Timer timerAddEdge;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditor));
			this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
			this.timerAddEdge = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// gViewer
			// 
			this.gViewer.AllowDrop = true;
			this.gViewer.ArrowheadLength = 10D;
			this.gViewer.AsyncLayout = false;
			this.gViewer.AutoScroll = true;
			this.gViewer.BackColor = System.Drawing.Color.White;
			this.gViewer.BackwardEnabled = true;
			this.gViewer.BuildHitTree = true;
			this.gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.SugiyamaScheme;
			this.gViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gViewer.EdgeInsertButtonVisible = true;
			this.gViewer.FileName = "";
			this.gViewer.ForwardEnabled = true;
			this.gViewer.Graph = null;
			this.gViewer.InsertingEdge = false;
			this.gViewer.LayoutAlgorithmSettingsButtonVisible = false;
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
			this.gViewer.SaveAsImageEnabled = false;
			this.gViewer.SaveAsMsaglEnabled = false;
			this.gViewer.SaveButtonVisible = false;
			this.gViewer.SaveGraphButtonVisible = false;
			this.gViewer.SaveInVectorFormatEnabled = false;
			this.gViewer.Size = new System.Drawing.Size(725, 426);
			this.gViewer.TabIndex = 0;
			this.gViewer.TightOffsetForRouting = 0.125D;
			this.gViewer.ToolBarIsVisible = true;
			this.gViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer.Transform")));
			this.gViewer.UndoRedoButtonsVisible = true;
			this.gViewer.WindowZoomButtonPressed = false;
			this.gViewer.ZoomF = 1D;
			this.gViewer.ZoomWindowThreshold = 0.05D;
			this.gViewer.EdgeAdded += new System.EventHandler(this.GViewerEdgeAdded);
			this.gViewer.DoubleClick += new System.EventHandler(this.GViewerDoubleClick);
			this.gViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewerKeyDown);
			// 
			// timerAddEdge
			// 
			this.timerAddEdge.Tick += new System.EventHandler(this.TimerTick);
			// 
			// CEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.gViewer);
			this.Name = "CEditor";
			this.Size = new System.Drawing.Size(725, 426);
			this.ResumeLayout(false);

		}
	}
}
