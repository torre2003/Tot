/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 15-12-2016
 * Hora: 12:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using SistemaExpertoLib;

namespace CEditor
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	partial class CEditorInputBox : Form {
		
		string VERDADERO ;
		string FALSO ;
		string COMPARADOR_LISTA ;
		string[] OPCIONES_NUMERICO ;
		string[] OPCIONES_NUMERICO_CONSECUENTE ;
		int INDICE_OPCION_NUMERICO_RANGO ;
		Variable variable;
		Node nodo;
		//---------------------------------------------------------------------------------
		string valorActual = "";
		/// <summary>
		/// Valor que tiene actualmente la variable que se está preguntando;
		/// </summary>
		public string ValorActual {
			set {
				valorActual = value;
			}
		}
		//---------------------------------------------------------------------------------
		string valor;
		/// <summary>
		/// Valor ingresado por el usuario.
		/// </summary>
		public string Valor {
			get {
				if(variable == null)
					throw new Exception("No se ha definido un nodo.");
				switch(variable.tipo_variable){
					case Variable.LISTA :
						valor = cmbLista.SelectedItem.ToString();
						break;
					case Variable.BOOLEANO:
						valor = rbNo.Checked ? FALSO : VERDADERO;
						break;
					case Variable.NUMERICO:						
						
						if(cmbComparador.SelectedIndex == INDICE_OPCION_NUMERICO_RANGO)
							valor = cmbComparador.SelectedItem.ToString()+" "+ numValor.Value.ToString()+" Y "+numValorAux.Value.ToString();
						else
							valor = cmbComparador.SelectedItem.ToString() + " QUE " + numValor.Value.ToString();
						break;
				}				
				return valor.ToLower();
			}
		}
		//---------------------------------------------------------------------------------
		string valorBooleano;
		/// <summary>
		/// Devuelve el valor binario selecionado por el usuario para variables tipo "BOOLEANO"
		/// </summary>
		public string ValorBooleano {
			get {
				if(variable == null)
					throw new Exception("No se ha definido un nodo.");
				if(variable.tipo_variable == Variable.BOOLEANO){
					valorBooleano = rbSi.Checked ? VERDADERO : FALSO ;
				}
				return valorBooleano;
			}
		}
		//---------------------------------------------------------------------------------
		string[] valorLista;
		/// <summary>
		/// Devuelve la opcion selecionada para variables tipo "LISTA".
		/// </summary>
		public string[] ValorLista {
			get {
				if(variable == null)
					throw new Exception("No se ha definido un nodo.");
				if(variable.tipo_variable == Variable.LISTA){
					valorLista =new string[2];
					valorLista[0] = COMPARADOR_LISTA ;
					valorLista[1] = variable.tipo_variable == Variable.LISTA ? cmbLista.SelectedItem.ToString() : null;
					
				}
				return valorLista;
			}
		}
		//---------------------------------------------------------------------------------
		CValorNumerico valorNumerico;
		/// <summary>
		/// Devuelve el valor binario selecionado por el usuario para variables tipo "BOOLEANO"
		/// </summary>
		public CValorNumerico ValorNumerico {
			get {
				if(variable == null)
					throw new Exception("No se ha definido un nodo.");
				if(variable.tipo_variable == Variable.NUMERICO){
					valorNumerico = new CValorNumerico();
					valorNumerico.Valor = (double) numValor.Value ;
					valorNumerico.ValorAux = (double) numValorAux.Value ;
					valorNumerico.Comparador = cmbComparador.SelectedItem.ToString();
				}
				return valorNumerico;
			}
		}
		//---------------------------------------------------------------------------------
		public CEditorInputBox(){
			
			InitializeComponent();
			
			//-- opciones variables booleanas ---- 
			FALSO = Hecho.OPCIONES_BOOLEANO[0] ;
			VERDADERO = Hecho.OPCIONES_BOOLEANO[1] ;
			
			//-- opcion variable lista (no soporta 'NO ES') ---- 
			COMPARADOR_LISTA = Hecho.OPCIONES_LISTA[0] ;
			
			//-- opciones  variables numericas -------------
			OPCIONES_NUMERICO = new string[Hecho.OPCIONES_NUMERICO.Length + 1] ;
			INDICE_OPCION_NUMERICO_RANGO = Hecho.OPCIONES_NUMERICO.Length ;
			for(var i = 0 ; i< Hecho.OPCIONES_NUMERICO.Length ; i++)
				OPCIONES_NUMERICO[i] = Hecho.OPCIONES_NUMERICO[i] ;	
			
			OPCIONES_NUMERICO[INDICE_OPCION_NUMERICO_RANGO] = "ENTRE";
			OPCIONES_NUMERICO_CONSECUENTE = new string[1];
			OPCIONES_NUMERICO_CONSECUENTE[0] = "IGUAL";
			
		}
		//---------------------------------------------------------------------------------
		public bool EstablecerOpcionesSegunNodo(Node nodo, bool esConsecuente = false){
			
			this.nodo = nodo;
			variable = (Variable)((CEditorVariable)nodo.UserData).Variable;
			Text = "Variable: "+variable.nombre_variable;
			switch(variable.tipo_variable){
				case Variable.BOOLEANO:
					return generarContenidoBinario();
				case Variable.LISTA:
					return generarContenidoLista();
				case Variable.NUMERICO:
					return generarContenidoNumerico(esConsecuente);
			}
			return false;
		}
		//---------------------------------------------------------------------------------
		bool generarContenidoNumerico(bool esConsecuente = false){
			
			this.tblPanelMain.Controls.Add(this.tblPanelRango, 1, 1);
			if(esConsecuente)
				this.cmbComparador.Items.AddRange(OPCIONES_NUMERICO_CONSECUENTE);
			else
				this.cmbComparador.Items.AddRange(OPCIONES_NUMERICO);				
			cmbComparador.SelectedIndex = 0;
			if(variable.rango_limitado){
				numValor.Minimum = (decimal)variable.rango_limite_inferior ;
				numValor.Maximum = (decimal) variable.rango_limite_superior;
				numValorAux.Minimum = (decimal)variable.rango_limite_inferior ;
				numValorAux.Maximum = (decimal) variable.rango_limite_superior;				
				numValor.Value = (decimal)variable.rango_limite_inferior;
				numValorAux.Value = (decimal)variable.rango_limite_superior;
			}
			return true;
		}
		//---------------------------------------------------------------------------------
		bool generarContenidoBinario(){
			
			this.tblPanelMain.Controls.Add(this.pnlBinario, 1, 1);				
			this.rbSi.Text = VERDADERO;
			this.rbNo.Text = FALSO;
			
			int count = 1;
			foreach(var outEdge in nodo.OutEdges){
				if(count > 2)
					return false;
				if(outEdge.LabelText !=null && outEdge.LabelText.Equals(VERDADERO.ToLower())){
					rbSi.Enabled = false;
					rbNo.Checked = true;
				}
				if(outEdge.LabelText !=null && outEdge.LabelText.Equals(FALSO.ToLower())){
					rbSi.Checked = true;
					rbNo.Enabled = false;
				}
				btnAceptar.Enabled = rbSi.Enabled || rbNo.Enabled;
				count++;
			}			
			return true;
		}
		//---------------------------------------------------------------------------------
		bool generarContenidoLista(){
			
			tblPanelMain.Controls.Add(this.cmbLista, 1, 1);				
			var lista = variable.listarOpciones();
			var items = new ArrayList();
			for (int i = 0; i < lista.Length; i++) {
				bool existe = false;
				foreach (var edge in nodo.OutEdges)
					existe |= edge.LabelText != null && edge.LabelText.Equals(lista[i]);
				if (!existe)
					items.Add(lista[i]);
			}		
			cmbLista.Items.Clear();
			if (items.Count > 0) {
				cmbLista.Items.AddRange(items.ToArray());
				cmbLista.SelectedIndex = 0;
				return true;
			}
			return false;			
		}
		//---------------------------------------------------------------------------------
		void CmbComparadorSelectedIndexChanged(object sender, EventArgs e){
			
			numValorAux.Enabled = cmbComparador.SelectedIndex == INDICE_OPCION_NUMERICO_RANGO ? true : false;
		}
		//---------------------------------------------------------------------------------
	}
	
	/*************************************************************/
	[Serializable]
	class CValorNumerico{
		public string Comparador{get;set;}
		public double Valor{get;set;}
		public double ValorAux{get;set;}
	}
}
