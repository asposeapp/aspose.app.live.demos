using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.App.Live.Demos.UI.FileProcessing;
using System.Web;
using System.Web.Http;
using Aspose.App.Live.Demos.UI.Models;
using Aspose.Cells;
using Aspose.Pdf.Facades;
using Aspose.App.Live.Demos.UI.Models.Common;
using Aspose.Email.Mapi;
using Aspose.App.Live.Demos.UI.Helpers;
using Aspose.App.Live.Demos.UI.Config;

namespace Aspose.App.Live.Demos.UI.Models.pdf
{
	///<Summary>
	/// AsposeEmailMerger class to merge email files
	///</Summary>
	public class AsposeEmailMerger : AsposeCellsBase
	{
	
		///<Summary>
		/// Merge method to merge email files
		///</Summary>
		public Response Merge(string outputType, InputFiles inputFiles)
		{
			Aspose.App.Live.Demos.UI.Models.License.SetAsposeEmailLicense();			
			Aspose.Email.Mapi.MapiMessage mail = null;
						
			
			if (inputFiles.Count > 0)
			{
				mail = MapiHelper.GetMapiMessageFromFile(Path.Combine(Config.Configuration.WorkingDirectory, inputFiles[0].FolderName, inputFiles[0].FileName));
				if (mail == null)
					throw new Exception("Invalid file format");
			}			
				var processor = new CustomSingleOrZipFileProcessor()
				{

					CustomProcessMethod = (string inputFilePath, string outputFolderPath) =>
					{
						for (int i = 1; i < inputFiles.Count; i++)
						{
							if (i > 1)
							{
								mail = MapiHelper.GetMapiMessageFromFile(Path.Combine(outputFolderPath, "MergedMessage.msg"));
								if (mail == null)
									throw new Exception("Invalid file format");
							}

							var addedMail = MapiHelper.GetMapiMessageFromFile(Path.Combine(Config.Configuration.WorkingDirectory, inputFiles[i].FolderName, inputFiles[i].FileName));

							if (addedMail == null)
								throw new Exception("Invalid file format");

							var folderPath = Path.Combine(Config.Configuration.OutputDirectory, Guid.NewGuid().ToString());
							var filePath = Path.Combine(folderPath, "Merged.html");
							Directory.CreateDirectory(folderPath);

							MergeHtmlContentsAndSaveInFile(mail.BodyHtml, addedMail.BodyHtml, filePath);
							mail.SetBodyContent(System.IO.File.ReadAllText(filePath), BodyContentType.Html);

							Directory.Delete(folderPath, true);

							if (addedMail.Attachments != null)
								foreach (var attachment in addedMail.Attachments)
									mail.Attachments.Add(attachment);

							mail.Save(Path.Combine(outputFolderPath, "MergedMessage.msg"));
						}
						
					}
				};
			return new Response()
			{
				DownloadFileLink = "",
				FolderName = "",
				FileName = "MergedMessage.msg"
			};



		}
		///<Summary>
		/// MergeHtmlContentsAndSaveInFile method to merge html contents and save in file
		///</Summary>
		public static void MergeHtmlContentsAndSaveInFile(string srcHtml, string destHtml, string temporaryHtmlPath)
		{
			var htmlDocument1 = new Aspose.Html.HTMLDocument(srcHtml, "");
			var htmlDocument2 = new Aspose.Html.HTMLDocument(destHtml, "");

			htmlDocument1.Body.AppendChild(htmlDocument2.Body);

			if (htmlDocument1.Title != htmlDocument2.Title)
			{
				htmlDocument1.Title += htmlDocument2.Title;
			}

			var headElement = htmlDocument1.GetElementsByTagName("head")[0];
			var metaCollection1 = htmlDocument2.QuerySelectorAll("meta[name]").Cast<Html.HTMLMetaElement>();
			var metaCollection2 = htmlDocument2.QuerySelectorAll("meta[name]").Cast<Html.HTMLMetaElement>();

			foreach (var metaElement1 in metaCollection1)
			{
				Html.HTMLMetaElement metaElement2;
				try
				{
					metaElement2 = metaCollection2.First(e => e.Name == metaElement1.Name);
					metaElement1.Content += metaElement2.Content;
				}
				catch (System.InvalidOperationException)
				{
					headElement.AppendChild(metaElement1);
				}
			}

			htmlDocument1.Save(temporaryHtmlPath);
		}

		
		
	}
}
