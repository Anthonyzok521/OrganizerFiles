/*
 * Creado por SharpDevelop.
 * Usuario: Anthony
 * Fecha: 11/01/2021
 * Hora: 06:34 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace OrganizerFiles
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox Direccion;
		private System.Windows.Forms.ListBox Lista;
		private System.Windows.Forms.CheckBox MostrarArchivos;
		private System.Windows.Forms.CheckBox CarpetasSubCarpetas;
		private System.Windows.Forms.Button Eliminar;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.RadioButton EncarpetarSinE;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton Encarpetar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox Minimizar;
		private System.Windows.Forms.PictureBox Salir;
		private System.Windows.Forms.PictureBox Buscar;
		private System.Windows.Forms.PictureBox LimpiarLista;
		private System.Windows.Forms.PictureBox OrganizarArchivos;
		private System.Windows.Forms.Label labelLimpiar;
		private System.Windows.Forms.Label labelAbrir;
		private System.Windows.Forms.Label labelOrganizar;
		private System.Windows.Forms.PictureBox AbrirCarpetas;
		private System.Windows.Forms.Button BotonSpEn;
		
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
			this.components = new System.ComponentModel.Container();
			this.Direccion = new System.Windows.Forms.TextBox();
			this.Lista = new System.Windows.Forms.ListBox();
			this.MostrarArchivos = new System.Windows.Forms.CheckBox();
			this.CarpetasSubCarpetas = new System.Windows.Forms.CheckBox();
			this.Eliminar = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.EncarpetarSinE = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.Encarpetar = new System.Windows.Forms.RadioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.BotonSpEn = new System.Windows.Forms.Button();
			this.Minimizar = new System.Windows.Forms.PictureBox();
			this.Salir = new System.Windows.Forms.PictureBox();
			this.Buscar = new System.Windows.Forms.PictureBox();
			this.LimpiarLista = new System.Windows.Forms.PictureBox();
			this.OrganizarArchivos = new System.Windows.Forms.PictureBox();
			this.labelLimpiar = new System.Windows.Forms.Label();
			this.labelAbrir = new System.Windows.Forms.Label();
			this.labelOrganizar = new System.Windows.Forms.Label();
			this.AbrirCarpetas = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Minimizar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Buscar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LimpiarLista)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OrganizarArchivos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AbrirCarpetas)).BeginInit();
			this.SuspendLayout();
			// 
			// Direccion
			// 
			this.Direccion.BackColor = System.Drawing.Color.White;
			this.Direccion.ForeColor = System.Drawing.Color.Black;
			this.Direccion.Location = new System.Drawing.Point(6, 169);
			this.Direccion.Name = "Direccion";
			this.Direccion.Size = new System.Drawing.Size(279, 20);
			this.Direccion.TabIndex = 0;
			this.Direccion.Text = "Escribe la ruta aquí o click en la lupa.";
			// 
			// Lista
			// 
			this.Lista.BackColor = System.Drawing.SystemColors.InfoText;
			this.Lista.Cursor = System.Windows.Forms.Cursors.Default;
			this.Lista.ForeColor = System.Drawing.Color.White;
			this.Lista.FormattingEnabled = true;
			this.Lista.HorizontalScrollbar = true;
			this.Lista.Items.AddRange(new object[] {
			"---------------------------------------------------------------------------------" +
				"--------------------------",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"|\t\t\t\t\t\t|",
			"---------------------------------------------------------------------------------" +
				"--------------------------"});
			this.Lista.Location = new System.Drawing.Point(6, 285);
			this.Lista.Name = "Lista";
			this.Lista.ScrollAlwaysVisible = true;
			this.Lista.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.Lista.Size = new System.Drawing.Size(313, 173);
			this.Lista.TabIndex = 3;
			this.Lista.Tag = "LIST";
			// 
			// MostrarArchivos
			// 
			this.MostrarArchivos.BackColor = System.Drawing.Color.Transparent;
			this.MostrarArchivos.Checked = true;
			this.MostrarArchivos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MostrarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.MostrarArchivos.ForeColor = System.Drawing.Color.Black;
			this.MostrarArchivos.Location = new System.Drawing.Point(3, 32);
			this.MostrarArchivos.Name = "MostrarArchivos";
			this.MostrarArchivos.Size = new System.Drawing.Size(313, 24);
			this.MostrarArchivos.TabIndex = 5;
			this.MostrarArchivos.Text = "Mostrar cantidad de archivos hallados según su extención.";
			this.MostrarArchivos.UseVisualStyleBackColor = false;
			this.MostrarArchivos.Visible = false;
			// 
			// CarpetasSubCarpetas
			// 
			this.CarpetasSubCarpetas.BackColor = System.Drawing.Color.Transparent;
			this.CarpetasSubCarpetas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CarpetasSubCarpetas.ForeColor = System.Drawing.Color.Black;
			this.CarpetasSubCarpetas.Location = new System.Drawing.Point(3, 32);
			this.CarpetasSubCarpetas.Name = "CarpetasSubCarpetas";
			this.CarpetasSubCarpetas.Size = new System.Drawing.Size(323, 24);
			this.CarpetasSubCarpetas.TabIndex = 7;
			this.CarpetasSubCarpetas.Text = "Examinar carpetas y subcarpetas. (Esta acción tarda un poco)";
			this.CarpetasSubCarpetas.UseVisualStyleBackColor = false;
			// 
			// Eliminar
			// 
			this.Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Eliminar.FlatAppearance.BorderSize = 0;
			this.Eliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
			this.Eliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
			this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Eliminar.ForeColor = System.Drawing.Color.Black;
			this.Eliminar.Location = new System.Drawing.Point(84, 1);
			this.Eliminar.Name = "Eliminar";
			this.Eliminar.Size = new System.Drawing.Size(138, 23);
			this.Eliminar.TabIndex = 9;
			this.Eliminar.Text = "*OrganizerFiles v1.2*";
			this.Eliminar.UseVisualStyleBackColor = true;
			this.Eliminar.Click += new System.EventHandler(this.EliminarClick);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(6, 195);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(307, 23);
			this.progressBar1.TabIndex = 10;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// EncarpetarSinE
			// 
			this.EncarpetarSinE.BackColor = System.Drawing.Color.Transparent;
			this.EncarpetarSinE.Cursor = System.Windows.Forms.Cursors.Hand;
			this.EncarpetarSinE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EncarpetarSinE.ForeColor = System.Drawing.Color.Black;
			this.EncarpetarSinE.Location = new System.Drawing.Point(5, 135);
			this.EncarpetarSinE.Name = "EncarpetarSinE";
			this.EncarpetarSinE.Size = new System.Drawing.Size(280, 24);
			this.EncarpetarSinE.TabIndex = 18;
			this.EncarpetarSinE.TabStop = true;
			this.EncarpetarSinE.Text = "Encarpetar sin importar extensión.";
			this.EncarpetarSinE.UseVisualStyleBackColor = false;
			this.EncarpetarSinE.CheckedChanged += new System.EventHandler(this.EncarpetarSinECheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.BackColor = System.Drawing.Color.Transparent;
			this.radioButton3.Checked = true;
			this.radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.radioButton3.ForeColor = System.Drawing.Color.Black;
			this.radioButton3.Location = new System.Drawing.Point(5, 74);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(100, 24);
			this.radioButton3.TabIndex = 19;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "No encarpetar.";
			this.radioButton3.UseVisualStyleBackColor = false;
			// 
			// Encarpetar
			// 
			this.Encarpetar.BackColor = System.Drawing.Color.Transparent;
			this.Encarpetar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Encarpetar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Encarpetar.ForeColor = System.Drawing.Color.Black;
			this.Encarpetar.Location = new System.Drawing.Point(5, 105);
			this.Encarpetar.Name = "Encarpetar";
			this.Encarpetar.Size = new System.Drawing.Size(280, 24);
			this.Encarpetar.TabIndex = 21;
			this.Encarpetar.TabStop = true;
			this.Encarpetar.Text = "Encarpetar según su extensión.";
			this.Encarpetar.UseVisualStyleBackColor = false;
			this.Encarpetar.CheckedChanged += new System.EventHandler(this.EncarpetarCheckedChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
			this.panel1.Controls.Add(this.BotonSpEn);
			this.panel1.Controls.Add(this.Minimizar);
			this.panel1.Controls.Add(this.Salir);
			this.panel1.Controls.Add(this.Eliminar);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(320, 26);
			this.panel1.TabIndex = 23;
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseDown);
			// 
			// BotonSpEn
			// 
			this.BotonSpEn.BackColor = System.Drawing.Color.White;
			this.BotonSpEn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BotonSpEn.FlatAppearance.BorderSize = 0;
			this.BotonSpEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
			this.BotonSpEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
			this.BotonSpEn.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BotonSpEn.ForeColor = System.Drawing.Color.Black;
			this.BotonSpEn.Location = new System.Drawing.Point(0, 0);
			this.BotonSpEn.Name = "BotonSpEn";
			this.BotonSpEn.Size = new System.Drawing.Size(32, 26);
			this.BotonSpEn.TabIndex = 10;
			this.BotonSpEn.Text = "En";
			this.BotonSpEn.UseVisualStyleBackColor = false;
			this.BotonSpEn.Click += new System.EventHandler(this.BotonSpEnClick);
			// 
			// Minimizar
			// 
			this.Minimizar.BackColor = System.Drawing.Color.Transparent;
			this.Minimizar.Image = global::OrganizerFiles.Resource.Boton_;
			this.Minimizar.Location = new System.Drawing.Point(271, 0);
			this.Minimizar.Name = "Minimizar";
			this.Minimizar.Size = new System.Drawing.Size(20, 18);
			this.Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Minimizar.TabIndex = 1;
			this.Minimizar.TabStop = false;
			this.Minimizar.Click += new System.EventHandler(this.MinimizarClick);
			this.Minimizar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizarMouseDown);
			this.Minimizar.MouseLeave += new System.EventHandler(this.MinimizarMouseLeave);
			this.Minimizar.MouseHover += new System.EventHandler(this.MinimizarMouseHover);
			// 
			// Salir
			// 
			this.Salir.BackColor = System.Drawing.Color.Transparent;
			this.Salir.Image = global::OrganizerFiles.Resource.BtnX;
			this.Salir.Location = new System.Drawing.Point(297, 0);
			this.Salir.Name = "Salir";
			this.Salir.Size = new System.Drawing.Size(20, 18);
			this.Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Salir.TabIndex = 0;
			this.Salir.TabStop = false;
			this.Salir.Click += new System.EventHandler(this.SalirClick);
			this.Salir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SalirMouseDown);
			this.Salir.MouseLeave += new System.EventHandler(this.SalirMouseLeave);
			this.Salir.MouseHover += new System.EventHandler(this.SalirMouseHover);
			// 
			// Buscar
			// 
			this.Buscar.BackColor = System.Drawing.Color.Transparent;
			this.Buscar.Image = global::OrganizerFiles.Resource.Lupa;
			this.Buscar.Location = new System.Drawing.Point(287, 169);
			this.Buscar.Name = "Buscar";
			this.Buscar.Size = new System.Drawing.Size(26, 20);
			this.Buscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Buscar.TabIndex = 2;
			this.Buscar.TabStop = false;
			this.Buscar.Click += new System.EventHandler(this.BuscarClick);
			this.Buscar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BuscarMouseDown);
			this.Buscar.MouseLeave += new System.EventHandler(this.BuscarMouseLeave);
			this.Buscar.MouseHover += new System.EventHandler(this.BuscarMouseHover);
			// 
			// LimpiarLista
			// 
			this.LimpiarLista.BackColor = System.Drawing.Color.Transparent;
			this.LimpiarLista.Image = global::OrganizerFiles.Resource.Cepillo_l;
			this.LimpiarLista.Location = new System.Drawing.Point(16, 238);
			this.LimpiarLista.Name = "LimpiarLista";
			this.LimpiarLista.Size = new System.Drawing.Size(59, 38);
			this.LimpiarLista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.LimpiarLista.TabIndex = 24;
			this.LimpiarLista.TabStop = false;
			this.LimpiarLista.Click += new System.EventHandler(this.LimpiarListaClick);
			this.LimpiarLista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LimpiarListaMouseDown);
			this.LimpiarLista.MouseLeave += new System.EventHandler(this.LimpiarListaMouseLeave);
			this.LimpiarLista.MouseHover += new System.EventHandler(this.LimpiarListaMouseHover);
			// 
			// OrganizarArchivos
			// 
			this.OrganizarArchivos.BackColor = System.Drawing.Color.Transparent;
			this.OrganizarArchivos.Image = global::OrganizerFiles.Resource.Carpetapng;
			this.OrganizarArchivos.Location = new System.Drawing.Point(244, 241);
			this.OrganizarArchivos.Name = "OrganizarArchivos";
			this.OrganizarArchivos.Size = new System.Drawing.Size(59, 38);
			this.OrganizarArchivos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.OrganizarArchivos.TabIndex = 25;
			this.OrganizarArchivos.TabStop = false;
			this.OrganizarArchivos.Click += new System.EventHandler(this.OrganizarArchivosClick);
			this.OrganizarArchivos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OrganizarArchivosMouseDown);
			this.OrganizarArchivos.MouseLeave += new System.EventHandler(this.OrganizarArchivosMouseLeave);
			this.OrganizarArchivos.MouseHover += new System.EventHandler(this.OrganizarArchivosMouseHover);
			// 
			// labelLimpiar
			// 
			this.labelLimpiar.Location = new System.Drawing.Point(6, 221);
			this.labelLimpiar.Name = "labelLimpiar";
			this.labelLimpiar.Size = new System.Drawing.Size(81, 17);
			this.labelLimpiar.TabIndex = 26;
			this.labelLimpiar.Text = "Limpiar consola";
			this.labelLimpiar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelAbrir
			// 
			this.labelAbrir.Location = new System.Drawing.Point(124, 222);
			this.labelAbrir.Name = "labelAbrir";
			this.labelAbrir.Size = new System.Drawing.Size(73, 17);
			this.labelAbrir.TabIndex = 27;
			this.labelAbrir.Text = "Abrir carpeta";
			// 
			// labelOrganizar
			// 
			this.labelOrganizar.Location = new System.Drawing.Point(246, 221);
			this.labelOrganizar.Name = "labelOrganizar";
			this.labelOrganizar.Size = new System.Drawing.Size(57, 17);
			this.labelOrganizar.TabIndex = 28;
			this.labelOrganizar.Text = "Organizar";
			this.labelOrganizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AbrirCarpetas
			// 
			this.AbrirCarpetas.BackColor = System.Drawing.Color.Transparent;
			this.AbrirCarpetas.Image = global::OrganizerFiles.Resource.Llave;
			this.AbrirCarpetas.Location = new System.Drawing.Point(127, 238);
			this.AbrirCarpetas.Name = "AbrirCarpetas";
			this.AbrirCarpetas.Size = new System.Drawing.Size(59, 38);
			this.AbrirCarpetas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.AbrirCarpetas.TabIndex = 29;
			this.AbrirCarpetas.TabStop = false;
			this.AbrirCarpetas.Click += new System.EventHandler(this.AbrirCarpetasClick);
			this.AbrirCarpetas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AbrirCarpetasMouseDown);
			this.AbrirCarpetas.MouseLeave += new System.EventHandler(this.AbrirCarpetasMouseLeave);
			this.AbrirCarpetas.MouseHover += new System.EventHandler(this.AbrirCarpetasMouseHover);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(320, 460);
			this.Controls.Add(this.EncarpetarSinE);
			this.Controls.Add(this.Encarpetar);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.AbrirCarpetas);
			this.Controls.Add(this.labelOrganizar);
			this.Controls.Add(this.CarpetasSubCarpetas);
			this.Controls.Add(this.labelAbrir);
			this.Controls.Add(this.MostrarArchivos);
			this.Controls.Add(this.labelLimpiar);
			this.Controls.Add(this.OrganizarArchivos);
			this.Controls.Add(this.LimpiarLista);
			this.Controls.Add(this.Buscar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.Lista);
			this.Controls.Add(this.Direccion);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = global::OrganizerFiles.Resource.OrganizerFiles;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OrganizerFiles";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Minimizar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Buscar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LimpiarLista)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OrganizarArchivos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AbrirCarpetas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
