using System;
using System.Threading.Tasks;

namespace Pricer_v3
{
    public interface IMonitoringService
    {
        public Task<PricerResponse> StartMonitoring(int userId, string url);
    }
    public class MonitoringService : IMonitoringService
    {
        private readonly IPricerService _pricerService;
        private readonly IMonitorItemService _monitorItemService;
        
        public MonitoringService(IPricerService pricerService, IMonitorItemService monitorItemService)
        {
            _pricerService = pricerService;
            _monitorItemService = monitorItemService;
        }

        public async Task<PricerResponse> StartMonitoring(int userId, string url)
        {
            PricerResponse response = await _pricerService.GetPrice(url);
            if (response.Error != null || response.Price == null)
                return response;
            
            _monitorItemService.Create(userId, url, response.ImageUrl, (double)response.Price, response.Title, response.Site);

            return response;
        }
    }
}