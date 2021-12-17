using Hfmart.File.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hfmart.File.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            List<string> paths = new List<string>();
            try
            {
                
                var files = Request.Form.Files;
                if (files.Count != 0)
                {
                    foreach (var item in Request.Form.Files)
                    {
                        var folderPath = Path.Combine("resources", "img", "product");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        string exttension = "";
                        if (item != null)
                        {
                            exttension = Path.GetExtension(item.FileName);
                        }
                        var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderPath, fileName);
                        var str = ConvertPathStringToDB(dbPath);
                        paths.Add(str);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                    }
                }
                  
                return new ObjectResult(new { path = paths });
            }
            catch (Exception)
            {
                return new ObjectResult(new { path = paths });
            }
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadFileNews")]
        public IActionResult UploadFileNews()
        {
            List<string> paths = new List<string>();
            try
            {

                var files = Request.Form.Files;
                if (files.Count != 0)
                {
                    foreach (var item in Request.Form.Files)
                    {
                        var folderPath = Path.Combine("resources", "img", "news");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        string exttension = "";
                        if (item != null)
                        {
                            exttension = Path.GetExtension(item.FileName);
                        }
                        var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderPath, fileName);
                        var str = ConvertPathStringToDB(dbPath);
                        paths.Add(str);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                    }
                }

                return new ObjectResult(new { path = paths });
            }
            catch (Exception)
            {
                return new ObjectResult(new { path = paths });
            }
        }
        private static string ConvertPathStringToDB(string path)
        {
            return path.Replace('\\', '/');
        }
    }
}

