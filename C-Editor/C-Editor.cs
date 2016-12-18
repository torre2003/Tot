/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 24-11-2016
 * Hora: 23:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using SistemaExpertoLib;
using SistemaExpertoLib.GestionDelConocimiento;

namespace CEditor
{

	
	
	/// <summary>
	/// Editor gráfico de reglas.
	/// </summary>
	public partial class CEditor : UserControl{		
		
		
		Graph grafico;
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Gestionador de la base de conocimiento.
		/// </summary>
		[BrowsableAttribute(false)]
		public GestionadorBaseConocimiento BaseConocimiento {get;set;}
		//---------------------------------------------------------------------------------
		Variable consecuente;
		/// <summary>
		/// Variable que será determinada como consecuente en este conjunto de reglas. Si no se especifica, la primera variable ingresada
		/// será considerada el consecuente.
		/// Se puede cambiar esta variable usando el método "EstablecerConsecuente()", siempre y cuando la nueva variable establecida
		/// se pueda utilizar como consecuente según el grafico, es decir, que no se haya utilizado como antecedente.
		/// </summary>
		[BrowsableAttribute(false)]
		public Variable Consecuente {
			get {
				return consecuente;
			}
		}
		//---------------------------------------------------------------------------------
		readonly Color colorConsecuente;
		/// <summary>
		/// Color de los nodos que representen variables en el consecuente de una regla.
		/// </summary>
		/// 
		[BrowsableAttribute(false)]
		public Color ColorConsecuente {
			get {
				return colorConsecuente;
			}
		}
		//---------------------------------------------------------------------------------
		string nombreContexto = "" ;		
		/// <summary>
		/// Especifica un nombre para el conjunto de reglas creadas en el editor.
		/// </summary>
		[Description("Especifica un nombre para el conjunto de reglas creadas en el editor."),Category("BaseConocimiento")] 
		public string NombreContexto {
			get {
				return nombreContexto;
			}
			set {
				nombreContexto = value;
				cargarCache();
			}
		}
		//---------------------------------------------------------------------------------
		string rutaCache;
		/// <summary>
		/// Especifica la ruta relativa a la aplicación donde se almacena el archivo de respaldo correspondiente al grafico del conjunto de reglas.
		/// El archivo se guarda en formato .msagl.
		/// (por defecto la ruta es "rutaAplicacion\EditorCache\") 		
		/// </summary>
		[Description("Especifica la ruta relativa a la aplicación donde se almacena el archivo de respaldo correspondiente al grafico del conjunto de reglas."),Category("BaseConocimiento")] 
		public string RutaCache {
			get {
				return rutaCache ;
			}
			set {
				rutaCache = value;
				cargarCache();
			}
		}	
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Se produce cuando el conjunto de reglas ha cambiado.
		/// </summary>
		[Description("Se produce cuando el conjunto de reglas ha cambiado."), Category("Reglas")] 
		public event ManejadorEventoCambio Changed;
		protected virtual void OnChanged(EventArgs e) {	        
			guardarCache();			
			if (Changed != null)
	            Changed(this, e);
	    }
		
	//***  METODOS  *******************************************************************************************//	
		public CEditor(){

			InitializeComponent();
			grafico = new Microsoft.Msagl.Drawing.Graph("graph");
			colorConsecuente = Color.Gold;

		}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Agrega una variable al conjunto de reglas.
		/// </summary>
		/// <param name="variable">Variable a agregar.</param>
		public void AgregarVariable(Variable variable){
			
			deseleccionar();
			string nuevoId = variable.nombre_variable + DateTime.Now.TimeOfDay.ToString();
			var nodo = grafico.AddNode(nuevoId);
			nodo.LabelText = variable.nombre_variable;
			nodo.UserData = new CEditorVariable(variable);
			if(consecuente == null)
				consecuente = variable;
			if(variable.id_variable.Equals(consecuente.id_variable))
				nodo.Attr.FillColor = ColorConsecuente;
			actualizar();			
		}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Exporta la reglas a la base de conocimiento para que estén disponibles en el sistema.
		/// </summary>
		public void ExportarReglas(){
			
			var nodosIniciales = new List<Node>();
			foreach(var nodo in grafico.Nodes){
				bool tieneAntecesores = false;
				foreach(var inEdge in nodo.InEdges){
					tieneAntecesores = true;
					break;
				}
				if(!tieneAntecesores)
					nodosIniciales.Add(nodo);
			}
			var reglas = new ArrayList();
			foreach(var nodo in nodosIniciales){
				var regla = new ArrayList();
				regla.Add((nodo.UserData as CEditorVariable).Variable.id_variable);
				foreach(var outEdge in nodo.OutEdges){
				
				}
			}

		}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Establece la variable que corresponde al consecuente de las reglas especificadas en el gráfico.
		/// </summary>
		/// <param name="nuevoConsecuente">Variable que será utilizada como consecuente.</param>
		/// <returns>true si la variable no ha sido utilizada antes como antecedente este mismo grafico, false en caso contrario.</returns>
		public bool EstablecerConsecuente(Variable nuevoConsecuente){
			
			if(!puedeSerConsecuente(nuevoConsecuente.id_variable))
				return false;
			deseleccionar();
			foreach(var entidad in gViewer.Entities){
				var dNodo = entidad as DNode;
				if(dNodo != null){
					var cVar = dNodo.Node.UserData as CEditorVariable;
					if(cVar.Variable.id_variable.Equals(consecuente.id_variable)){
						cVar.Valor = null;
						dNodo.Node.Attr.FillColor = Color.White;
						dNodo.Node.LabelText = cVar.Variable.nombre_variable;
					}
					if(cVar.Variable.id_variable.Equals(nuevoConsecuente.id_variable))
					   dNodo.Node.Attr.FillColor = ColorConsecuente;
				}
			}
			consecuente = nuevoConsecuente;
			actualizar();
			return true;
		}
		//---------------------------------------------------------------------------------
		bool puedeSerConsecuente(string idVariable){
			
			foreach(var entidad in gViewer.Entities){
				var dNodo = entidad as DNode;
				if(dNodo != null){
					var uv = dNodo.Node.UserData as CEditorVariable;
					if(uv.Variable.id_variable.Equals(idVariable)){
						foreach(var outEdge in dNodo.OutEdges){
							if(outEdge.Target != null)
								return false;
						}
					}
				}
			}
			return true;
		}
		//---------------------------------------------------------------------------------
		void deseleccionar(){
			var sel = obtenerObjetoSelecionado();
			if (sel is IViewerNode) {
				sel.MarkedForDragging = false;
				var selec = sel as DNode;
				selec.DrawingNode.Attr.LineWidth = 1;
			}
		}
		//---------------------------------------------------------------------------------
		IViewerObject obtenerObjetoSelecionado(){
			
			foreach (var en in gViewer.Entities){
				if (en.MarkedForDragging)
					return en;
				var dEdge = en as DEdge;
				if (dEdge != null){
					if (dEdge.SelectedForEditing)
						return en;
				}
			}
			return null;
		}
		//---------------------------------------------------------------------------------
		bool existeConexionHaciaCostado(Microsoft.Msagl.Drawing.Edge edge, Node targetNode){
			
			foreach(var inEdge in edge.SourceNode.InEdges){
				foreach(var outEdge in inEdge.SourceNode.OutEdges){
					if(outEdge == edge)
						break;
					if(outEdge.TargetNode.Id == targetNode.Id)
						return true;
				}
			}
			return false;				
		}
		//---------------------------------------------------------------------------------
		bool existeConexionHaciaArriba(Microsoft.Msagl.Drawing.Edge edge, Node targetNode){
			
			foreach(var inEdge in edge.SourceNode.InEdges){
				if( inEdge.SourceNode.Id == targetNode.Id)
					return true;
			}
			var result = false ;
			foreach(var inEdge in edge.SourceNode.InEdges){
				result = existeConexionHaciaArriba( inEdge, targetNode);
				if(result)
					return true;					
			}
			return false;				
		}
		//---------------------------------------------------------------------------------
		void pedirValorAlCrearEdge(Edge edge){
			
			deseleccionar();
			var inputbox = new CEditorInputBox();
        	if(edge != null){        		
				if(!inputbox.EstablecerOpcionesSegunNodo(edge.SourceNode)){
					removerEdge(edge);
					return;
				}
				var result = inputbox.ShowDialog();				
				if(result == DialogResult.OK){				
					removerEdge(edge);
					grafico.AddEdge(edge.Source,inputbox.Valor,edge.Target);
				}else{
					removerEdge(edge);
				}
        	}
			timerAddEdge.Enabled = true;
		}
		//---------------------------------------------------------------------------------
		bool chequearSiEsConsecuente(Edge edge){
			
			CEditorVariable ud;
			ud = edge.SourceNode.UserData as CEditorVariable;
			if(ud.Variable.id_variable == consecuente.id_variable){
				removerEdge(edge);
				return true;
			}
			return false;
		}
		//---------------------------------------------------------------------------------
		bool existeConexionAnterior(Edge edge){
			int count = 0;
			foreach(var otherEdge in edge.SourceNode.OutEdges){
				if(otherEdge.TargetNode == edge.TargetNode)
					count++;
			}
			return count > 1;
		}
		//---------------------------------------------------------------------------------
		void removerEdge(Edge edge){
			foreach (var en in gViewer.Entities){
				var dEdge = en as IViewerEdge;
				if (dEdge != null){
					if (dEdge.Edge == edge){
						gViewer.RemoveEdge(dEdge,false);
						return ;
					}
				}
			}
		}
		//---------------------------------------------------------------------------------
		void actualizar(){
			gViewer.Graph = grafico;
			gViewer.Refresh();
			OnChanged(EventArgs.Empty);
		}
		//---------------------------------------------------------------------------------
		void guardarCache(){
			
			if(nombreContexto == "")
				throw new Exception("No se ha definido un nombre para el contexto.");
			if(rutaCache == "")
				throw new Exception("No se ha definido una ruta para el caché.");
			string ruta = Application.StartupPath + "\\" + rutaCache ;
			string archivo = ruta + "\\" + NombreContexto ;
			deseleccionar();
			if(!Directory.Exists(ruta))
				Directory.CreateDirectory(ruta);
			grafico.Write(archivo);
			guardarConfiguracion(archivo);
		}
		//---------------------------------------------------------------------------------
		void cargarCache(){
			
			string ruta = Application.StartupPath + "\\" + rutaCache ;
			string archivo = ruta + "\\" + nombreContexto + ".msagl" ;
			string config = ruta + "\\" + nombreContexto + ".config" ;
			if(Directory.Exists(ruta) && File.Exists(archivo)){
				try{
					grafico = Graph.Read(archivo);
					cargarConfiguracion(config);
				}catch(System.Xml.XmlException e){
					Console.WriteLine(e.Message);
					return;
				}
				gViewer.Graph = grafico;
				gViewer.Refresh();				
			}			
		}
		//---------------------------------------------------------------------------------
		void cargarConfiguracion(string archivo){

            if (File.Exists(archivo)){
                using (Stream stream = File.OpenRead(archivo)){
                    var deserializer = new BinaryFormatter();
					var config = deserializer.Deserialize(stream) as CEditorConfiguracion;
                    stream.Close();
                    consecuente = config.Consecuente;
                }
            }
		}
		//---------------------------------------------------------------------------------
		void guardarConfiguracion(string archivo){
			
			if (File.Exists(archivo+".config"))
                File.Delete(archivo+".config");			
			var config = new CEditorConfiguracion();
			config.Consecuente = consecuente ;
            using (Stream stream = File.OpenWrite(archivo+".config")){
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, config);
                stream.Close();
            }
		}
		//---------------------------------------------------------------------------------
		void GViewerDoubleClick(object sender, EventArgs e){
			
			var sel = obtenerObjetoSelecionado();
			deseleccionar();
        	if(sel == null)
				return ;
        	var inputbox = new CEditorInputBox();
			var dNodo = sel as DNode;
			if (dNodo != null) {
				var ud = dNodo.Node.UserData as CEditorVariable;
				if(ud.Variable.id_variable.Equals(consecuente.id_variable)){
					inputbox.EstablecerOpcionesSegunNodo(dNodo.Node);
					var result = inputbox.ShowDialog();				
					if(result == DialogResult.OK){
						dNodo.Node.LabelText = ud.Variable.nombre_variable + " : " +inputbox.Valor ;	
						((CEditorVariable)dNodo.Node.UserData).Valor = inputbox.Valor;
					}
				}
			}
			var edge = sel as DEdge ;
        	if(edge != null){        		
				var source = edge.Edge.Source;
				var target = edge.Edge.Target;
				if(edge.Label != null)
					inputbox.ValorActual = edge.Edge.LabelText;
				inputbox.EstablecerOpcionesSegunNodo(edge.Edge.SourceNode as Node);
				var result = inputbox.ShowDialog();				
				if(result == DialogResult.OK){
					var viewerEdge = sel as IViewerEdge;					
					gViewer.RemoveEdge(viewerEdge, false);					
					grafico.AddEdge(source, inputbox.Valor.ToString(), target);
				}
        	}
			actualizar();
		}
		//---------------------------------------------------------------------------------
		void ViewerKeyDown(object sender, KeyEventArgs e){
			
			var seleccionado = obtenerObjetoSelecionado();
			if(seleccionado == null)
				return ;
			if(e.KeyData == Keys.Delete){
				var viewerNode = seleccionado as IViewerNode;
				if(viewerNode != null)
					gViewer.RemoveNode(viewerNode, true);
				var viewerEdge = seleccionado as IViewerEdge;
				if(viewerEdge != null)
					gViewer.RemoveEdge(viewerEdge, true);
				OnChanged(EventArgs.Empty);
			}	   
		}
		//---------------------------------------------------------------------------------
		void GViewerEdgeAdded(object sender, EventArgs e){
			
			var edge = sender as Edge;
			if(chequearSiEsConsecuente(edge))
				return ;
			pedirValorAlCrearEdge(edge);
			if(existeConexionAnterior(edge))
				removerEdge(edge);
			if(existeConexionHaciaArriba(edge,edge.TargetNode))
				removerEdge(edge);
			if(existeConexionHaciaCostado(edge,edge.TargetNode))
				removerEdge(edge);
			if(edge.SourceNode.LabelText.Equals(edge.TargetNode.LabelText))
				removerEdge(edge);
		}
		//---------------------------------------------------------------------------------
		void TimerTick(object sender, EventArgs e){
			actualizar();
			timerAddEdge.Enabled = false;
		}
		//---------------------------------------------------------------------------------
	}		
	/*************************************************************************************************/	
	[Serializable]
	public class CEditorVariable{
		public string Valor {get;set;}
		public Variable Variable{get;set;}
		public CEditorVariable(Variable variable){
			Variable = variable;
		}
	}
	/*************************************************************************************************/
	[Serializable]
	public class CEditorConfiguracion{
		public Variable Consecuente{get;set;}
	}
	/*** Delegados ***********************************************************************************/	
	public delegate void ManejadorEventoCambio(object sender, EventArgs e);	
	/*************************************************************************************************/
}
