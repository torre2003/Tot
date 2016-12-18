/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 24-11-2016
 * Hora: 23:31
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaExpertoLib.GestionDelConocimiento;

namespace C_Editor_Test
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{

			InitializeComponent();
			
			var gbc = new GestionadorBaseConocimiento();
			if (!gbc.existe_base_de_conocimiento){
                gbc.iniciarNuevaBaseDeConocimiento();
                MessageBox.Show("La base de conocimiento no ha sido creada.\n Se ha creado una nueva base de conocimiento vacia", "Gestión Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
			
			c_Editor1.BaseConocimiento = gbc;
			listaVariables.BaseConocimiento = gbc;
			listaVariables.MostrarVariables();
			c_Editor1.NombreContexto = "Contexto1" ;
			//c_Editor1.dibujar();

		}
		//------------------------------------------------------------------------------------------------
		void ListaVariablesVariableDoubleClick(SistemaExpertoLib.Variable variable, MouseEventArgs e){
			
			c_Editor1.AgregarVariable(variable);
		}
		//------------------------------------------------------------------------------------------------
		void ListaVariablesEstablecerConsecuente(SistemaExpertoLib.Variable variable, EventArgs e){

			if(!c_Editor1.EstablecerConsecuente(variable))
				MessageBox.Show("No se puede establer "+variable.nombre_variable+" como consecuente debido a que está establecida como antecedente");
		}
		void ExportarReglasToolStripMenuItemClick(object sender, EventArgs e)
		{
			c_Editor1.ExportarReglas();
		}
		//------------------------------------------------------------------------------------------------




	}
}
