/*
 * Creado por SharpDevelop.
 * Usuario: Marlon
 * Fecha: 11/9/2024
 * Hora: 19:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
	
namespace Computos
{
	partial class Form1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		// Importar el método para simular el arrastre de una ventana
	    [DllImport("user32.dll", CharSet = CharSet.Auto)]
	    public static extern bool ReleaseCapture();
	    [DllImport("user32.dll", CharSet = CharSet.Auto)]
	    public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
	
	    // Constantes para mover el formulario
	    private const int WM_NCLBUTTONDOWN = 0xA1;
	    private const int HTCAPTION = 0x2;
		
		
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.lbox_Datos = new System.Windows.Forms.ListBox();
            this.lbl_tagTotal = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATOS";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.BackColor = System.Drawing.Color.Silver;
            this.btn_Seleccionar.Location = new System.Drawing.Point(13, 17);
            this.btn_Seleccionar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(224, 53);
            this.btn_Seleccionar.TabIndex = 1;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseCompatibleTextRendering = true;
            this.btn_Seleccionar.UseVisualStyleBackColor = false;
            this.btn_Seleccionar.Click += new System.EventHandler(this.Btn_SeleccionarClick);
            // 
            // lbox_Datos
            // 
            this.lbox_Datos.FormattingEnabled = true;
            this.lbox_Datos.ItemHeight = 18;
            this.lbox_Datos.Location = new System.Drawing.Point(14, 122);
            this.lbox_Datos.Margin = new System.Windows.Forms.Padding(4);
            this.lbox_Datos.Name = "lbox_Datos";
            this.lbox_Datos.Size = new System.Drawing.Size(473, 256);
            this.lbox_Datos.TabIndex = 2;
            // 
            // lbl_tagTotal
            // 
            this.lbl_tagTotal.Location = new System.Drawing.Point(14, 437);
            this.lbl_tagTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tagTotal.Name = "lbl_tagTotal";
            this.lbl_tagTotal.Size = new System.Drawing.Size(117, 32);
            this.lbl_tagTotal.TabIndex = 3;
            this.lbl_tagTotal.Text = "Total";
            this.lbl_tagTotal.UseCompatibleTextRendering = true;
            // 
            // lbl_Total
            // 
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total.Location = new System.Drawing.Point(130, 437);
            this.lbl_Total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(77, 32);
            this.lbl_Total.TabIndex = 4;
            this.lbl_Total.UseCompatibleTextRendering = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Silver;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(390, 17);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(97, 32);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cerrar";
            this.btn_Cancel.UseCompatibleTextRendering = true;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_CancelClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_tagTotal);
            this.Controls.Add(this.lbox_Datos);
            this.Controls.Add(this.btn_Seleccionar);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Cómputo de Elementos";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            this.ResumeLayout(false);

		}
		
		void Form1MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			 if (e.Button == MouseButtons.Left)
	        {
	            ReleaseCapture();
	            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
	        }			
		}
		
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Label lbl_Total;
		private System.Windows.Forms.Label lbl_tagTotal;
		private System.Windows.Forms.ListBox lbox_Datos;
		private System.Windows.Forms.Button btn_Seleccionar;
		private System.Windows.Forms.Label label1;
		
		
		
	}
}
