/*
 * Creado por SharpDevelop.
 * Usuario: Anthony
 * Fecha: 11/01/2021
 * Hora: 06:34 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace OrganizerFiles
{
	
	public partial class MainForm : Form
	{
		
		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
		//Estos son recursos del sistema para mover el form sin bordes.
		
		public string letra; public bool SpEn = false;
		
		public long TamanoCarpeta(DirectoryInfo d){
			
			long size = 0;
			long tamano = 0;
			string ConvertSize;
			
			FileInfo[] fis = d.GetFiles();
			
			foreach(FileInfo fi in fis){
				
				size += fi.Length;
				
			}
			
			DirectoryInfo[] dis = d.GetDirectories();
			
			foreach(DirectoryInfo di in dis){
				
				size += TamanoCarpeta(di);
				
			}
			
			ConvertSize = Convert.ToString(size);
			
			if(ConvertSize.Length > 0 && ConvertSize.Length <= 6){
				
				tamano += size / 1024;
				
				
				letra = "KB";
				
			}else if(ConvertSize.Length > 6 && ConvertSize.Length < 10){
				
				tamano += size / 1048576;
							
				letra = "MB";
				
			}else if(ConvertSize.Length == 10 || ConvertSize.Length > 10){
				
				tamano += size / 1073741824;				
				
				letra = "GB";
				
			}

			Convert.ToDouble(tamano);
			
			return tamano;
			
		}					
		
		public MainForm()
		{	
			CambiarIdioma Cambiar = new CambiarIdioma();
			Cambiar.Lenguaje();		
			InitializeComponent();
			labelOrganizar.Text = Idioma.Default.Organizar;
			labelLimpiar.Text = Idioma.Default.Limpiar;
			labelAbrir.Text = Idioma.Default.AbrirCarpeta;
			CarpetasSubCarpetas.Text = Idioma.Default.ExaminarCarpetas;
			Encarpetar.Text = Idioma.Default.EnCarpetarConExtension;
			EncarpetarSinE.Text = Idioma.Default.EnEnCarpetarSinExtension;
			radioButton3.Text = Idioma.Default.NoEncarpetar;
			Direccion.Text = Idioma.Default.EscribeLaRuta;
			
			
		}
		void BuscarDirectorioClick(object sender, EventArgs e)
		{
			
			Direccion.Clear();
			FolderBrowserDialog buscar = new FolderBrowserDialog();
			
			if(buscar.ShowDialog() == DialogResult.OK){
				Direccion.Text += buscar.SelectedPath.ToString();
			}
			
		}
		
				void BuscarClick(object sender, EventArgs e)
		{
			Direccion.Clear();
			FolderBrowserDialog buscar = new FolderBrowserDialog();
			
			if(buscar.ShowDialog() == DialogResult.OK){
				Direccion.Text += buscar.SelectedPath.ToString();
			}
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			double Tiempo=0;
			Tiempo += 1;
			if(Tiempo == 3){
					progressBar1.Value = 0;
				}
		}
		
		void OrganizarArchivosClick(object sender, EventArgs e)
		{
	
			try{
		 	for(int i = 0; i < 30; i++){
			progressBar1.Value = i;
			
			}
		 		
		 	
		 	
		 	DriveInfo detalles = new DriveInfo(Direccion.Text);
		 	DirectoryInfo D = new DirectoryInfo(Direccion.Text);
		 	FileInfo[] nombre = D.GetFiles("*.*");
		 	
		 	
			int cantidadPdfs,cantidadJpg,cantidadDocx,cantidadPng,cantidadMp4,cantidadPptx,cantidadEml,
			cantidadXlsx,cantidadZip,cantidadRar,cantidadExe,cantidadBmp,cantidadMp3,cantidadMhtml,cantidadHtm,cantidadHtml,
			cantidadJpeg,cantidadAsd,cantidadGif,cantidadIco,cantidadTiff,cantidadTif,cantidadWav,cantidadAvi,
			cantidadMkv,cantidadMpeg,cantidadMpg,cantidadXps,cantidadXlm,cantidadXml,cantidadAspx,cantidadBat,cantidadBin,cantidadXltx,
			cantidadDif,cantidadDll,cantidadDotx,cantidadIni,cantidadIso,cantidadJar,cantidadM4a,cantidadInk,cantidadMsi,cantidadPotx,
			cantidadPpam,cantidadPpsx,cantidadPsd,cantidadTxt,cantidadXlsm,cantidadWma,cantidadOgg,cantidadDoc,cantidadXls,
			cantidadPpt,cantidadJs,cantidadPhp,cantidadCpp,cantidadC,cantidadCs,cantidadOds,cantidadXcf,cantidadCmd,
			cantidadCss,cantidadSh,cantidadMd,cantidadPy,cantidadMsstyle,cantidadSvg,cantidadSettings,cantidadTheme,cantidadOtf,
			cantidadTtf,cantidadTotal = 0;
			
			
			
				
				Lista.Items.Clear();
				if(CarpetasSubCarpetas.Checked == true){
			cantidadPdfs = Directory.GetFiles(Direccion.Text, "*.pdf*", SearchOption.AllDirectories).Length;
			cantidadJpg = Directory.GetFiles(Direccion.Text, "*.jpg*", SearchOption.AllDirectories).Length;
			cantidadDocx = Directory.GetFiles(Direccion.Text, "*.docx*", SearchOption.AllDirectories).Length;
			cantidadPng = Directory.GetFiles(Direccion.Text, "*.png*", SearchOption.AllDirectories).Length;
			cantidadMp4 = Directory.GetFiles(Direccion.Text, "*.mp4*", SearchOption.AllDirectories).Length;
			cantidadPptx = Directory.GetFiles(Direccion.Text, "*.pptx*", SearchOption.AllDirectories).Length;
			cantidadEml = Directory.GetFiles(Direccion.Text, "*.eml*", SearchOption.AllDirectories).Length;
			cantidadXlsx = Directory.GetFiles(Direccion.Text, "*.xlsx*", SearchOption.AllDirectories).Length;
			cantidadZip = Directory.GetFiles(Direccion.Text, "*.zip*", SearchOption.AllDirectories).Length;
			cantidadRar = Directory.GetFiles(Direccion.Text, "*.rar*", SearchOption.AllDirectories).Length;
			cantidadExe = Directory.GetFiles(Direccion.Text, "*.exe*", SearchOption.AllDirectories).Length;
			cantidadBmp = Directory.GetFiles(Direccion.Text, "*.bmp*", SearchOption.AllDirectories).Length;
			cantidadMp3 = Directory.GetFiles(Direccion.Text, "*.mp3*", SearchOption.AllDirectories).Length;
			cantidadMhtml = Directory.GetFiles(Direccion.Text, "*.mhtml*", SearchOption.AllDirectories).Length;
			cantidadHtm = Directory.GetFiles(Direccion.Text, "*.htm*", SearchOption.AllDirectories).Length;
			cantidadHtml = Directory.GetFiles(Direccion.Text, "*.html*", SearchOption.AllDirectories).Length;
			cantidadJpeg = Directory.GetFiles(Direccion.Text, "*.jpeg*", SearchOption.AllDirectories).Length;
			cantidadAsd = Directory.GetFiles(Direccion.Text, "*.asd*", SearchOption.AllDirectories).Length;
			cantidadGif = Directory.GetFiles(Direccion.Text, "*.gif*", SearchOption.AllDirectories).Length;
			cantidadIco = Directory.GetFiles(Direccion.Text, "*.ico*", SearchOption.AllDirectories).Length;
			cantidadTif = Directory.GetFiles(Direccion.Text, "*.tif*", SearchOption.AllDirectories).Length;
			cantidadTiff = Directory.GetFiles(Direccion.Text, "*.tiff*", SearchOption.AllDirectories).Length;
			cantidadWav = Directory.GetFiles(Direccion.Text, "*.wav*", SearchOption.AllDirectories).Length;
			cantidadAvi = Directory.GetFiles(Direccion.Text, "*.avi*", SearchOption.AllDirectories).Length;
			cantidadMkv = Directory.GetFiles(Direccion.Text, "*.mkv*", SearchOption.AllDirectories).Length;
			cantidadMpeg = Directory.GetFiles(Direccion.Text, "*.mpeg*", SearchOption.AllDirectories).Length;
			cantidadMpg = Directory.GetFiles(Direccion.Text, "*.mpg*", SearchOption.AllDirectories).Length;
			cantidadXml = Directory.GetFiles(Direccion.Text, "*.xml*", SearchOption.AllDirectories).Length;
			cantidadXlm = Directory.GetFiles(Direccion.Text, "*.xlm*", SearchOption.AllDirectories).Length;
			cantidadAspx = Directory.GetFiles(Direccion.Text, "*.aspx*", SearchOption.AllDirectories).Length;
			cantidadBat = Directory.GetFiles(Direccion.Text, "*.bat*", SearchOption.AllDirectories).Length;
			cantidadBin = Directory.GetFiles(Direccion.Text, "*.bin*", SearchOption.AllDirectories).Length;
			cantidadXltx = Directory.GetFiles(Direccion.Text, "*.xltx*", SearchOption.AllDirectories).Length;
			cantidadDif = Directory.GetFiles(Direccion.Text, "*.dif*", SearchOption.AllDirectories).Length;
			cantidadDll = Directory.GetFiles(Direccion.Text, "*.dll*", SearchOption.AllDirectories).Length;
			cantidadDotx = Directory.GetFiles(Direccion.Text, "*.dotx*", SearchOption.AllDirectories).Length;
			cantidadIni = Directory.GetFiles(Direccion.Text, "*.ini*", SearchOption.AllDirectories).Length;
			cantidadIso = Directory.GetFiles(Direccion.Text, "*.iso*", SearchOption.AllDirectories).Length;
			cantidadJar = Directory.GetFiles(Direccion.Text, "*.jar*", SearchOption.AllDirectories).Length;
			cantidadM4a = Directory.GetFiles(Direccion.Text, "*.m4a*", SearchOption.AllDirectories).Length;
			cantidadMsi = Directory.GetFiles(Direccion.Text, "*.msi*", SearchOption.AllDirectories).Length;
			cantidadPotx = Directory.GetFiles(Direccion.Text, "*.potx*", SearchOption.AllDirectories).Length;
			cantidadPpam = Directory.GetFiles(Direccion.Text, "*.ppam*", SearchOption.AllDirectories).Length;
			cantidadPpsx = Directory.GetFiles(Direccion.Text, "*.ppsx*", SearchOption.AllDirectories).Length;
			cantidadPsd = Directory.GetFiles(Direccion.Text, "*.psd*", SearchOption.AllDirectories).Length;
			cantidadTxt = Directory.GetFiles(Direccion.Text, "*.txt*", SearchOption.AllDirectories).Length;
			cantidadXlsm = Directory.GetFiles(Direccion.Text, "*.xlsm*", SearchOption.AllDirectories).Length;
			cantidadOgg = Directory.GetFiles(Direccion.Text, "*.ogg*", SearchOption.AllDirectories).Length;
			cantidadXps = Directory.GetFiles(Direccion.Text, "*.xps*", SearchOption.AllDirectories).Length;
			cantidadIni = Directory.GetFiles(Direccion.Text, "*.ini*", SearchOption.AllDirectories).Length;
			cantidadInk = Directory.GetFiles(Direccion.Text, "*.ink*", SearchOption.AllDirectories).Length;
			cantidadWma = Directory.GetFiles(Direccion.Text, "*.wma*", SearchOption.AllDirectories).Length;
			cantidadDoc = Directory.GetFiles(Direccion.Text, "*.doc*", SearchOption.AllDirectories).Length;
			cantidadXls = Directory.GetFiles(Direccion.Text, "*.xls*", SearchOption.AllDirectories).Length;
			cantidadPpt = Directory.GetFiles(Direccion.Text, "*.ppt*", SearchOption.AllDirectories).Length;
			cantidadJs = Directory.GetFiles(Direccion.Text, "*.js*", SearchOption.AllDirectories).Length;
			cantidadPhp = Directory.GetFiles(Direccion.Text, "*.php*", SearchOption.AllDirectories).Length;
			cantidadCpp = Directory.GetFiles(Direccion.Text, "*.cpp*", SearchOption.AllDirectories).Length;
			cantidadC = Directory.GetFiles(Direccion.Text, "*.c*", SearchOption.AllDirectories).Length;
			cantidadCs = Directory.GetFiles(Direccion.Text, "*.cs*", SearchOption.AllDirectories).Length;
			cantidadOds = Directory.GetFiles(Direccion.Text, "*.ods*", SearchOption.AllDirectories).Length;
			cantidadXcf = Directory.GetFiles(Direccion.Text, "*.xcf*", SearchOption.AllDirectories).Length;
			cantidadCmd = Directory.GetFiles(Direccion.Text, "*.cmd*", SearchOption.AllDirectories).Length;
			cantidadCss= Directory.GetFiles(Direccion.Text, "*.css*", SearchOption.AllDirectories).Length;
			cantidadSh= Directory.GetFiles(Direccion.Text, "*.sh*", SearchOption.AllDirectories).Length;
			cantidadMd= Directory.GetFiles(Direccion.Text, "*.md*", SearchOption.AllDirectories).Length;
			cantidadPy= Directory.GetFiles(Direccion.Text, "*.py*", SearchOption.AllDirectories).Length;
			cantidadMsstyle= Directory.GetFiles(Direccion.Text, "*.msstyle*", SearchOption.AllDirectories).Length;
			cantidadSvg= Directory.GetFiles(Direccion.Text, "*.svg*", SearchOption.AllDirectories).Length;
			cantidadSettings= Directory.GetFiles(Direccion.Text, "*.settings*", SearchOption.AllDirectories).Length;
			cantidadTheme= Directory.GetFiles(Direccion.Text, "*.theme*", SearchOption.AllDirectories).Length;
			cantidadOtf= Directory.GetFiles(Direccion.Text, "*.otf*", SearchOption.AllDirectories).Length;
			cantidadTtf= Directory.GetFiles(Direccion.Text, "*.ttf*", SearchOption.AllDirectories).Length;
			}
			else{
			cantidadPdfs = Directory.GetFiles(Direccion.Text, "*.pdf*", SearchOption.TopDirectoryOnly).Length;
			cantidadJpg = Directory.GetFiles(Direccion.Text, "*.jpg*", SearchOption.TopDirectoryOnly).Length;
			cantidadDocx = Directory.GetFiles(Direccion.Text, "*.docx*", SearchOption.TopDirectoryOnly).Length;
			cantidadPng = Directory.GetFiles(Direccion.Text, "*.png*", SearchOption.TopDirectoryOnly).Length;
			cantidadMp4 = Directory.GetFiles(Direccion.Text, "*.mp4*", SearchOption.TopDirectoryOnly).Length;
			cantidadPptx = Directory.GetFiles(Direccion.Text, "*.pptx*", SearchOption.TopDirectoryOnly).Length;
			cantidadEml = Directory.GetFiles(Direccion.Text, "*.eml*", SearchOption.TopDirectoryOnly).Length;
			cantidadXlsx = Directory.GetFiles(Direccion.Text, "*.xlsx*", SearchOption.TopDirectoryOnly).Length;
			cantidadZip = Directory.GetFiles(Direccion.Text, "*.zip*", SearchOption.TopDirectoryOnly).Length;
			cantidadRar = Directory.GetFiles(Direccion.Text, "*.rar*", SearchOption.TopDirectoryOnly).Length;
			cantidadExe = Directory.GetFiles(Direccion.Text, "*.exe*", SearchOption.TopDirectoryOnly).Length;
			cantidadBmp = Directory.GetFiles(Direccion.Text, "*.bmp*", SearchOption.TopDirectoryOnly).Length;
			cantidadMp3 = Directory.GetFiles(Direccion.Text, "*.mp3*", SearchOption.TopDirectoryOnly).Length;
			cantidadMhtml = Directory.GetFiles(Direccion.Text, "*.mhtml*", SearchOption.TopDirectoryOnly).Length;
			cantidadHtm = Directory.GetFiles(Direccion.Text, "*.htm*", SearchOption.TopDirectoryOnly).Length;
			cantidadHtml = Directory.GetFiles(Direccion.Text, "*.html*", SearchOption.TopDirectoryOnly).Length;
			cantidadJpeg = Directory.GetFiles(Direccion.Text, "*.jpeg*", SearchOption.TopDirectoryOnly).Length;
			cantidadAsd = Directory.GetFiles(Direccion.Text, "*.asd*", SearchOption.TopDirectoryOnly).Length;
			cantidadGif = Directory.GetFiles(Direccion.Text, "*.gif*", SearchOption.TopDirectoryOnly).Length;
			cantidadIco = Directory.GetFiles(Direccion.Text, "*.ico*", SearchOption.TopDirectoryOnly).Length;
			cantidadTif = Directory.GetFiles(Direccion.Text, "*.tif*", SearchOption.TopDirectoryOnly).Length;
			cantidadTiff = Directory.GetFiles(Direccion.Text, "*.tiff*", SearchOption.TopDirectoryOnly).Length;
			cantidadWav = Directory.GetFiles(Direccion.Text, "*.wav*", SearchOption.TopDirectoryOnly).Length;
			cantidadAvi = Directory.GetFiles(Direccion.Text, "*.avi*", SearchOption.TopDirectoryOnly).Length;
			cantidadMkv = Directory.GetFiles(Direccion.Text, "*.mkv*", SearchOption.TopDirectoryOnly).Length;
			cantidadMpeg = Directory.GetFiles(Direccion.Text, "*.mpeg*", SearchOption.TopDirectoryOnly).Length;
			cantidadMpg = Directory.GetFiles(Direccion.Text, "*.mpg*", SearchOption.TopDirectoryOnly).Length;
			cantidadXml = Directory.GetFiles(Direccion.Text, "*.xml*", SearchOption.TopDirectoryOnly).Length;
			cantidadXlm = Directory.GetFiles(Direccion.Text, "*.xlm*", SearchOption.TopDirectoryOnly).Length;
			cantidadAspx = Directory.GetFiles(Direccion.Text, "*.aspx*", SearchOption.TopDirectoryOnly).Length;
			cantidadBat = Directory.GetFiles(Direccion.Text, "*.bat*", SearchOption.TopDirectoryOnly).Length;
			cantidadBin = Directory.GetFiles(Direccion.Text, "*.bin*", SearchOption.TopDirectoryOnly).Length;
			cantidadXltx = Directory.GetFiles(Direccion.Text, "*.xltx*", SearchOption.TopDirectoryOnly).Length;
			cantidadDif = Directory.GetFiles(Direccion.Text, "*.dif*", SearchOption.TopDirectoryOnly).Length;
			cantidadDll = Directory.GetFiles(Direccion.Text, "*.dll*", SearchOption.TopDirectoryOnly).Length;
			cantidadDotx = Directory.GetFiles(Direccion.Text, "*.dotx*", SearchOption.TopDirectoryOnly).Length;
			cantidadIni = Directory.GetFiles(Direccion.Text, "*.ini*", SearchOption.TopDirectoryOnly).Length;
			cantidadIso = Directory.GetFiles(Direccion.Text, "*.iso*", SearchOption.TopDirectoryOnly).Length;
			cantidadJar = Directory.GetFiles(Direccion.Text, "*.jar*", SearchOption.TopDirectoryOnly).Length;
			cantidadM4a = Directory.GetFiles(Direccion.Text, "*.m4a*", SearchOption.TopDirectoryOnly).Length;
			cantidadMsi = Directory.GetFiles(Direccion.Text, "*.msi*", SearchOption.TopDirectoryOnly).Length;
			cantidadPotx = Directory.GetFiles(Direccion.Text, "*.potx*", SearchOption.TopDirectoryOnly).Length;
			cantidadPpam = Directory.GetFiles(Direccion.Text, "*.ppam*", SearchOption.TopDirectoryOnly).Length;
			cantidadPpsx = Directory.GetFiles(Direccion.Text, "*.ppsx*", SearchOption.TopDirectoryOnly).Length;
			cantidadPsd = Directory.GetFiles(Direccion.Text, "*.psd*", SearchOption.TopDirectoryOnly).Length;
			cantidadTxt = Directory.GetFiles(Direccion.Text, "*.txt*", SearchOption.TopDirectoryOnly).Length;
			cantidadXlsm = Directory.GetFiles(Direccion.Text, "*.xlsm*", SearchOption.TopDirectoryOnly).Length;
			cantidadOgg = Directory.GetFiles(Direccion.Text, "*.ogg*", SearchOption.TopDirectoryOnly).Length;
			cantidadXps = Directory.GetFiles(Direccion.Text, "*.xps*", SearchOption.TopDirectoryOnly).Length;	
			cantidadIni = Directory.GetFiles(Direccion.Text, "*.ini*", SearchOption.TopDirectoryOnly).Length;	
			cantidadInk = Directory.GetFiles(Direccion.Text, "*.ink*", SearchOption.TopDirectoryOnly).Length;	
			cantidadWma = Directory.GetFiles(Direccion.Text, "*.wma*", SearchOption.TopDirectoryOnly).Length;		
			cantidadDoc = Directory.GetFiles(Direccion.Text, "*.doc*", SearchOption.TopDirectoryOnly).Length;	
			cantidadXls = Directory.GetFiles(Direccion.Text, "*.xls*", SearchOption.TopDirectoryOnly).Length;
			cantidadPpt = Directory.GetFiles(Direccion.Text, "*.ppt*", SearchOption.TopDirectoryOnly).Length;
			cantidadJs = Directory.GetFiles(Direccion.Text, "*.js*", SearchOption.TopDirectoryOnly).Length;
			cantidadPhp = Directory.GetFiles(Direccion.Text, "*.php*", SearchOption.TopDirectoryOnly).Length;
			cantidadCpp = Directory.GetFiles(Direccion.Text, "*.cpp*", SearchOption.TopDirectoryOnly).Length;
			cantidadC = Directory.GetFiles(Direccion.Text, "*.c*", SearchOption.TopDirectoryOnly).Length;
			cantidadCs = Directory.GetFiles(Direccion.Text, "*.cs*", SearchOption.TopDirectoryOnly).Length;
			cantidadOds = Directory.GetFiles(Direccion.Text, "*.ods*", SearchOption.TopDirectoryOnly).Length;
			cantidadXcf = Directory.GetFiles(Direccion.Text, "*.xcf*", SearchOption.TopDirectoryOnly).Length;
			cantidadCmd = Directory.GetFiles(Direccion.Text, "*.cmd*", SearchOption.TopDirectoryOnly).Length;
			cantidadCss= Directory.GetFiles(Direccion.Text, "*.css*", SearchOption.TopDirectoryOnly).Length;
			cantidadSh= Directory.GetFiles(Direccion.Text, "*.sh*", SearchOption.TopDirectoryOnly).Length;
			cantidadMd= Directory.GetFiles(Direccion.Text, "*.md*", SearchOption.TopDirectoryOnly).Length;
			cantidadPy= Directory.GetFiles(Direccion.Text, "*.py*", SearchOption.TopDirectoryOnly).Length;
			cantidadMsstyle= Directory.GetFiles(Direccion.Text, "*.msstyle*", SearchOption.TopDirectoryOnly).Length;
			cantidadSvg= Directory.GetFiles(Direccion.Text, "*.svg*", SearchOption.TopDirectoryOnly).Length;
			cantidadSettings= Directory.GetFiles(Direccion.Text, "*.settings*", SearchOption.TopDirectoryOnly).Length;
			cantidadTheme= Directory.GetFiles(Direccion.Text, "*.theme*", SearchOption.TopDirectoryOnly).Length;
			cantidadOtf= Directory.GetFiles(Direccion.Text, "*.otf*", SearchOption.TopDirectoryOnly).Length;
			cantidadTtf= Directory.GetFiles(Direccion.Text, "*.ttf*", SearchOption.TopDirectoryOnly).Length;
			}
			cantidadTotal =  cantidadPdfs+cantidadJpg+cantidadDocx+cantidadPng+cantidadMp4+cantidadPptx+cantidadEml+
			cantidadXlsx+cantidadZip+cantidadRar+cantidadExe+cantidadBmp+cantidadMp3+cantidadHtm+cantidadHtml+
			cantidadJpeg+cantidadAsd+cantidadGif+cantidadIco+cantidadTiff+cantidadTif+cantidadWav+cantidadAvi+
			cantidadMkv+cantidadMpeg+cantidadMpg+cantidadXps+cantidadXlm+cantidadAspx+cantidadBat+cantidadBin+cantidadXltx+
			cantidadDif+cantidadDll+cantidadDotx+cantidadIni+cantidadIso+cantidadJar+cantidadM4a+cantidadMsi+cantidadPotx+
			cantidadPpam+cantidadPpsx+cantidadPsd+cantidadTxt+cantidadXlsm+cantidadWma+cantidadOgg+cantidadDoc+cantidadXls+
			cantidadPpt+cantidadJs+cantidadCpp+cantidadPhp+cantidadC+cantidadCs+cantidadOds+cantidadXcf+cantidadCmd+cantidadCss+
			cantidadSh+cantidadMd+cantidadPy+cantidadMsstyle+cantidadSvg+cantidadSettings+cantidadTheme+cantidadOtf+cantidadTtf;
			
			if(MostrarArchivos.Checked == true){	
			Lista.Items.Add("---------------------------------------------------------------------------------------------------------------");
			Lista.Items.Add(Idioma.Default.TiposDeArchivos);
			Lista.Items.Add("---------------------------------------------------------------------------------------------------------------");
			Lista.Items.Add("");
			if(cantidadPdfs>=1){
			Lista.Items.Add("Cantidad de documentos .Pdf: "+cantidadPdfs);
				if(Encarpetar.Checked == true && cantidadPdfs>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPdfs>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos PDF");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.pdf*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos PDF",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Pdf");
				}
				}
			}
			if(cantidadDocx>=1){
			Lista.Items.Add("Cantidad de documentos .Docx: "+cantidadDocx);
				if(Encarpetar.Checked == true && cantidadDocx>=1 && CarpetasSubCarpetas.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos DOCX");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.docx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos DOCX",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Docx");
				}
				}
			}
			if(cantidadDoc>=1){
			Lista.Items.Add("Cantidad de documentos .Doc: "+cantidadDoc);
				if(Encarpetar.Checked == true && cantidadDoc>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadDoc>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos DOC");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.doc*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos DOC",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Doc");
				}
				}
			}
			if(cantidadXlsx>=1){
			Lista.Items.Add("Cantidad de documentos .Xlsx: "+cantidadXlsx);
				if(Encarpetar.Checked == true && cantidadXlsx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXlsx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos XLSX");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xlsx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos XLSX",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xlsx");
				}
				}
			}
			if(cantidadXls>=1){
			Lista.Items.Add("Cantidad de documentos .Xls: "+cantidadXls);
				if(Encarpetar.Checked == true && cantidadXls>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXls>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos XLS");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xls*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos XLS",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xls");
				}
				}
			}
			if(cantidadXml>=1){
			Lista.Items.Add("Cantidad de documentos .Xml: "+cantidadXml);
				if(Encarpetar.Checked == true && cantidadXml>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXml>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos Xml");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xml*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos Xml",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xml");
				}
				}
			}
			if(cantidadEml>=1){
			Lista.Items.Add("Cantidad de documentos .Eml: "+cantidadEml);
				if(Encarpetar.Checked == true && cantidadEml>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadEml>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos EML");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.eml*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos EML",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Eml");
				}
				}
			}
			if(cantidadDotx>=1){
			Lista.Items.Add("Cantidad de documentos .Dotx: "+cantidadDotx);
				if(Encarpetar.Checked == true && cantidadDotx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadDotx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos DOTX");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.dotx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos DOTX",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Dotx");
				}
				}
			}
			if(cantidadXlsm>=1){
			Lista.Items.Add("Cantidad de documentos .Xlsm: "+cantidadXlsm);
				if(Encarpetar.Checked == true && cantidadXlsm>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXlsm>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos XLSM");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xlsm*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos XLSM",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xlsm");
				}
				}
			}
			if(cantidadDif>=1){
			Lista.Items.Add("Cantidad de documentos .Dif: "+cantidadDif);
				if(Encarpetar.Checked == true && cantidadDif>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadDif>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos DIF");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.dif*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos DIF",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Dif");
				}
				}
			}
			if(cantidadOds>=1){
			Lista.Items.Add("Cantidad de documentos .Ods: "+cantidadOds);
				if(Encarpetar.Checked == true && cantidadOds>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadOds>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos ODS");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ods*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos ODS",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ods");
				}
				}
			}
			if(cantidadXlm>=1){
			Lista.Items.Add("Cantidad de documentos .Xlm: "+cantidadXlm);
				if(Encarpetar.Checked == true && cantidadXlm>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXlm>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos XLM");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xlm*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos XLM",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xlm");
				}
				}
			}
			if(cantidadXps>=1){
			Lista.Items.Add("Cantidad de documentos .Xps: "+cantidadXps);
				if(Encarpetar.Checked == true && cantidadXps>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXps>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos XPS");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xps*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos XPS",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xps");
				}
				}
			}
			if(cantidadXltx>=1){
			Lista.Items.Add("Cantidad de documentos .Xltx: "+cantidadXltx);
				if(Encarpetar.Checked == true && cantidadXltx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadXltx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos XLTX");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xltx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos XLTX",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xltx");
				}
				}
			}
			if(cantidadTxt>=1){
			Lista.Items.Add("Cantidad de archivos de texto .Txt: "+cantidadTxt);
				if(Encarpetar.Checked == true && cantidadTxt>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadTxt>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos TXT");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.txt*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos TXT",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Txt");
				}
				}
			}
			if(cantidadMhtml>=1){
			Lista.Items.Add("Cantidad de páginas .Mhtml: "+cantidadMhtml);
				if(Encarpetar.Checked == true && cantidadMhtml>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMhtml>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas Mhtml");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mhtml*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas Mhtml",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mhtml");
				}
				}
			}
			if(cantidadHtm>=1){
			Lista.Items.Add("Cantidad de páginas .Htm: "+cantidadHtm);
				if(Encarpetar.Checked == true && cantidadHtm>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadHtm>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas HTM");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.htm*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas HTM",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Htm");
				}
				}
			}
			if(cantidadHtml>=1){
			Lista.Items.Add("Cantidad de páginas .Html: "+cantidadHtml);
				if(Encarpetar.Checked == true && cantidadHtml>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadHtml>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas HTML");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.html*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas HTML",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Html");
				}
				}
			}
			if(cantidadAsd>=1){
			Lista.Items.Add("Cantidad de páginas .Asd: "+cantidadAsd);
				if(Encarpetar.Checked == true && cantidadAsd>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadAsd>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas ASD");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.asd*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas ASD",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Asd");
				}
				}
			}
			if(cantidadAspx>=1){
			Lista.Items.Add("Cantidad de páginas .Aspx: "+cantidadAspx);
				if(Encarpetar.Checked == true && cantidadAspx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadAspx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas ASPX");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.aspx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas ASPX",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Aspx");
				}
				}
			}
			if(cantidadPptx>=1){
			Lista.Items.Add("Cantidad de Power Points .Pptx: "+cantidadPptx);
				if(Encarpetar.Checked == true && cantidadPptx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPptx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.pptx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Pptx");
				}
				}
			}
			if(cantidadPpt>=1){
			Lista.Items.Add("Cantidad de Power Points .Ppt: "+cantidadPpt);
				if(Encarpetar.Checked == true && cantidadPpt>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPpt>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ppt*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ppt");
				}
				}
			}
			if(cantidadPotx>=1){
			Lista.Items.Add("Cantidad de Power Points .Potx: "+cantidadPotx);
				if(Encarpetar.Checked == true && cantidadPotx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPotx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.potx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Potx");
				}
				}
			}
			if(cantidadPpam>=1){
			Lista.Items.Add("Cantidad de Power Points .Ppam: "+cantidadPpam);
				if(Encarpetar.Checked == true && cantidadPpam>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPpam>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ppam*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ppam");
				}
				}
			}
			if(cantidadPpsx>=1){
			Lista.Items.Add("Cantidad de Power Points .Ppsx: "+cantidadPpsx);
				if(Encarpetar.Checked == true && cantidadPpsx>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPpsx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ppsx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ppsx");
				}
				}
			}
			if(cantidadJpg>=1){
			Lista.Items.Add("Cantidad de imágenes .Jpg: "+cantidadJpg);
				if(Encarpetar.Checked == true && cantidadJpg>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadJpg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes JPG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.jpg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes JPG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Jpg");
				}
				}
			}
			if(cantidadPng>=1){
			Lista.Items.Add("Cantidad de imágenes .Png: "+cantidadPng);
				if(Encarpetar.Checked == true && cantidadPng>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPng>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes PNG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.png*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes PNG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Png");
				}
				}
			}
			if(cantidadBmp>=1){
			Lista.Items.Add("Cantidad de imágenes .Bmp: "+cantidadBmp);
				if(Encarpetar.Checked == true && cantidadBmp>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadBmp>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes BMP");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.bmp*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes BMP",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Bmp");
				}
				}
			}
			if(cantidadJpeg>=1){
			Lista.Items.Add("Cantidad de imágenes .Jpeg: "+cantidadJpeg);
				if(Encarpetar.Checked == true && cantidadJpeg>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadJpeg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes JPEG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.jpeg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes JPEG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Jpeg");
				}
				}
			}
			if(cantidadIco>=1){
			Lista.Items.Add("Cantidad de imágenes .Ico: "+cantidadIco);
				if(Encarpetar.Checked == true && cantidadIco>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadIco>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes ICO");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ico*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes ICO",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ico");
				}
				}
			}
			if(cantidadGif>=1){
			Lista.Items.Add("Cantidad de imágenes .Gif: "+cantidadGif);
				if(Encarpetar.Checked == true && cantidadGif>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadGif>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes GIF");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.gif*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes GIF",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Gif");
				}
				}
			}
			if(cantidadSvg>=1){
			Lista.Items.Add("Cantidad de imágenes .Svg: "+cantidadSvg);
				if(Encarpetar.Checked == true && cantidadSvg>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadSvg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes SVG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.svg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes SVG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Svg");
				}
				}
			}	
			if(cantidadTif>=1){
			Lista.Items.Add("Cantidad de imágenes .Tif: "+cantidadTif);
				if(Encarpetar.Checked == true && cantidadTif>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadTif>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes TIF");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.tif*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes TIF",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Tif");
				}
				}
			}
			if(cantidadTiff>=1){
			Lista.Items.Add("Cantidad de imágenes .Tiff: "+cantidadTiff);
				if(Encarpetar.Checked == true && cantidadTiff>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadTiff>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes TIFF");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.tiff*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes TIFF",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Tiff");
				}
				}
			}
			if(cantidadMpeg>=1){
			Lista.Items.Add("Cantidad de videos .Mpeg: "+cantidadMpeg);
				if(Encarpetar.Checked == true && cantidadMpeg>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMpeg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos MPEG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mpeg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos MPEG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mpeg");
				}
				}
			}
			if(cantidadMpg>=1){
			Lista.Items.Add("Cantidad de videos .Mpg: "+cantidadMpg);
				if(Encarpetar.Checked == true && cantidadMpg>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMpg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos MPG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mpg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos MPG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mpg");
				}
				}
			}
			if(cantidadMkv>=1){
			Lista.Items.Add("Cantidad de videos .Mkv: "+cantidadMkv);
				if(Encarpetar.Checked == true && cantidadMkv>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMkv>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos MKV");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mkv*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos MKV",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mkv");
				}
				}
			}
			if(cantidadAvi>=1){
			Lista.Items.Add("Cantidad de videos .Avi: "+cantidadAvi);
				if(Encarpetar.Checked == true && cantidadAvi>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadAvi>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos AVI");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.avi*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos AVI",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Avi");
				}
				}
			}
			if(cantidadMp4>=1){
			Lista.Items.Add("Cantidad de videos .Mp4: "+cantidadMp4);
				if(Encarpetar.Checked == true && cantidadMp4>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMp4>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos MP4");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mp4*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos MP4",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mp4");
				}
				}
			}
			if(cantidadOgg>=1){
			Lista.Items.Add("Cantidad de videos .Ogg: "+cantidadOgg);
				if(Encarpetar.Checked == true && cantidadOgg>=1 && CarpetasSubCarpetas.Checked == false|| Encarpetar.Checked == true && cantidadOgg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos OGG");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ogg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos OGG",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ogg");
				}
				}
			}
			if(cantidadMp3>=1){
			Lista.Items.Add("Cantidad de audios .Mp3: "+cantidadMp3);
				if(Encarpetar.Checked == true && cantidadMp3>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMp3>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Audios MP3");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mp3*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Audios MP3",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mp3");
				}
				}
			}
			if(cantidadWav>=1){
			Lista.Items.Add("Cantidad de audios .Wav: "+cantidadWav);
				if(Encarpetar.Checked == true && cantidadWav>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadWav>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Audios WAV");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.wav*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Audios WAV",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Wav");
				}
				}
			}
				if(cantidadWma>=1){
			Lista.Items.Add("Cantidad de audios .Wma: "+cantidadWma);
				if(Encarpetar.Checked == true && cantidadWma>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadWma>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Audios WMA");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.wma*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Audios WMA",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Wma");
				}
				}
			}
			if(cantidadOgg>=1){
			Lista.Items.Add("Cantidad de audios .Ogg: "+cantidadOgg);
			}
			if(cantidadZip>=1){
			Lista.Items.Add("Cantidad de archivos comprimidos .Zip: "+cantidadZip);
				if(Encarpetar.Checked == true && cantidadZip>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadZip>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Comprimidos ZIP");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.zip*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Comprimidos ZIP",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Zip");
				}
				}
			}
			if(cantidadRar>=1){
			Lista.Items.Add("Cantidad de archivos comprimidos .Rar: "+cantidadRar);
				if(Encarpetar.Checked == true && cantidadRar>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadRar>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Comprimidos RAR");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.rar*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Comprimidos RAR",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Rar");
				}
				}
			}
			if(cantidadIso>=1){
			Lista.Items.Add("Cantidad de archivos comprimidos .Iso: "+cantidadIso);
					if(Encarpetar.Checked == true && cantidadIso>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadIso>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Comprimidos ISO");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.iso*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Comprimidos ISO",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Iso");
				}
				}
			}
			if(cantidadJar>=1){
			Lista.Items.Add("Cantidad de archivos Java .Jar: "+cantidadJar);
				if(Encarpetar.Checked == true && cantidadJar>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadJar>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos JAVA JAR");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.jar*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos JAVA JAR",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Jar");
				}
				}
			}
			if(cantidadJs>=1){
			Lista.Items.Add("Cantidad de archivos JavaScript .Js: "+cantidadJs);
				if(Encarpetar.Checked == true && cantidadJs>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadJs>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.js*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Js");
				}
				}
			}
			if(cantidadPhp>=1){
			Lista.Items.Add("Cantidad de archivos PHP .Php: "+cantidadPhp);
				if(Encarpetar.Checked == true && cantidadPhp>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPhp>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.php*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Php");
				}
				}
			}
			if(cantidadPy>=1){
			Lista.Items.Add("Cantidad de archivos Py .Py: "+cantidadPy);
				if(Encarpetar.Checked == true && cantidadPy>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadPy>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.py*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Py");
				}
				}
			}
			if(cantidadCpp>=1){
			Lista.Items.Add("Cantidad de archivos C++ .Cpp: "+cantidadCpp);
				if(Encarpetar.Checked == true && cantidadCpp>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadCpp>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.cpp*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Cpp");
				}
				}
			}
			if(cantidadC>=1){
			Lista.Items.Add("Cantidad de archivos C .C: "+cantidadC);
				if(Encarpetar.Checked == true && cantidadC>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadC>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.c*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .C");
				}
				}
			}
			if(cantidadCs>=1){
			Lista.Items.Add("Cantidad de archivos CiSharp .Cs: "+cantidadCs);
				if(Encarpetar.Checked == true && cantidadCs>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadCs>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.cs*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Cs");
				}
				}
			}
			if(cantidadPsd>=1){
			Lista.Items.Add("Cantidad de archivos Photoshop .Psd: "+cantidadPsd);
				if(Encarpetar.Checked == true && cantidadPsd>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked ==true && cantidadPsd>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos PhotoShop PSD");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.psd*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos PhotoShop PSD",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Psd");
				}
				}
			}
			if(cantidadXcf>=1){
			Lista.Items.Add("Cantidad de archivos GIMP .Xcf: "+cantidadXcf);
				if(Encarpetar.Checked == true && cantidadPsd>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked ==true && cantidadXcf>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos GIMP XCF");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xcf*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos GIMP XCF",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xcf");
				}
				}
			}
			if(cantidadBin>=1){
			Lista.Items.Add("Cantidad de archivos Binario .Bin: "+cantidadBin);
				if(Encarpetar.Checked == true && cantidadBin>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadBin>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Binario BIN");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.bin*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Binario BIN",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Bin");
				}
				}
			}
			if(cantidadExe>=1){
			Lista.Items.Add("Cantidad de programas .Exe: "+cantidadExe);
				if(Encarpetar.Checked == true && cantidadExe>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadExe>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Ejecutables EXE");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.exe*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Ejecutables EXE",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Exe");
				}
				}
			}
			if(cantidadCmd>=1){
			Lista.Items.Add("Cantidad de programas .Cmd: "+cantidadCmd);
				if(Encarpetar.Checked == true && cantidadCmd>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadCmd>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Ejecutables CMD");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.cmd*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Ejecutables CMD",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Cmd");
				}
				}
			}
			if(cantidadBat>=1){
			Lista.Items.Add("Cantidad de programas .Bat: "+cantidadBat);
				if(Encarpetar.Checked == true && cantidadBat>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadBat>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Ejecutables BAT");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.bat*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Ejecutables BAT",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Bat");
				}
				}
			}
			if(cantidadMsi>=1){
			Lista.Items.Add("Cantidad de Intaladores .Msi: "+cantidadMsi);
				if(Encarpetar.Checked == true && cantidadMsi>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMsi>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Intaladores MSI");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.msi*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Instaladores MSI",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Msi");
				}
				}
			}
			if(cantidadDll>=1){
			Lista.Items.Add("Cantidad de archivos del sistema .Dll: "+cantidadDll);
			if(Encarpetar.Checked == true && cantidadDll>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadDll>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos del Sistema DLL");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.dll*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos del Sistema DLL",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Dll");
				}
				}
			}
			if(cantidadIni>=1){
			Lista.Items.Add("Cantidad de archivos de configuración .Ini: "+cantidadIni);
				if(Encarpetar.Checked == true && cantidadIni>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadIni>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Configuración INI");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ini*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Configuración INI",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ini");
				}
				}
			}
			if(cantidadInk>=1){
			Lista.Items.Add("Cantidad de accesos directos .Ink: "+cantidadInk);
				if(Encarpetar.Checked == true && cantidadInk>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadInk>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Accesos Directos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ink*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Accesos Directos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ink");
				}
				}
			
			}
			}else{
				Lista.Items.Clear();
			}
			
			if(MostrarArchivos.Checked == true){	
			if(cantidadPdfs>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPdfs>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPdfs>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.pdf*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Pdf");
				}
				}
			}
			if(cantidadDocx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadDocx>=1 && CarpetasSubCarpetas.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.docx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Docx");
				}
				}
			}
			if(cantidadDoc>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadDoc>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadDoc>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.doc*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Doc");
				}
				}
			}
			if(cantidadXlsx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXlsx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadXlsx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xlsx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xlsx");
				}
				}
			}
			if(cantidadXls>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXls>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadXls>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xls*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xls");
				}
				}
			}
			if(cantidadEml>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadEml>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadEml>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.eml*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Eml");
				}
				}
			}
			if(cantidadDotx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadDotx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadDotx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.dotx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Dotx");
				}
				}
			}
			if(cantidadXlsm>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXlsm>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadXlsm>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xlsm*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xlsm");
				}
				}
			}
			if(cantidadDif>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadDif>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadDif>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.dif*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Dif");
				}
				}
			}
			if(cantidadOds>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadOds>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadOds>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ods*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ods");
				}
				}
			}
			if(cantidadXlm>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXlm>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadXlm>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xlm*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xlm");
				}
				}
			}
			if(cantidadXps>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXps>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadXps>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xps*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xps");
				}
				}
			}
			if(cantidadXltx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXltx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadXltx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xltx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xltx");
				}
				}
			}
			if(cantidadTxt>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadTxt>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadTxt>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Documentos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.txt*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Documentos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Txt");
				}
				}
			}
			if(cantidadHtm>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadHtm>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadHtm>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.htm*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Htm");
				}
				}
			}
			if(cantidadHtml>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadHtml>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadHtml>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.html*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Html");
				}
				}
			}
			if(cantidadAsd>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadAsd>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadAsd>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.asd*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Asd");
				}
				}
			}
			if(cantidadAspx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadAspx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadAspx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Páginas");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.aspx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Páginas",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Aspx");
				}
				}
			}
			if(cantidadPptx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPptx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPptx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.pptx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Pptx");
				}
				}
			}
			if(cantidadPpt>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPpt>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPpt>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ppt*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ppt");
				}
				}
			}
			if(cantidadPotx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPotx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPotx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.potx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Potx");
				}
				}
			}
			if(cantidadPpam>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPpam>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPpam>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ppam*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ppam");
				}
				}
			}
			if(cantidadPpsx>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPpsx>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPpsx>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Power Points");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ppsx*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Power Points",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ppsx");
				}
				}
			}
			if(cantidadJpg>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadJpg>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadJpg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.jpg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Jpg");
				}
				}
			}
			if(cantidadPng>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPng>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPng>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.png*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Png");
				}
				}
			}
			if(cantidadBmp>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadBmp>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadBmp>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.bmp*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Bmp");
				}
				}
			}
			if(cantidadJpeg>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadJpeg>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadJpeg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.jpeg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Jpeg");
				}
				}
			}
			if(cantidadIco>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadIco>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadIco>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ico*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ico");
				}
				}
			}
			if(cantidadGif>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadGif>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadGif>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.gif*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Gif");
				}
				}
			}
			if(cantidadTif>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadTif>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadTif>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.tif*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Tif");
				}
				}
			}
			if(cantidadTiff>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadTiff>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadTiff>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Imágenes");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.tiff*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Imágenes",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Tiff");
				}
				}
			}
			if(cantidadMpeg>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadMpeg>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadMpeg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mpeg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mpeg");
				}
				}
			}
			if(cantidadMpg>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadMpg>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadMpg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mpg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mpg");
				}
				}
			}
			if(cantidadMkv>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadMkv>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadMkv>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mkv*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mkv");
				}
				}
			}
			if(cantidadAvi>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadAvi>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadAvi>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.avi*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Avi");
				}
				}
			}
			if(cantidadMp4>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadMp4>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadMp4>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mp4*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mp4");
				}
				}
			}
			if(cantidadOgg>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadOgg>=1 && CarpetasSubCarpetas.Checked == false|| EncarpetarSinE.Checked == true && cantidadOgg>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Videos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ogg*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Videos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ogg");
				}
				}
			}
			if(cantidadMp3>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadMp3>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadMp3>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Audios");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.mp3*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Audios",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Mp3");
				}
				}
			}
			if(cantidadWav>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadWav>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadWav>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Audios");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.wav*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Audios",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Wav");
				}
				}
			}
				if(cantidadWma>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadWma>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadWma>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Audios");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.wma*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Audios",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Wma");
				}
				}
			}
			if(cantidadOgg>=1){
			
			}
			if(cantidadZip>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadZip>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadZip>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Comprimidos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.zip*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Comprimidos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Zip");
				}
				}
			}
			if(cantidadRar>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadRar>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadRar>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Comprimidos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.rar*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Comprimidos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Rar");
				}
				}
			}
			if(cantidadIso>=1){
			
					if(EncarpetarSinE.Checked == true && cantidadIso>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadIso>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Comprimidos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.iso*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Comprimidos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Iso");
				}
				}
			}
			if(cantidadJar>=1){
		
				if(EncarpetarSinE.Checked == true && cantidadJar>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadJar>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos JAVA");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.jar*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos JAVA",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Jar");
				}
				}
			}
			if(cantidadJs>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadJs>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadJs>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.js*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Js");
				}
				}
			}
			if(cantidadPhp>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPhp>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadPhp>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.php*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Php");
				}
				}
			}
			if(cantidadCpp>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadCpp>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadCpp>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.cpp*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Cpp");
				}
				}
			}
			if(cantidadC>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadC>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadC>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.c*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .C");
				}
				}
			}
			if(cantidadCs>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadCs>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadCs>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.cs*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Cs");
				}
				}
			}
			if(cantidadPsd>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadPsd>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked ==true && cantidadPsd>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos PhotoShop");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.psd*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos PhotoShop",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Psd");
				}
				}
			}
			if(cantidadXcf>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadXcf>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked ==true && cantidadXcf>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos GIMP");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.xcf*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos GIMP",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Xcf");
				}
				}
			}
			if(cantidadBin>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadBin>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadBin>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Sistema");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.bin*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Sistema",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Bin");
				}
				}
			}
			if(cantidadExe>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadExe>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadExe>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Ejecutables");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.exe*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Ejecutables",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Exe");
				}
				}
			}
			if(cantidadBat>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadBat>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadBat>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Ejecutables");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.bat*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Ejecutables",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Bat");
				}
				}
			}
			if(cantidadMsi>=1){
			
				if(EncarpetarSinE.Checked == true && cantidadMsi>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadMsi>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos Ejecutables");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.msi*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos Ejecutables",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Msi");
				}
				}
			}
			if(cantidadDll>=1){
			
			if(EncarpetarSinE.Checked == true && cantidadDll>=1 && CarpetasSubCarpetas.Checked == false || EncarpetarSinE.Checked == true && cantidadDll>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Sistema");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.dll*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Sistema",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Dll");
				}
				}
			}
			if(cantidadIni>=1){
			
				if(Encarpetar.Checked == true && cantidadIni>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadIni>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Configuración INI");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ini*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Configuración INI",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ini");
				}
				}
			}
			if(cantidadInk>=1){
				Lista.Items.Add("Cantidad de accesos directos .ink: "+cantidadInk);
				if(Encarpetar.Checked == true && cantidadInk>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadInk>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Accesos Directos");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ink*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Accesos Directos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ink");
				}
				}
			
			}
			if(cantidadCss>=1){
				Lista.Items.Add("Cantidad de archivos Css .css: "+cantidadCss);
				if(Encarpetar.Checked == true && cantidadCss>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadCss>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.css*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Accesos Directos",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Css");
				}
				}
			
			}
			if(cantidadSh>=1){
			Lista.Items.Add("Cantidad de archivos Sh .sh: "+cantidadSh);
				if(Encarpetar.Checked == true && cantidadSh>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadSh>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.sh*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Sh");
				}
				}
			}
			if(cantidadSettings>=1){
			Lista.Items.Add("Cantidad de archivos de configuración .settings: "+cantidadSettings);
				if(Encarpetar.Checked == true && cantidadSettings>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadSettings>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Configuración");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.settings*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Configuración",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Settings");
				}
				}
			}
			if(cantidadTheme>=1){
			Lista.Items.Add("Cantidad de archivos Temas .Theme: "+cantidadTheme);
				if(Encarpetar.Checked == true && cantidadTheme>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadTheme>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Temas");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.theme*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Temas",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Theme");
				}
				}
			}
			if(cantidadMsstyle>=1){
			Lista.Items.Add("Cantidad de archivos Temas .msstyle: "+cantidadMsstyle);
				if(Encarpetar.Checked == true && cantidadMsstyle>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMsstyle>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Temas");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.msstyle*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Temas",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Msstyle");
				}
				}
			}
			if(cantidadTtf>=1){
			Lista.Items.Add("Cantidad de archivos Fonts .Ttf: "+cantidadTtf);
				if(Encarpetar.Checked == true && cantidadTtf>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadTtf>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Fuente");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.ttf*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Fuente",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Ttf");
				}
				}
			}
			if(cantidadOtf>=1){
			Lista.Items.Add("Cantidad de archivos Fonts .Otf: "+cantidadOtf);
				if(Encarpetar.Checked == true && cantidadOtf>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadOtf>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Fuente");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.otf*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Fuente",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Otf");
				}
				}
			}
			if(cantidadMd>=1){
			Lista.Items.Add("Cantidad de archivos Md .Md: "+cantidadMd);
				if(Encarpetar.Checked == true && cantidadMd>=1 && CarpetasSubCarpetas.Checked == false || Encarpetar.Checked == true && cantidadMd>=1 && CarpetasSubCarpetas.Checked == false && MostrarArchivos.Checked == false){
				DirectoryInfo crearCarpeta =  Directory.CreateDirectory(Direccion.Text+"\\Archivos de Programación");
				string[] files  = Directory.GetFiles(Direccion.Text,"*.md*");
				foreach(string file in files){
					string filename = Path.GetFileName(file);
					string destino = Path.Combine(Direccion.Text+"\\Archivos de Programación",filename);
					File.Move(file,destino);
					Lista.Items.Add(Idioma.Default.CarpetaCreadaPara+" .Md");
				}
				}
			}
						
			}else{
				Lista.Items.Clear();
			}
			
			for(int i = 0; i <= 100; i++){
			progressBar1.Value = i;
			}
			timer1.Enabled = true;
				timer1.Start();
			Lista.Items.Add("");
			Lista.Items.Add("---------------------------------------------------------------------------------------------------------------");
			Lista.Items.Add(Idioma.Default.ArchivosHallados);
			Lista.Items.Add("---------------------------------------------------------------------------------------------------------------");
			Lista.Items.Add("");
			if(MostrarArchivos.Checked == true){
			foreach (FileInfo fi in nombre)
			{
            		Lista.Items.Add("* "+fi.Name);
       			 }
			}
			Lista.Items.Add("");
			Lista.Items.Add("---------------------------------------------------------------------------------------------------------------");
			Lista.Items.Add(Idioma.Default.CantidadTotal+cantidadTotal);
			Lista.Items.Add("---------------------------------------------------------------------------------------------------------------");
			Lista.Items.Add("La Carpeta pesa: " + TamanoCarpeta(new DirectoryInfo(Direccion.Text))+" "+letra);
			
			if(Encarpetar.Checked == true && CarpetasSubCarpetas.Checked == true){
				MessageBox.Show(Idioma.Default.DesactiveExaminar,"Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			}catch(Exception){
					MessageBox.Show(Idioma.Default.HaOcurrido,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					progressBar1.Value = 0;
				}
		}
		void EliminarClick(object sender, EventArgs e)
		{
			MessageBox.Show("♦                  Creado por AC GAMES\t♦\n♥\t       Anthony Carrillo\t\t♥\n♦\t\tv1.2\t\t♦\n♥    Organiza tus cosas así como tu vida.\t♥","Créditos/Credits",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		void EncarpetarCheckedChanged(object sender, EventArgs e)
		{
			MostrarArchivos.Checked = true;
		}
		void EncarpetarSinECheckedChanged(object sender, EventArgs e)
		{
			MostrarArchivos.Checked = true;
		}
		void LimpiarListaClick(object sender, EventArgs e)
		{
	
			Lista.Items.Clear();
			Direccion.Clear();
			radioButton3.Checked = true;
			MostrarArchivos.Checked = true;
			CarpetasSubCarpetas.Checked = false;
			progressBar1.Value = 0;
		}
		void AbrirCarpetasClick(object sender, EventArgs e)
		{
	
			try{
			Process.Start(Direccion.Text);

			
			radioButton3.Checked = true;
			
			progressBar1.Value = 0;
			}catch(Exception){
				MessageBox.Show(Idioma.Default.SinRuta,"Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		void Panel1MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}
		void SalirClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void SalirMouseDown(object sender, MouseEventArgs e)
		{
			Salir.BackColor = Color.Brown;
		}
		void SalirMouseHover(object sender, EventArgs e)
		{
			Salir.BackColor = Color.Red;
		}
		void SalirMouseLeave(object sender, EventArgs e)
		{
			Salir.BackColor = Color.Transparent;
		}
		void MinimizarClick(object sender, EventArgs e)
		{
			if(WindowState == FormWindowState.Normal){
				WindowState = FormWindowState.Minimized;
			}
		}
		void MinimizarMouseDown(object sender, MouseEventArgs e)
		{
			Minimizar.BackColor = Color.SteelBlue;
		}
		void MinimizarMouseHover(object sender, EventArgs e)
		{
			Minimizar.BackColor = Color.DeepSkyBlue;
		}
		void MinimizarMouseLeave(object sender, EventArgs e)
		{
			Minimizar.BackColor = Color.Transparent;
		}
		void BuscarMouseDown(object sender, MouseEventArgs e)
		{
			Buscar.BackColor = Color.SteelBlue;
		}
		void BuscarMouseHover(object sender, EventArgs e)
		{
			Buscar.BackColor = Color.DeepSkyBlue;
		}
		void BuscarMouseLeave(object sender, EventArgs e)
		{
			Buscar.BackColor = Color.Transparent;
		}
		void LimpiarListaMouseDown(object sender, MouseEventArgs e)
		{
			LimpiarLista.BackColor = Color.Goldenrod;
		}
		void LimpiarListaMouseHover(object sender, EventArgs e)
		{
			LimpiarLista.BackColor = Color.Gold;
		}
		void LimpiarListaMouseLeave(object sender, EventArgs e)
		{
			LimpiarLista.BackColor = Color.Transparent;
		}
		void OrganizarArchivosMouseDown(object sender, MouseEventArgs e)
		{
			OrganizarArchivos.BackColor = Color.NavajoWhite;
		}
		void OrganizarArchivosMouseHover(object sender, EventArgs e)
		{
			OrganizarArchivos.BackColor = Color.PapayaWhip;
		}
		void OrganizarArchivosMouseLeave(object sender, EventArgs e)
		{
			OrganizarArchivos.BackColor = Color.Transparent;
		}
		void AbrirCarpetasMouseDown(object sender, MouseEventArgs e)
		{
			AbrirCarpetas.BackColor = Color.Orange;
		}
		void AbrirCarpetasMouseHover(object sender, EventArgs e)
		{
			AbrirCarpetas.BackColor = Color.Yellow;
		}
		void AbrirCarpetasMouseLeave(object sender, EventArgs e)
		{
			AbrirCarpetas.BackColor = Color.Transparent;
		}
		void BotonSpEnClick(object sender, EventArgs e)
		{
			CambiarIdioma Cambiar = new CambiarIdioma();
			if(SpEn == false){
			SpEn = true;

			BotonSpEn.Text = "Sp";
			Idioma.Default.SpEn = "Spanish";
			}else{
				SpEn = false;	
			BotonSpEn.Text = "En";
			Idioma.Default.SpEn = "English";
			}
			Cambiar.Lenguaje();
			labelOrganizar.Text = Idioma.Default.Organizar;
			labelLimpiar.Text = Idioma.Default.Limpiar;
			labelAbrir.Text = Idioma.Default.AbrirCarpeta;
			CarpetasSubCarpetas.Text = Idioma.Default.ExaminarCarpetas;
			Encarpetar.Text = Idioma.Default.EnCarpetarConExtension;
			EncarpetarSinE.Text = Idioma.Default.EncarpetarSinExtension;
			radioButton3.Text = Idioma.Default.NoEncarpetar;
			Direccion.Text = Idioma.Default.EscribeLaRuta;
		}
	
	}
}
