/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 24-11-2016
 * Hora: 23:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace CEditor
{
	
	/// <summary>
	/// Editor gráfico de reglas.
	/// </summary>
	public partial class C_Editor : UserControl
	{
		
		string nombreContexto = "" ;
		/// <summary>
		/// Especifica un nombre para el conjunto de reglas creadas en el editor.
		/// </summary>
		public string NombreContexto {
			get {
				return nombreContexto;
			}
			set {
				nombreContexto = value;
				cargarCache();
			}
		}
		
		string rutaCache = @"\cache\";
		/// <summary>
		/// Especifica la ruta relativa a la aplicación donde se almacena el archivo de respaldo correspondiente al grafico del conjunto de reglas.
		/// El archivo se guarda en formato .msagl.
		/// (por defecto la ruta es "rutaAplicacion\cache\") 		
		/// </summary>
		public string RutaCache {
			get {
				return rutaCache ;
			}
			set {
				rutaCache = value;
				cargarCache();
			}
		}
		
		/// <summary>
		/// Especifica el grafico que representa el conjunto de reglas.
		/// </summary>
		public Graph Grafico {get;set;}
		
		
		/// <summary>
		/// Se produce cuando el conjunto de reglas ha cambiado.y
		/// </summary>
		public event EventHandler Changed;
		
		//---------------------------------------------------------------------------------	
		public C_Editor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			Grafico = new Microsoft.Msagl.Drawing.Graph("graph");
			
			

		}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Agrega una variable al conjunto de reglas.
		/// </summary>
		public void AgregarVariable(string NombreVariable){
			
			Grafico.AddNode(NombreVariable);
			actualizar();	
			
		}
		//---------------------------------------------------------------------------------
		//public agregarCondicion(string nombreVariable, string valor, string )
		//---------------------------------------------------------------------------------
		private void guardarCache(){
			
			if(nombreContexto == ""){
				throw new Exception("No se ha definido un nombre para el contexto");
			}
			string ruta = Application.StartupPath + rutaCache ;
			string archivo = ruta + NombreContexto ;
			if(Directory.Exists(ruta))
				Grafico.Write(archivo);
			else{
				Directory.CreateDirectory(ruta);
				Grafico.Write(archivo);
			}
		}//---------------------------------------------------------------------------------
		private void cargarCache(){
			
			string ruta = Application.StartupPath + rutaCache ;
			string archivo = ruta + nombreContexto + ".msagl" ;
			if(Directory.Exists(ruta)){
				Grafico = Graph.Read(archivo);
				actualizar();				
			}

		}
		//---------------------------------------------------------------------------------
		private void actualizar(){
			viewer.Graph = Grafico;
			viewer.Refresh();
			OnChanged(EventArgs.Empty);
		}
		//---------------------------------------------------------------------------------
		protected virtual void OnChanged(EventArgs e) {
	        
			guardarCache();			
			if (Changed != null)
	            Changed(this, e);
	      }
		//---------------------------------------------------------------------------------
		public void dibujar(){
			
			Grafico.AddEdge("A", "B").Label = new Microsoft.Msagl.Drawing.Label("etiqueta");
			Grafico.AddEdge("B", "C");
			Grafico.AddEdge("A", "C");
			Grafico.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
			Grafico.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
			//Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
			//c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
			//c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
			
			Grafico.AddNode("variable");
			Grafico.AddEdge("C","condicion","Variable");
			
			
			viewer.Graph = Grafico ;
			viewer.Refresh();
		}
		//---------------------------------------------------------------------------------
	}
	
	
	public delegate void EventHandler(object sender, EventArgs e);
}
