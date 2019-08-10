using NLog;
using school_diary.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace school_diary.Controllers
{
    [Authorize(Roles = "admins")]
    //thanks to https://stackoverflow.com/questions/42072536/web-api-json-web-service-to-show-folder-file-information
    public class ValuesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET api/values
        public IHttpActionResult Get()
        {
            string ImageryFolder = @WebConfigurationManager.AppSettings["folderName"];
            string fileExtension = WebConfigurationManager.AppSettings["fileExtension"];

            DirectoryInfo d = new DirectoryInfo(ImageryFolder);
            logger.Info("getting files, api value controller");
            FileInfo[] Files = d.GetFiles("*." + fileExtension);
            logger.Info("getting directories, api values controller");
            DirectoryInfo[] directories = d.GetDirectories();
            var list = new List<FileInformation>();
            string dirName = ImageryFolder + directories.Select(x => x.Name).FirstOrDefault();
            d = new DirectoryInfo(dirName);

            FileInfo[] archiveFiles = d.GetFiles("*." + fileExtension);

            logger.Info("creating list of archive files");
            foreach (FileInfo fileInfo in archiveFiles)
            {
                string name = dirName + "/" + fileInfo.Name;
                string mimeType = MimeMapping.GetMimeMapping(fileInfo.Name);
                long size = fileInfo.Length;
                DateTime lastModified = fileInfo.LastWriteTime;
                FileInformation newFile = new FileInformation("Archive", name, mimeType, size, lastModified);

                list.Add(newFile);
            }

            logger.Info("creating list of files");
            foreach (FileInfo fileInfo in Files)
            {
                string name = ImageryFolder + fileInfo.Name;
                string mimeType = MimeMapping.GetMimeMapping(fileInfo.Name);
                long size = fileInfo.Length;
                DateTime lastModified = fileInfo.LastWriteTime;
                FileInformation newFile = new FileInformation("Current", name, mimeType, size, lastModified);
                
                list.Add(newFile);
            }

            //var jsonResult = JsonConvert.SerializeObject(list);
            return Ok(list);
        }


        //thanks to https://codereview.stackexchange.com/questions/169499/download-file-uisng-asp-net-webapi
        [HttpPost, Route("download/{filename}")]
        public HttpResponseMessage GetDataFileResponse(string filename)

        {
            logger.Info("Preparing filepath for download");
            string filePath = WebConfigurationManager.AppSettings["folderName"] + filename;
            FileStream fileStream = File.OpenRead(filePath);
            long fileLength = new FileInfo(filePath).Length;

            var response = new HttpResponseMessage();
            response.Content = new StreamContent(fileStream);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = filename;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = fileLength;
            return response;
        }

        [HttpPost, Route("downloadarchives/{filename}")]
        public HttpResponseMessage GetDataFileResponseArchives(string filename)

        {
            logger.Info("Preparing filepath for download");
            string filePath = WebConfigurationManager.AppSettings["folderName"] + "archives" + "/" + filename;
            FileStream fileStream = File.OpenRead(filePath);
            long fileLength = new FileInfo(filePath).Length;

            var response = new HttpResponseMessage();
            response.Content = new StreamContent(fileStream);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = filename;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = fileLength;
            return response;
        }
    }
}
