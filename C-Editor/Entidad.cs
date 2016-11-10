/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 06-11-2016
 * Hora: 2:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace CEditor
{
	/// <summary>
	/// Representa a una entidad, objeto, variable, etc. de un dominio dado.
	/// </summary>
	public class Entidad
	{

		/// <summary>
		/// Nombre de la entidad
		/// </summary>
		public string Nombre{get;set;}
		
		public List<Entidad> Hijos{get;set;}
		
		/// <summary>
		/// Crea un anueva entidad.
		/// </summary>
		public Entidad()
		{
		}
	}
}
