using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Aspose.App.Live.Demos.UI.Models;
using Aspose.Cells;
using Aspose.Pdf.Facades;
using Aspose.App.Live.Demos.UI.Models.Common;

namespace Aspose.App.Live.Demos.UI.Models.pdf
{
	///<Summary>
	/// AsposeCellsMerger class to merge pdf file
	///</Summary>
	public class AsposeCellsMerger : AsposeCellsBase
	{
		///<Summary>
		/// Merge method to merge pdf document
		///</Summary>
		
		
		public Response Merge(string outputType, InputFiles inputFiles)
		{
			List<Workbook> documents = new List<Workbook>();

			foreach (InputFile inputFile in inputFiles)
			{
				documents.Add(new Workbook(Config.Configuration.WorkingDirectory + inputFile.FolderName + "//" + inputFile.FileName));

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
				var doc = docs[0];
				for (var i = 1; i < docs.Count; i++)
				{
					doc.Combine(docs[i]);
				}
				doc.Save(outPath);
			});
		}
		
	}
}
