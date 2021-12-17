using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wangkanai.Detection;

namespace WebSaleHfFood.Controllers
{
    public class ShopGridController : Controller
    {
        private readonly IDeviceResolver _deviceResolver;

        public ShopGridController(IDeviceResolver deviceResolver)
        {
            _deviceResolver = deviceResolver;
        }
        public IActionResult Index()
        {
            ViewData["device"] = _deviceResolver.Device.Type;
            return View();
        }
    }
}
