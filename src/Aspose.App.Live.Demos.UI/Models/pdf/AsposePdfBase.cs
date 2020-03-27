using Aspose.App.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.App.Live.Demos.UI.Helpers;
using Aspose.App.Live.Demos.UI.Services;
using Aspose.Pdf;
using Aspose.Pdf.Drawing;
using Newtonsoft.Json.Linq;

using Path = System.IO.Path;


namespace Aspose.App.Live.Demos.UI.Models.pdf
{
	///<Summary>
	/// AsposePdfBase class 
	///</Summary>

	public class AsposePdfBase : AppsBase
  {
    /// <summary>
    /// Maximum number of files which can be uploaded for MVC Aspose.Words apps
    /// </summary>
    protected const int MaximumUploadFiles = 10;

    /// <summary>
    /// Original file format SaveAs option for multiple files uploading. By default, "-"
    /// </summary>
    protected const string SaveAsOriginalName = ".-";
    
    /// <summary>
    /// Response when uploaded files exceed the limits
    /// </summary>
    protected Response MaximumFileLimitsResponse = new Response()
    {
      Status = $"Number of files should be less {MaximumUploadFiles}",
      StatusCode = 500
    };

		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};


		///<Summary>
		/// Options class 
		///</Summary>
		public class Options
    {
      ///<Summary>
      /// AppName
      ///</Summary>
      public string AppName;
      ///<Summary>
      /// FolderName
      ///</Summary>
      public string FolderName;
      ///<Summary>
      /// FileName
      ///</Summary>
      public string FileName;

      private string _outputType;

      /// <summary>
      /// By default, it is the extension of FileName - e.g. ".docx"
      /// </summary>
      public string OutputType
      {
        get => _outputType;
        set
        {
          if (!value.StartsWith("."))
            value = "." + value;
          _outputType = value.ToLower();
        }
      }

      /// <summary>
      /// Check if OuputType is a picture extension
      /// </summary>
      public bool IsPicture
      {
        get
        {
          switch (_outputType)
          {
            case ".bmp":
            case ".emf":
            case ".png":
            case ".jpg":
            case ".jpeg":
            case ".gif":
            case ".tiff":
              return true;
            default:
              return false;
          }
        }
      }

      ///<Summary>
      /// ResultFileName
      ///</Summary>
      public string ResultFileName = "";

      ///<Summary>
      /// MethodName
      ///</Summary>
      public string MethodName;
			///<Summary>
			/// ModelName
			///</Summary>
			public string ModelName;
      ///<Summary>
      /// CreateZip
      ///</Summary>
      public bool CreateZip = false;
      ///<Summary>
      /// CheckNumberOfPages
      ///</Summary>
      public bool CheckNumberOfPages = false;
      ///<Summary>
      /// DeleteSourceFolder
      ///</Summary>
      public bool DeleteSourceFolder = false;

      /// <summary>
      /// Output zip filename (without '.zip'), if CreateZip property is true
      /// By default, FileName + AppName
      /// </summary>
      public string ZipFileName;

      /// <summary>
      /// AppSettings.WorkingDirectory + FolderName + "/" + FileName
      /// </summary>
      public string WorkingFileName
      {
        get
        {
          if (System.IO.File.Exists(Config.Configuration.WorkingDirectory + FolderName + "/" + FileName))
            return Config.Configuration.WorkingDirectory + FolderName + "/" + FileName;
          return Config.Configuration.OutputDirectory + FolderName + "/" + FileName;
        }
      }
    }
    /// <summary>
    /// init Options
    /// </summary>
    protected Options Opts = new Options();
    
    /// <summary>
    /// UTF8WithoutBom
    /// </summary>
    protected static readonly Encoding UTF8WithoutBom = new UTF8Encoding(false);



		/// <summary>
		/// AsposePdfBase
		/// </summary>
		public AsposePdfBase()
    {
    
      Opts.ModelName = GetType().Name;
    }

		/// <summary>
		/// AsposePdfBase 
		/// </summary>
		static AsposePdfBase()
    {
			Aspose.App.Live.Demos.UI.Models.License.SetAsposePdfLicense();
      
    }

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="docs"></param>
		protected void SetDefaultOptions( List< Document> docs)
		{
			if (docs.Count > 0)
			{
				SetDefaultOptions(Path.GetFileName(docs[0].FileName));
				Opts.CreateZip = docs.Count > 1 || Opts.IsPicture;
			}
		}



		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="filename"></param>
		private void SetDefaultOptions(string filename)
    {
      Opts.ResultFileName = filename;
      Opts.FileName = Path.GetFileName(filename);

      var query = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
      string outputType = null;
      if (query.ContainsKey("outputType"))
        outputType = query["outputType"];
      Opts.OutputType = !string.IsNullOrEmpty(outputType)
        ? outputType
        : Path.GetExtension(Opts.FileName);

      Opts.ResultFileName = Opts.OutputType == SaveAsOriginalName
        ? Opts.FileName
        : Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
    }
    
   

    /// <summary>
    /// Process
    /// </summary>
    protected Response Process(ActionDelegate action)
    {
      if (string.IsNullOrEmpty(Opts.OutputType) && !string.IsNullOrEmpty(Opts.FileName))
        Opts.OutputType = Path.GetExtension(Opts.FileName);

      if (Opts.OutputType == ".html" || Opts.IsPicture)
        Opts.CreateZip = true;

      if (string.IsNullOrEmpty(Opts.ZipFileName))
        Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.AppName;
      
      var outputType = Opts.OutputType;
      if (outputType == SaveAsOriginalName && !string.IsNullOrEmpty(Opts.FileName))
        outputType = Path.GetExtension(Opts.FileName);

      return Process(Opts.ModelName, Opts.ResultFileName, Opts.FolderName, outputType, Opts.CreateZip, Opts.CheckNumberOfPages,
         Opts.MethodName, action, Opts.DeleteSourceFolder, Opts.ZipFileName);
    }   

    #region Common
    /// <summary>
    /// IsValidRegex
    /// </summary>
    public static bool IsValidRegex(string pattern)
    {
      if (string.IsNullOrEmpty(pattern))
        return false;
      try
      {
        Regex.Match("", pattern);
      }
      catch (ArgumentException)
      {
        return false;
      }
      return true;
    }

    

   
    #endregion
  }
}
