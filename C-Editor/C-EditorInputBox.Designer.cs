/*
 * Creado por SharpDevelop.
 * Usuario: ${Ivan Araya}
 * Fecha: 15-12-2016
 * Hora: 12:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CEditor
{
	partial class CEditorInputBox
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tblPanelMain;
		private System.Windows.Forms.Label lblVariable;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.ComboBox cmbLista;
		private System.Windows.Forms.TableLayoutPanel tblPanelButtons;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TableLayoutPanel pnlBinario;
		private System.Windows.Forms.RadioButton rbSi;
		private System.Windows.Forms.RadioButton rbNo;
		private System.Windows.Forms.TableLayoutPanel tblPanelRango;
		private System.Windows.Forms.ComboBox cmbComparador;
		private System.Windows.Forms.NumericUpDown numValor;
		private System.Windows.Forms.NumericUpDown numValorAux;
		private System.Windows.Forms.Label label1;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.tblPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.lblVariable = new System.Windows.Forms.Label();
			this.tblPanelButtons = new System.Windows.Forms.TableLayoutPanel();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.pnlBinario = new System.Windows.Forms.TableLayoutPanel();
			this.rbSi = new System.Windows.Forms.RadioButton();
			this.rbNo = new System.Windows.Forms.RadioButton();
			this.tblPanelRango = new System.Windows.Forms.TableLayoutPanel();
			this.cmbComparador = new System.Windows.Forms.ComboBox();
			this.numValor = new System.Windows.Forms.NumericUpDown();
			this.numValorAux = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbLista = new System.Windows.Forms.ComboBox();
			this.tblPanelMain.SuspendLayout();
			this.tblPanelButtons.SuspendLayout();
			this.pnlBinario.SuspendLayout();
			this.tblPanelRango.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numValorAux)).BeginInit();
			this.SuspendLayout();
			// 
			// tblPanelMain
			// 
			this.tblPanelMain.ColumnCount = 3;
			this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tblPanelMain.Controls.Add(this.lblVariable, 0, 0);
			this.tblPanelMain.Controls.Add(this.tblPanelButtons, 1, 2);
			//this.tblPanelMain.Controls.Add(this.pnlBinario, 1, 1);
			this.tblPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tblPanelMain.Name = "tblPanelMain";
			this.tblPanelMain.RowCount = 3;
			this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tblPanelMain.Size = new System.Drawing.Size(498, 155);
			this.tblPanelMain.TabIndex = 0;
			// 
			// lblVariable
			// 
			this.tblPanelMain.SetColumnSpan(this.lblVariable, 3);
			this.lblVariable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblVariable.Location = new System.Drawing.Point(3, 0);
			this.lblVariable.Name = "lblVariable";
			this.lblVariable.Size = new System.Drawing.Size(492, 50);
			this.lblVariable.TabIndex = 0;
			this.lblVariable.Text = "Seleccione la opción correspondiente a la condición deseada.";
			this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tblPanelButtons
			// 
			this.tblPanelButtons.ColumnCount = 2;
			this.tblPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanelButtons.Controls.Add(this.btnAceptar, 0, 0);
			this.tblPanelButtons.Controls.Add(this.btnCancelar, 1, 0);
			this.tblPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblPanelButtons.Location = new System.Drawing.Point(102, 118);
			this.tblPanelButtons.Name = "tblPanelButtons";
			this.tblPanelButtons.RowCount = 1;
			this.tblPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanelButtons.Size = new System.Drawing.Size(292, 34);
			this.tblPanelButtons.TabIndex = 3;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAceptar.Location = new System.Drawing.Point(3, 3);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(140, 23);
			this.btnAceptar.TabIndex = 1;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(149, 3);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(140, 23);
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			// 
			// pnlBinario
			// 
			this.pnlBinario.ColumnCount = 2;
			this.pnlBinario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.pnlBinario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.pnlBinario.Controls.Add(this.rbSi, 1, 0);
			this.pnlBinario.Controls.Add(this.rbNo, 1, 1);
			this.pnlBinario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBinario.Location = new System.Drawing.Point(102, 53);
			this.pnlBinario.Name = "pnlBinario";
			this.pnlBinario.RowCount = 2;
			this.pnlBinario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.pnlBinario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.pnlBinario.Size = new System.Drawing.Size(292, 59);
			this.pnlBinario.TabIndex = 4;
			// 
			// rbSi
			// 
			this.rbSi.Checked = true;
			this.rbSi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rbSi.Location = new System.Drawing.Point(90, 3);
			this.rbSi.Name = "rbSi";
			this.rbSi.Size = new System.Drawing.Size(199, 23);
			this.rbSi.TabIndex = 0;
			this.rbSi.TabStop = true;
			this.rbSi.UseVisualStyleBackColor = true;
			// 
			// rbNo
			// 
			this.rbNo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rbNo.Location = new System.Drawing.Point(90, 32);
			this.rbNo.Name = "rbNo";
			this.rbNo.Size = new System.Drawing.Size(199, 24);
			this.rbNo.TabIndex = 1;
			this.rbNo.TabStop = true;
			this.rbNo.UseVisualStyleBackColor = true;
			// 
			// tblPanelRango
			// 
			this.tblPanelRango.ColumnCount = 3;
			this.tblPanelRango.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
			this.tblPanelRango.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
			this.tblPanelRango.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
			this.tblPanelRango.Controls.Add(this.cmbComparador, 0, 1);
			this.tblPanelRango.Controls.Add(this.numValor, 1, 1);
			this.tblPanelRango.Controls.Add(this.numValorAux, 2, 1);
			this.tblPanelRango.Controls.Add(this.label1, 0, 0);
			this.tblPanelRango.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblPanelRango.Location = new System.Drawing.Point(102, 53);
			this.tblPanelRango.Name = "tblPanelRango";
			this.tblPanelRango.RowCount = 2;
			this.tblPanelRango.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanelRango.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanelRango.Size = new System.Drawing.Size(292, 59);
			this.tblPanelRango.TabIndex = 4;
			// 
			// cmbComparador
			// 
			this.cmbComparador.FormattingEnabled = true;
			this.cmbComparador.Location = new System.Drawing.Point(3, 32);
			this.cmbComparador.Name = "cmbComparador";
			this.cmbComparador.Size = new System.Drawing.Size(91, 21);
			this.cmbComparador.TabIndex = 0;
			this.cmbComparador.SelectedIndexChanged += new System.EventHandler(this.CmbComparadorSelectedIndexChanged);
			// 
			// numValor
			// 
			this.numValor.Location = new System.Drawing.Point(100, 32);
			this.numValor.Name = "numValor";
			this.numValor.Size = new System.Drawing.Size(91, 20);
			this.numValor.TabIndex = 1;
			// 
			// numValorAux
			// 
			this.numValorAux.Enabled = false;
			this.numValorAux.Location = new System.Drawing.Point(197, 32);
			this.numValorAux.Name = "numValorAux";
			this.numValorAux.Size = new System.Drawing.Size(92, 20);
			this.numValorAux.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 29);
			this.label1.TabIndex = 3;
			this.label1.Text = "Comparador";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbLista
			// 
			this.cmbLista.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbLista.FormattingEnabled = true;
			this.cmbLista.Location = new System.Drawing.Point(102, 73);
			this.cmbLista.Name = "cmbLista";
			this.cmbLista.Size = new System.Drawing.Size(292, 21);
			this.cmbLista.TabIndex = 3;
			// 
			// CEditorInputBox
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 155);
			this.ControlBox = false;
			this.Controls.Add(this.tblPanelMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CEditorInputBox";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Form1";
			this.tblPanelMain.ResumeLayout(false);
			this.tblPanelButtons.ResumeLayout(false);
			this.pnlBinario.ResumeLayout(false);
			this.tblPanelRango.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numValorAux)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
