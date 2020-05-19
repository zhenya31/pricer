using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Pricer_v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorItemController : Controller
    {
        private readonly IMonitorItemService _itemService;
        private readonly IPricerService _pricerService;

        public MonitorItemController(IMonitorItemService itemService, IPricerService pricerService)
        {
            _itemService = itemService;
            _pricerService = pricerService;
        }

        [HttpGet]
        public void Get()
        {
            //return _pricerService.RegSearch("<span class=\"price  product-slider__data__price\">42&nbsp;980 ₽</span>");
        }
        
        [HttpPost]
        public (IEnumerable<MonitorItem> Items, string error) Create()
        {
            _itemService.Create("gg@gg", "http", 1293);
            return _itemService.GetAll();
        }
    }
}