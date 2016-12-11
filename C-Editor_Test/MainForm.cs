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

namespace C_Editor_Test
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			c_Editor1.NombreContexto = "variable 1" ;
			//c_Editor1.AgregarVariable("variable 1");
	
			
			//c_Editor1.dibujar();
		}
		void C_Editor1Changed(object sender, EventArgs e)
		{
	
		}

	}
}
