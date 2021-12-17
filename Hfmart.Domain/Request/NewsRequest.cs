using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfmart.Domain.Request
{
   public class NewsRequest
    {
        public string Id { get; set; }
        public string ImgUrlMaster { get; set; }
        public string Title { get; set; }
        public string SortContent { get; set; }
        public string LongContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderBy { get; set; }
        public string ImgUrlSeo { get; set; }
        public int TypeNews { get; set; }
        public string ReSource { get; set; }
        public string TagId { get; set; }
        public string ImgUrlTrending { get; set; }
        public string ImgUrlPopular { get; set; }
        public string UrlSeo { get; set; }
        public string TitleSeo { get; set; }
        public string SortSeo { get; set; }
        public string ImgInNews { get; set; }
        public List<string> ImgInNewArrays { get; set; }
    }
}
