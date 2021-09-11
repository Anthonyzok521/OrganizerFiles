/*
 * Creado por SharpDevelop.
 * Usuario: Anthony
 * Fecha: 6/9/2021
 * Hora: 6:37 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace OrganizerFiles
{
	/// <summary>
	/// Description of CambiarIdioma.
	/// </summary>
	public class CambiarIdioma
	{
		public CambiarIdioma()
		{
			
			
		}
		public void Lenguaje(){
			if(Idioma.Default.SpEn == "Spanish"){
				
				
				Idioma.Default.Organizar = Idioma.Default.SpOrganizar;
				Idioma.Default.Limpiar = Idioma.Default.SpLimpiar;
				Idioma.Default.AbrirCarpeta = Idioma.Default.SpAbrirCarpeta;
				Idioma.Default.EnCarpetarConExtension = Idioma.Default.SpEncarpetarConExtension;
				Idioma.Default.EncarpetarSinExtension = Idioma.Default.SpArchivarSinE;
				Idioma.Default.EscribeLaRuta = Idioma.Default.SpEscribeLaRuta;
				Idioma.Default.NoEncarpetar = Idioma.Default.SpNoEncarpetar;
				Idioma.Default.ExaminarCarpetas = Idioma.Default.SpExaminarCarpetas;
				Idioma.Default.DesactiveExaminar = Idioma.Default.SpDesactiveExaminar;
				Idioma.Default.TiposDeArchivos = Idioma.Default.SpTiposDeArchivos;
				Idioma.Default.ArchivosHallados = Idioma.Default.SpArchivosHallados;
				Idioma.Default.HaOcurrido = Idioma.Default.SpHaOcurrido;
				Idioma.Default.CantidadTotal = Idioma.Default.SpCantidadTotal;
				Idioma.Default.CarpetaPesa = Idioma.Default.SpCarpetaPesa;
				Idioma.Default.CarpetaCreadaPara = Idioma.Default.SpCarpetaCreadaPara;
				Idioma.Default.SinRuta = Idioma.Default.SpSinRuta;
				
			}else if(Idioma.Default.SpEn == "English"){
				
				
				Idioma.Default.Organizar = Idioma.Default.EnOrganizar;
				Idioma.Default.Limpiar = Idioma.Default.EnLimpiar;
				Idioma.Default.AbrirCarpeta = Idioma.Default.EnAbrirCarpeta;
				Idioma.Default.EnCarpetarConExtension = Idioma.Default.EnEncarpetarConExtension;
				Idioma.Default.EncarpetarSinExtension = Idioma.Default.EnEnCarpetarSinExtension;
				Idioma.Default.EscribeLaRuta = Idioma.Default.EnEscribeLaRuta;
				Idioma.Default.NoEncarpetar = Idioma.Default.EnNoEncarpetar;
				Idioma.Default.ExaminarCarpetas = Idioma.Default.EnExaminarCarpetas;
				Idioma.Default.DesactiveExaminar = Idioma.Default.EnDesactiveExaminar;
				Idioma.Default.TiposDeArchivos = Idioma.Default.EnTiposDeArchivos;
				Idioma.Default.ArchivosHallados = Idioma.Default.EnArchivosHallados;
				Idioma.Default.HaOcurrido = Idioma.Default.EnHaOcurrido;
				Idioma.Default.CantidadTotal = Idioma.Default.EnCantidadTotal;
				Idioma.Default.CarpetaPesa = Idioma.Default.EnCarpetaPesa;
				Idioma.Default.CarpetaCreadaPara = Idioma.Default.EnCarpetaCreadaPara;
				Idioma.Default.SinRuta = Idioma.Default.EnSinRuta;
				
			}
		}
	}
}
