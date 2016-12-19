/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 13-12-2016
 * Hora: 16:54
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SistemaExpertoLib;
using SistemaExpertoLib.GestionDelConocimiento;

namespace CEditor
{
	/// <summary>
	/// Description of ListaVariables.
	/// </summary>
	public partial class CEditorListaVariables : UserControl
	{
		
		int indiceIdVariable ;
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Gestionador de la base de conocimiento.
		/// </summary>
		[BrowsableAttribute(false)]
		public GestionadorBaseConocimiento BaseConocimiento{get;set;}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Devuelve una colección con los items seleccionados.
		/// </summary>
		[BrowsableAttribute(false)]
		public ListView.SelectedListViewItemCollection SelectedItems {
			get {
				return listView.SelectedItems;
			}
		}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Devuelve una colección con los índices de los items selecionados.
		/// </summary>
		[BrowsableAttribute(false)]
		public ListView.SelectedIndexCollection SelectedIndices {
			get {
				return listView.SelectedIndices;
			}
		}
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Ocurre al hacer doble click en un item.
		/// </summary>
		[Description("Ocurre al hacer doble click en una variable."), Category("Variables")] 
		public event ManejadorEventoDobleClickVariable VariableDoubleClick;
		protected virtual void OnItemDoubleClick(MouseEventArgs e) {		
			if(SelectedItems.Count==0)
				return;
			var idVariable = SelectedItems[0].SubItems[indiceIdVariable].Text;
			var variable = BaseConocimiento.leerVariable(idVariable);
			if (VariableDoubleClick != null)
	            VariableDoubleClick(variable, e);
	    }
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Ocurre al hacer click en un item.
		/// </summary>
		[Description("Ocurre al hacer click en una variable."), Category("Variables")] 
		public event ManejadorEventoClickVariable VariableClick;
		protected virtual void OnItemClick(MouseEventArgs e) {		
			if(SelectedItems.Count==0)
				return;
			var idVariable = SelectedItems[0].SubItems[indiceIdVariable].Text;
			var variable = BaseConocimiento.leerVariable(idVariable);
			if (VariableClick != null)
	            VariableClick(variable, e);
	    }
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Ocurre al establecer una variable como consecuente.
		/// </summary>
		[Description("Ocurre al establecer una variable como consecuente."), Category("Variables")] 
		public event ManejadorEventoEstablecerConsecuente EstablecerConsecuente;
		protected virtual void OnEstablecerConsecuente(EventArgs e) {		
			if(SelectedItems.Count==0)
				return;
			var idVariable = SelectedItems[0].SubItems[indiceIdVariable].Text;
			var variable = BaseConocimiento.leerVariable(idVariable);
			if (EstablecerConsecuente != null)
	            EstablecerConsecuente(variable, e);
	    }
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Ocurre al selecionar una variable para editar.
		/// </summary>
		[Description("Ocurre al selecionar una variable para editar."), Category("Variables")] 
		public event ManejadorEventoEditarVariable EditarVariable;
		protected virtual void OnEditarVariable(EventArgs e) {		
			if(SelectedItems.Count==0)
				return;
			var idVariable = SelectedItems[0].SubItems[indiceIdVariable].Text;
			var variable = BaseConocimiento.leerVariable(idVariable);
			if (EditarVariable != null)
	            EditarVariable(variable, e);
	    }
		//---------------------------------------------------------------------------------
		/// <summary>
		/// Ocurre al arrastrar un item.
		/// </summary>
		[Description("Ocurre al arrastrar una variable."), Category("Variables")] 
		public event ManejadorEventoArrastrarVariable VariableDrag;
		protected virtual void OnItemDrag(ItemDragEventArgs e) {		
			if(SelectedItems.Count==0)
				return;
			var idVariable = SelectedItems[0].SubItems[indiceIdVariable].Text;
			var variable = BaseConocimiento.leerVariable(idVariable);
			if (VariableDrag != null)
	            VariableDrag(variable, e);
	    }
		/**************************************************************************************************/
		public CEditorListaVariables()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------
		/// <summary>
		/// Muestra el listado de variables desde la base de conocimeiento.
		/// </summary>
		public void MostrarVariables(){
			
			if(BaseConocimiento == null)
				throw new Exception("No se ha establecido la base de conocimiento a utilizar.");
			string[] id_variables = BaseConocimiento.listarVariables();
            if (id_variables != null){				
				for (int i = 0; i < id_variables.Length; i++){
					Variable variable = BaseConocimiento.leerVariable(id_variables[i]);                    
                    
                    string aux = "";
                    if (!variable.chequeo_de_consistencia)
                        aux += " (No Chequeado)";
                    if (variable.variable_de_inicio)
                        aux += " [ I ]";
                    if (variable.variable_objetivo)
                        aux += " [ O ]";
                    if (variable.variable_preguntable_al_usuario)
                        aux += " [¿?]";
                    
                    var arr = new string[3]; 
                    arr[0] = variable.nombre_variable; 
                    arr[1] = variable.id_variable;
                    arr[2] = aux; 
                    indiceIdVariable = 1;
                    
                    var elemento = new ListViewItem(arr);
                    
                    switch (variable.tipo_variable){
                        case Variable.BOOLEANO:
                            elemento.ImageIndex = 0;
                            break;
                        case Variable.NUMERICO:
                            elemento.ImageIndex = 2;
                            break;
                        case Variable.LISTA:
                            elemento.ImageIndex = 1;
                            break;
                    }

                    listView.Items.Add(elemento);
				}
            }
		}
		//------------------------------------------------------------------------
		void ListViewItemDrag(object sender, ItemDragEventArgs e){
			OnItemDrag(e);
		}
		//------------------------------------------------------------------------
		void ListViewMouseDoubleClick(object sender, MouseEventArgs e){
			OnItemDoubleClick(e);
		}
		//------------------------------------------------------------------------
		void ListViewMouseClick(object sender, MouseEventArgs e){			
			OnItemClick(e);
		}
		//------------------------------------------------------------------------
		void EditarToolStripMenuItemClick(object sender, EventArgs e){
			OnEditarVariable(e);
		}
		//------------------------------------------------------------------------
		void EstablecerComoConcecuenteToolStripMenuItemClick(object sender, EventArgs e){
			OnEstablecerConsecuente(e);
		}
		//---------------------------------------------------------------

	}
	
	public delegate void ManejadorEventoArrastrarVariable(Variable variable, ItemDragEventArgs e);
	public delegate void ManejadorEventoClickVariable (Variable variable, MouseEventArgs e);
	public delegate void ManejadorEventoDobleClickVariable (Variable variable, MouseEventArgs e);
	public delegate void ManejadorEventoEstablecerConsecuente (Variable variable, EventArgs e);
	public delegate void ManejadorEventoEditarVariable (Variable variable, EventArgs e);


}
