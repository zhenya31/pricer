using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using Pricer_v3.Data;


namespace Pricer_v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMonitorItemService _monitorItemService;

        public ItemsController(IMonitorItemService monitorItemService)
        {
            _monitorItemService = monitorItemService;
        }
        
        [HttpGet]
        public IEnumerable<MonitorItem> Get(int userId)
        {
            return _monitorItemService.GetForUser(userId);
        }
        
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            _monitorItemService.Delete(id);
            return 1;
        }
    }
}