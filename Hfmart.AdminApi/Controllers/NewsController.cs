using AspNetCore.SEOHelper.Sitemap;
using Hfmart.AdminApi.Common;
using Hfmart.Domain.Entities;
using Hfmart.Domain.ModelEntity;
using Hfmart.Domain.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly HfMartContext _context;
        private readonly IWebHostEnvironment _env;
        public NewsController(HfMartContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #region Bai viet
        // GET: api/<CommonController>
        [HttpGet]
        [Route("r1_GetNews")]
        public async Task<IActionResult> Get()
        {
            var data = await _context.News.ToListAsync();
            return new JsonResult(new { error = 0, data });
        }
        [HttpGet]
        [Route("r1GetById/{id}")]
        public async Task<IActionResult> r1GetById(string id)
        {
            var data = await _context.News.FindAsync(id);
            return new JsonResult(new { error = 0, data });
        }

        // POST api/<CommonController>
        [HttpPost]
        [Route("r2_CreateNews")]
        public async Task<IActionResult> Post(NewsRequest request)
        {
            try
            {
                News obj = new News(request);
                obj.ImgInNews = String.Join(",", request.ImgInNewArrays);
                _context.News.Add(obj);
                await _context.SaveChangesAsync();
                CreateSitemapInRootDirectory();
                return new JsonResult(new { error = 0 });
            }
            catch (Exception)
            {
                return new JsonResult(new { error = 1 });
            }
        }
        [HttpPost]
        [Route("r3_UpdateNews")]
        public async Task<IActionResult> r3_UpdateNews(NewsRequest model)
        {
                model.CreatedDate = DateTime.Now;
                var data = await _context.News.FindAsync(model.Id);
                if (!string.IsNullOrEmpty(model.ImgUrlMaster))
                {
                    data.ImgUrlMaster = model.ImgUrlMaster;
                }
                if (!string.IsNullOrEmpty(model.ImgUrlSeo))
                {
                    data.ImgUrlSeo = model.ImgUrlSeo;
                }
                data.SortContent = model.SortContent;
                data.TitleSeo = model.TitleSeo;
                data.SortSeo = model.SortSeo;
                data.LongContent = model.LongContent;
                data.Title = model.Title;
                data.UrlSeo = HandlePage.nonVietNamese(model.Title);
                await _context.SaveChangesAsync();
                CreateSitemapInRootDirectory();
            
            return new JsonResult(new { error = 0 });

        }
        public string CreateSitemapInRootDirectory()
        {
            var list = new List<SitemapNode>();
            var products = _context.Product.ToList();
            var newss = _context.News.ToList();
            foreach (var item in products)
            {
                list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.ruoutu.com/sanpham/chitiet/", Frequency = SitemapFrequency.Weekly });
            }
            foreach (var item in newss)
            {
                list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.ruoutu.com/kinhnghiem/chitiet/" + item.UrlSeo + "?id=" + item.Id, Frequency = SitemapFrequency.Daily });
            }
            new SitemapDocument().CreateSitemapXML(list, _env.ContentRootPath);
            return "sitemap.xml file should be create in root directory";
        }
        // PUT api/<CommonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommonController>/5
        [HttpDelete]
        [Route("r4_DeleteNews/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _context.News.FindAsync(id);
            _context.News.Remove(data);
            await _context.SaveChangesAsync();
            return new JsonResult(new { error = 0 });
        }
        #endregion
    }
}
