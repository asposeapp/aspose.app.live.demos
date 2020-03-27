using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.lic";

		///<Summary>
		/// SetAsposePdfLicense method to Aspose.PDF License
		///</Summary>
		public static void SetAsposeProductFamilyLicense(string product)
		{
			
			try
			{
				Aspose.Pdf.License awLic = new Aspose.Pdf.License();
				awLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		///<Summary>
		/// SetAsposePdfLicense method to Aspose.PDF License
		///</Summary>
		public static void SetAsposePdfLicense()
		{
			try
			{
				Aspose.Pdf.License awLic = new Aspose.Pdf.License();
            awLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		///<Summary>
		/// SetAsposeWordsLicense method to Aspose.Words License
		///</Summary>
		public static void SetAsposeWordsLicense()
		{
			try
			{
				Aspose.Words.License awLic = new Aspose.Words.License();
				awLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		///<Summary>
		/// SetAsposeCellsLicense method to Aspose.Cells License
		///</Summary>
		public static void SetAsposeCellsLicense()
		{
			try
			{
				Aspose.Cells.License acLic = new Aspose.Cells.License();
				acLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAsposeEmailLicense method to Aspose.Email License
		///</Summary>
		public static void SetAsposeEmailLicense()
		{
			try
			{
				Aspose.Email.License acLic = new Aspose.Email.License();
				acLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAsposeSlidesLicense method to Aspose.Slides License
		///</Summary>
		public static void SetAsposeSlidesLicense()
		{
			try
			{
				Aspose.Slides.License acLic = new Aspose.Slides.License();
				acLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		///<Summary>
		/// SetAsposeImagingLicense method to Aspose.Imaging License
		///</Summary>
		public static void SetAsposeImagingLicense()
		{
			try
			{
				Aspose.Imaging.License lic = new Aspose.Imaging.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
		///<Summary>
		/// SetAsposeHtmlLicense method to Aspose.Html License
		///</Summary>
		public static void SetAsposeHtmlLicense()
		{
			try
			{
				Aspose.Html.License lic = new Aspose.Html.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAsposeTasksLicense method to Aspose.Tasks License
		///</Summary>
		public static void SetAsposeTasksLicense()
		{
			try
			{
				Aspose.Tasks.License lic = new Aspose.Tasks.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAsposeDiagramLicense method to Aspose.Diagram License
		///</Summary>
		public static void SetAsposeDiagramLicense()
		{
			try
			{
				Aspose.Diagram.License lic = new Aspose.Diagram.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAsposeNoteLicense method to Aspose.Note License
		///</Summary>
		public static void SetAsposeNoteLicense()
		{
			try
			{
				Aspose.Note.License lic = new Aspose.Note.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAsposeGisLicense method to Aspose.Gis License
		///</Summary>
		public static void SetAsposeGisLicense()
		{
			try
			{
				Aspose.Gis.License lic = new Aspose.Gis.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
		///<Summary>
		/// SetAsposeCadLicense method to Aspose.CAD License
		///</Summary>
		public static void SetAsposeCadLicense()
		{
			try
			{
				Aspose.CAD.License lic = new Aspose.CAD.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		///<Summary>
		/// SetAspose3dLicense method to Aspose.ThreeD License
		///</Summary>
		public static void SetAspose3dLicense()
		{
			try
			{

				Aspose.ThreeD.License lic = new Aspose.ThreeD.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		///<Summary>
		/// SetAsposePsdLicense method to Aspose.PSD License
		///</Summary>
		public static void SetAsposePsdLicense()
		{
			try
			{
				Aspose.PSD.License lic = new Aspose.PSD.License();
			lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		///<Summary>
		/// SetAsposePageLicense method to Aspose.Page License
		///</Summary>
		public static void SetAsposePageLicense()
		{
			try
			{
				Aspose.Page.License lic = new Aspose.Page.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
