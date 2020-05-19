using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pricer_v3.Data;


namespace Pricer_v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricerController : ControllerBase
    {
        private readonly IMonitoringService _monitoringService;

        public PricerController(IMonitoringService monitoringService)
        {
            _monitoringService = monitoringService;
        }

        [HttpGet]
        public async Task<PricerResponse> Get(string email, string url)
        {
            return await _monitoringService.StartMonitoring(email, url);
        }
    }
}