using Hfmart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class NewsViewModel
    {
        public string Id { get; set; }
        public string ImgUrlMaster { get; set; }
        public string Title { get; set; }
        public string SortContent { get; set; }
        public string LongContent { get; set; }
        [DataType(DataType.Date)]
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
        public NewsViewModel()
        {

        }
        public NewsViewModel(News request, string baseUrl)
        { 
            Id = request.Id;
            ImgUrlSeo = baseUrl + request.ImgUrlSeo;
            ImgUrlMaster = baseUrl + request.ImgUrlMaster;
            Title = request.Title;
            SortContent = request.SortContent;
            LongContent = request.LongContent;
            OrderBy = 1;
            TypeNews = request.TypeNews??0;
            ReSource = request.ReSource;
            CreatedDate = DateTime.Now;
            ImgUrlTrending = baseUrl + request.ImgUrlTrending;
            ImgUrlPopular = baseUrl + request.ImgUrlPopular;
            UrlSeo = request.UrlSeo;
            TitleSeo = request.TitleSeo;
            SortSeo = request.SortSeo;
            ImgInNews = request.ImgInNews;
        }
    }
}
