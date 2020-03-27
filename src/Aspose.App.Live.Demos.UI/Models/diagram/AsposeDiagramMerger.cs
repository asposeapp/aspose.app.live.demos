using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Aspose.App.Live.Demos.UI.Models;
using Aspose.App.Live.Demos.UI.Models.Common;
using System.IO;

namespace Aspose.App.Live.Demos.UI.Models.diagram
{
	public class AsposeDiagramMerger : AppsBase
	{
		
		public Response Merge(string outputType, InputFiles inputFiles)
		{
			Aspose.App.Live.Demos.UI.Models.License.SetAsposeDiagramLicense();

			List<Aspose.Diagram.Diagram> documents = new List<Aspose.Diagram.Diagram>();

			foreach (InputFile inputFile in inputFiles)
			{
				documents.Add(new Aspose.Diagram.Diagram( Path.Combine( Config.Configuration.WorkingDirectory , inputFile.FolderName , inputFile.FileName)));

			}
			var docs = documents;

			var visioDocs = documents;

			Aspose.Diagram.Diagram dgs = visioDocs[0];

			int iter = 0;
			foreach(var dg in visioDocs)
			{
				if (iter != 0)
				{
					dgs.Combine(dg);
				}
				iter++;
			}

			string folderName = Guid.NewGuid().ToString();
			string fileName = "Merged document.vsdx";

			string strOutputFolder = Config.Configuration.OutputDirectory + folderName +"\\";
			System.IO.Directory.CreateDirectory(strOutputFolder);

			string outpath = strOutputFolder + fileName;
			dgs.Save(outpath, Aspose.Diagram.SaveFileFormat.VSDX);

			return new Response()
			{
				DownloadFileLink = outpath,
				FolderName=folderName,
				FileName =fileName
			};
		}
	}
}
