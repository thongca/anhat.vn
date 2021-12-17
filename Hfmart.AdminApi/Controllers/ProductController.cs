using Hfmart.Domain.Entities;
using Hfmart.Domain.ModelEntity;
using Hfmart.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hfmart.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static Regex ConvertToUnsign_rg = null;
        private readonly HfMartContext _context;
        public ProductController(HfMartContext context)
        {
            _context = context;
        }
        //Post: api/MyWorkFlow/r2AssignWork
        [HttpPost]
        [Route("CreatedProduct")]
        public async Task<IActionResult> CreatedProduct(ProductRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.ParentId))
                {
                    Product obj = new Product(request);
                    obj.Id = Guid.NewGuid().ToString();
                    _context.Product.Add(obj);
                    ProductVariant proVar = new ProductVariant(request);
                    proVar.ProductId = obj.Id;
                    proVar.Id = Guid.NewGuid().ToString();
                    proVar.Img = ConvertPathStringToDB(request.Img);
                    proVar.ImgSeo = ConvertPathStringToDB(request.ImgSeo);
                    _context.ProductVariant.Add(proVar);
                    foreach (var item in request.ProductSizes)
                    {
                        ProductVariantPrice sizepro = new ProductVariantPrice();
                        sizepro.ProductId = obj.Id;
                        sizepro.VariantId = proVar.Id;
                        sizepro.Price = item.Price;
                        sizepro.Size = item.Size;
                        sizepro.Unit = item.Unit;
                        sizepro.Id = Guid.NewGuid().ToString();
                        _context.ProductVariantPrice.Add(sizepro);
                    }

                    foreach (var item in request.ProductImgs)
                    {
                        ProductImg prcImg = new ProductImg()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ImgZoom = ConvertPathStringToDB(item.ImgZoom),
                            ImgHome = ConvertPathStringToDB(item.ImgZoom),
                            ImgSeo = ConvertPathStringToDB(item.ImgZoom),
                            ProductId = obj.Id,
                            SortBy = 1,
                            ProductVariantId = proVar.Id
                        };
                        _context.ProductImg.Add(prcImg);
                    }
                }
                else
                {
                  
                    ProductVariant proVar = new ProductVariant(request);

                    proVar.ProductId = request.ParentId;
                    proVar.Id = Guid.NewGuid().ToString();
                    _context.ProductVariant.Add(proVar);
                    foreach (var item in request.ProductImgs)
                    {
                        ProductImg prcImg = new ProductImg()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ImgZoom = ConvertPathStringToDB(item.ImgZoom),
                            ImgHome = ConvertPathStringToDB(item.ImgZoom),
                            ImgSeo = ConvertPathStringToDB(item.ImgZoom),
                            ProductId = request.ParentId,
                            SortBy = 1,
                            ProductVariantId = proVar.Id
                        };
                        _context.ProductImg.Add(prcImg);
                    }
                }
                await _context.SaveChangesAsync();

                return new ObjectResult(new { error = 0, ms = "Thêm mới thành công!" });
            }
            catch (Exception)
            {
                return new ObjectResult(new { error = 1, ms = "Thêm mới lỗi!" });
            }
        }

        //Post: api/MyWorkFlow/r2AssignWork
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductRequest request)
        {
            try
            {

                var proVar = await _context.ProductVariant.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (!string.IsNullOrEmpty(request.Img))
                {
                    proVar.Img = ConvertPathStringToDB(request.Img);
                }
                if (!string.IsNullOrEmpty(request.ImgSeo))
                {
                    proVar.ImgSeo = ConvertPathStringToDB(request.ImgSeo);
                }
                proVar.Ingredients = request.Ingredients;
                proVar.Name = request.Name;
                proVar.MoreInfo = request.MoreInfo;
                proVar.CampaignId = request.CampaignId;
                proVar.Price = request.Price;
                proVar.Unit = request.Unit;
                proVar.DescriptionSeo = request.SeoContend;
                proVar.Description = request.Description;
                if (request.ProductSizes != null)
                {
                    foreach (var item in request.ProductSizes)
                    {
                        var sizepro = await _context.ProductVariantPrice.FirstOrDefaultAsync(x => x.Id == item.Id);
                        if (proVar.Price > item.Price)
                        {
                            proVar.Price = item.Price;
                            proVar.Unit = item.Unit;
                        }
                        sizepro.Price = item.Price;
                        sizepro.Size = item.Size;
                        sizepro.Unit = item.Unit;
                    }
                }
               
                if (request.ProductImgs != null)
                {
                    foreach (var item in request.ProductImgs)
                    {
                        var prcImg = await _context.ProductImg.FirstOrDefaultAsync(x => x.Id == item.Id);
                        if (prcImg == null)
                        {
                            ProductImg prcImgObj = new ProductImg()
                            {
                                Id = Guid.NewGuid().ToString(),
                                ImgZoom = ConvertPathStringToDB(item.ImgZoom),
                                ImgHome = ConvertPathStringToDB(item.ImgZoom),
                                ImgSeo = ConvertPathStringToDB(item.ImgZoom),
                                ProductId = proVar.ProductId,
                                SortBy = 1,
                                ProductVariantId = proVar.Id
                            };
                            _context.ProductImg.Add(prcImgObj);
                        } else
                        {
                            prcImg.ImgZoom = item.ImgZoom;
                        }
                        
                    }
                }
               
                await _context.SaveChangesAsync();

                return new ObjectResult(new { error = 0, ms = "Cập nhật thành công!" });
            }
            catch (Exception)
            {
                return new ObjectResult(new { error = 1, ms = "Cập nhật  lỗi!" });
            }
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var listprod = await _context.ProductVariant.Select(a => new
            {
                Name = a.Name,
                Id = a.Id,
                Img = a.Img,
                a.Description,
                a.ImgSeo,
                a.Ingredients,
                a.MoreInfo,
                Prices = _context.ProductVariantPrice.Where(x => x.VariantId == a.Id).ToList(),
                ImgDetails = _context.ProductImg.Where(x => x.ProductVariantId == a.Id).ToList()
            }).ToListAsync();
            return new ObjectResult(new { error = 0, data = listprod, ms = "Get product success!" });
        }
        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var prod = await (from a in _context.ProductVariant
                              join b in _context.Product on a.ProductId equals b.Id
                              where a.Id == id
                              select new
                              {
                                  Name = a.Name,
                                  Id = a.Id,
                                  Img = a.Img,
                                  b.GroupId,
                                  a.Description,
                                  a.ImgSeo,
                                  a.Price,
                                  a.Unit,
                                  a.ProductId,
                                  a.CampaignId,
                                  a.Ingredients,
                                  a.MoreInfo,
                                  ProductSizes = _context.ProductVariantPrice.Where(x => x.VariantId == a.Id).ToList(),
                                  ProductImgs = _context.ProductImg.Where(x => x.ProductVariantId == a.Id).ToList()
                              }).FirstOrDefaultAsync();
            return new ObjectResult(new { error = 0, data = prod, ms = "Get product success!" });
        }
        public static string ConvertToUnsign(string strInput)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ", " "};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y", "-"};
            for (int i = 0; i < arr1.Length; i++)
            {
                strInput = strInput.Replace(arr1[i], arr2[i]);
                strInput = strInput.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return strInput;
        }
        private static string ConvertPathStringToDB(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            return path.Replace('\\', '/');
        }
        private static bool Base64ToImage(string base64String, string path)
        {
            try
            {
                // Convert base 64 string to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                    {
                        ms.CopyTo(file);
                        return true;
                    }
                }

            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
