using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Aspose.App.Live.Demos.UI.Models;
using Aspose.App.Live.Demos.UI.Services;
using Aspose.Words;
using Aspose.App.Live.Demos.UI.Models.Common;



namespace Aspose.App.Live.Demos.UI.Models.words
{
	///<Summary>
	/// AsposeWordsMerger class to merge word document
	///</Summary>
	public class AsposeWordsMerger : AsposeWordsBase
  {
    ///<Summary>
    /// Merge method to merge word document
    ///</Summary>
   

		public Response Merge(string outputType, InputFiles inputFiles)
    {
			List<Document> documents = new List<Document>();

			foreach (InputFile inputFile in inputFiles)
			{
				documents.Add(new Document( Path.Combine( Config.Configuration.WorkingDirectory , inputFile.FolderName , inputFile.FileName)));

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
          doc.AppendDocument(docs[i], ImportFormatMode.KeepSourceFormatting);
        SaveDocument(doc, outPath, zipOutFolder);
      });
    }   
  }
}