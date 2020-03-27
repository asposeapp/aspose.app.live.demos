using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Aspose.App.Live.Demos.UI.Models;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.App.Live.Demos.UI.Models.Common;

namespace Aspose.App.Live.Demos.UI.Models.pdf
{
	///<Summary>
	/// AsposePdfMerger class to merge pdf file
	///</Summary>
	public class AsposePdfMerger : AsposePdfBase
	{
		///<Summary>
		/// Merge method to merge pdf document
		///</Summary>
		
		
		public Response Merge(string outputType, InputFiles inputFiles)
		{
			List<Document> documents = new List<Document>();

			foreach (InputFile inputFile in inputFiles)
			{
				documents.Add(new Document(Config.Configuration.WorkingDirectory + inputFile.FolderName + "//" + inputFile.FileName));

			}
			var docs = documents;
			if (docs == null)
				return BadDocumentResponse;
			if (docs.Count <= 1 || docs.Count > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(docs);
			Opts.AppName = "Merger";
			Opts.MethodName = "Merge";
			Opts.ResultFileName = $"Merged document{Opts.OutputType}";
			Opts.CreateZip = false;
			Opts.ZipFileName = "Merged document";

			return  Process((inFilePath, outPath, zipOutFolder) =>
			{
				var outputDoc = new Document();
				PdfFileEditor pdfEditor = new PdfFileEditor();
				pdfEditor.Concatenate(docs.ToArray(), outputDoc);
				outputDoc.Save(outPath);
			});
		}
		
	}
}
