using Hfmart.Domain.Entities;
using Hfmart.Domain.ModelEntity;
using Hfmart.Domain.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HfMartContext _context;
        private readonly IWebHostEnvironment _env;
        public OrderController(HfMartContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: api/<CommonController>
        [HttpPost]
        [Route("addOrder")]
        public async Task<IActionResult> AddOrder(OrderRequest request)
        {
            Order order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                CustomerName = request.FullName,
                CustomerMobile = request.Mobile,
                CustomerAddress = request.AddressDelivery,
                OrderDelivery = request.AddressDelivery,
                Note = request.Note,
                OrderDeliveryTime = DateTime.Now,
                TotalPayment = request.TotalPayment
            };
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in request.OrderDetails)
            {
                OrderDetail detail = new OrderDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductVariantId = item.id,
                    ProductName = item.name,
                    VariantUnit = item.unit,
                    PriceSale = item.salePrice,
                    Quantity = item.quantity,
                    SizeId = item.variantSizeId,
                    VariantName = item.name,
                    OrderId = order.Id,
                };
                orderDetails.Add(detail);
            }
            _context.Order.Add(order);
            _context.OrderDetail.AddRange(orderDetails);
            await _context.SaveChangesAsync();
            return new JsonResult(new { error = 0 });
        }
        [HttpGet]
        [Route("r1GetById/{id}")]
        public async Task<IActionResult> r1GetById(int id)
        {
            var data = await _context.News.FindAsync(id);
            return new JsonResult(new { error = 0, data });
        }

    }
}
