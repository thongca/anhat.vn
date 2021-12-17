using Hfmart.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
   public class News : ModelBase
    {
        public string ImgUrlMaster { get; set; }
        public string Title { get; set; }
        public string SortContent { get; set; }
        public string LongContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? OrderBy { get; set; }
        public string ImgUrlSeo { get; set; }
        public int? TypeNews { get; set; }
        public string ReSource { get; set; }
        public string TagId { get; set; }
        public string ImgUrlTrending { get; set; }
        public string ImgUrlPopular { get; set; }
        public string UrlSeo { get; set; }
        public string TitleSeo { get; set; }
        public string SortSeo { get; set; }
        public string ImgInNews { get; set; }
        public News()
        {

        }
        public News(NewsRequest request)
        {
            Id = Guid.NewGuid().ToString();
            ImgUrlSeo = request.ImgUrlSeo;
            ImgUrlMaster = request.ImgUrlMaster;
            Title = request.Title;
            SortContent = request.SortContent;
            LongContent = request.LongContent;
            OrderBy = 1;
            TypeNews = request.TypeNews;
            ReSource = request.ReSource;
            CreatedDate = DateTime.Now;
            TagId = "";
            ImgUrlTrending = request.ImgUrlTrending;
            ImgUrlPopular = request.ImgUrlPopular;
            UrlSeo = request.UrlSeo;
            TitleSeo = request.TitleSeo;
            SortSeo = request.SortSeo;
            ImgInNews = request.ImgInNews;
        }
    }
}
