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
	public partial class CEditorInputBox : Form {
		
		const string VERDADERO = "si";
		const string FALSO = "no";
		const int ENTRE = 5;
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
						valor = cmbComparador.SelectedItem.ToString() + " " + numValor.Value.ToString();
						if(cmbComparador.SelectedIndex == ENTRE)
							valor += " y " + numValorAux.Value.ToString();
						break;
				}				
				return valor;
			}
		}
		//---------------------------------------------------------------------------------
		string valorLista;
		/// <summary>
		/// Devuelve la opcion selecionada para variables tipo "LISTA".
		/// </summary>
		public string ValorLista {
			get {
				if(variable == null)
					throw new Exception("No se ha definido un nodo.");
				valorLista = variable.tipo_variable == Variable.LISTA ? cmbLista.SelectedItem.ToString() : null;
				return valorLista;
			}
		}
		//---------------------------------------------------------------------------------
		bool valorBinario;
		/// <summary>
		/// Devuelve el valor binario selecionado por el usuario para variables tipo "BOOLEANO"
		/// </summary>
		public bool ValorBinario {
			get {
				if(variable == null)
					throw new Exception("No se ha definido un nodo.");
				if(variable.tipo_variable == Variable.BOOLEANO)
					valorBinario = !rbNo.Checked;
				return valorBinario;
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
		}
		//---------------------------------------------------------------------------------
		public bool EstablecerOpcionesSegunNodo(Node nodo){
			this.nodo = nodo;
			variable = (Variable)((CEditorVariable)nodo.UserData).Variable;
			Text = "Variable: "+variable.nombre_variable;
			switch(variable.tipo_variable){
				case Variable.BOOLEANO:
					return generarContenidoBinario();
				case Variable.LISTA:
					return generarContenidoLista();
				case Variable.NUMERICO:
					return generarContenidoNumerico();
			}
			return false;
		}
		//---------------------------------------------------------------------------------
		bool generarContenidoNumerico(){
			
			this.tblPanelMain.Controls.Add(this.tblPanelRango, 1, 1);
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
			int count = 1;
			foreach(var outEdge in nodo.OutEdges){
				if(count > 2)
					return false;
				if(outEdge.LabelText !=null && outEdge.LabelText.Equals(VERDADERO)){
					rbSi.Enabled = false;
					rbNo.Checked = true;
				}
				if(outEdge.LabelText !=null && outEdge.LabelText.Equals(FALSO)){
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
			
			numValorAux.Enabled = cmbComparador.SelectedIndex == ENTRE ? true : false;
		}
		//---------------------------------------------------------------------------------
	}
	
	/*************************************************************/
	public struct CValorNumerico{
		public string Comparador{get;set;}
		public double Valor{get;set;}
		public double ValorAux{get;set;}
	}
}
