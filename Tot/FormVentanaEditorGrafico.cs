/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 19-12-2016
 * Hora: 2:40
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SistemaExpertoLib.GestionDelConocimiento;

namespace Tot
{
	/// <summary>
	/// Description of FormVentanaEditorGrafico.
	/// </summary>
	public partial class FormVentanaEditorGrafico : Form
	{

		string nombreContextoAnterior = "";
		GestionadorBaseConocimiento baseConocimiento ;
		public FormVentanaEditorGrafico()
		{

			InitializeComponent();
			baseConocimiento = new GestionadorBaseConocimiento();
			if (!baseConocimiento.existe_base_de_conocimiento) {
				baseConocimiento.iniciarNuevaBaseDeConocimiento();
				MessageBox.Show("La base de conocimiento no ha sido creada.\n Se ha creado una nueva base de conocimiento vacia", "Gestión Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			
			c_Editor1.BaseConocimiento = baseConocimiento;
			c_Editor1.RutaCache = baseConocimiento.ruta_carpeta_base_conocimiento + "\\DirEditorCache";
			listaVariables.BaseConocimiento = baseConocimiento;
			listaVariables.MostrarVariables();
			
			cargarContextos();

		}
		//--------------------------------------------------------------------------------------------
		void cargarContextos(){
			lstContextos.Items.Clear();
			var di = new DirectoryInfo(c_Editor1.RutaCache);
			foreach (var fi in di.GetFiles("*.msagl")) {
				var fileName = fi.Name.Split('.');
				lstContextos.Items.Add(fileName[0]);
			}
		}
		//--------------------------------------------------------------------------------------------
		void FormVentanaEditorGraficoFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Visible = false;
		}
		//--------------------------------------------------------------------------------------------
		void ListaVariablesEstablecerConsecuente(SistemaExpertoLib.Variable variable, EventArgs e)
		{
			if (!c_Editor1.EstablecerConsecuente(variable))
				MessageBox.Show("No se puede establer " + variable.nombre_variable + " como consecuente debido a que está establecida como antecedente");
		}
		//--------------------------------------------------------------------------------------------
		void ListaVariablesVariableDoubleClick(SistemaExpertoLib.Variable variable, MouseEventArgs e)
		{
			if (c_Editor1.NombreContexto.Equals("")) {
				MessageBox.Show("Seleccione un contexto", "Contexto");
				return;
			}
			
			c_Editor1.AgregarVariable(variable);
		}
		//--------------------------------------------------------------------------------------------
		void BtnExportarClick(object sender, EventArgs e)
		{
			if (!c_Editor1.ExportarReglas()) {
				MessageBox.Show("Verifique la variable consecuente tenga todos los valores asociados");
				return;
			}
			var Reglas = c_Editor1.Reglas;
			
			string log = "" ;
			
			foreach(var regla in Reglas){
				var result = baseConocimiento.agregarNuevaRegla(regla.Antecedentes, regla.Consecuente);
				if(result != null)
					log += result +"\n" ;
				else
					log += "regla existente\n" ;
			}
			
			MessageBox.Show(log,"Reglas");
		}
		//--------------------------------------------------------------------------------------------
		void ListaVariablesEditarVariable(SistemaExpertoLib.Variable variable, EventArgs e)
		{
			
		}
		//--------------------------------------------------------------------------------------------
		void NuevoContextoToolStripMenuItemClick(object sender, EventArgs e)
		{
			var item = lstContextos.Items.Add("nuevo");
			c_Editor1.nuevoGrafico("nuevo");
			
		}
		//--------------------------------------------------------------------------------------------
		void LstContextosMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lstContextos.SelectedItems.Count == 0)
				return;
			c_Editor1.NombreContexto = lstContextos.SelectedItems[0].Text;
			lblContexto.Text = c_Editor1.NombreContexto;
			c_Editor1.actualizar();
		}
		//--------------------------------------------------------------------------------------------
		void RenombrarToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (lstContextos.SelectedItems.Count == 0)
				return;
			nombreContextoAnterior = lstContextos.SelectedItems[0].Text;
			lstContextos.LabelEdit = true;
			lstContextos.SelectedItems[0].BeginEdit();
		}
		//--------------------------------------------------------------------------------------------
		void LstContextosAfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			var newName = c_Editor1.RutaCache + "\\" + e.Label;
			var fileName = c_Editor1.RutaCache + "\\" + nombreContextoAnterior;
			
			if (File.Exists(fileName + ".msagl") && File.Exists(fileName + ".config")) {
				if (!File.Exists(newName + ".msagl") && !File.Exists(newName + ".config")) {
					File.Move(fileName + ".msagl", newName + ".msagl");
					File.Move(fileName + ".config", newName + ".config");
				} else {
					MessageBox.Show("Ya existe el contexto", "Contexto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					e.CancelEdit = true;
				}
			} else {
				MessageBox.Show("No se se encontro el contexto", "Contexto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				e.CancelEdit = true;
			}

			lstContextos.LabelEdit = false;
			//cargarContextos();
		}
		//--------------------------------------------------------------------------------------------
		void EliminarToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (lstContextos.SelectedItems.Count == 0)
				return;
			var filename = c_Editor1.RutaCache + "\\" + lstContextos.SelectedItems[0].Text;
			if (File.Exists(filename + ".msagl") && File.Exists(filename + ".config")) {
				File.Delete(filename + ".msagl");
				File.Delete(filename + ".config");
			} else {
				MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			cargarContextos();
		}
		//--------------------------------------------------------------------------------------------
	}
}
