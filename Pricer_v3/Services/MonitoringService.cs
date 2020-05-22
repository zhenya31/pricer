using System;
using System.Threading.Tasks;

namespace Pricer_v3
{
    public interface IMonitoringService
    {
        public Task<PricerResponse> StartMonitoring(string email, string url);
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

        public async Task<PricerResponse> StartMonitoring(string email, string url)
        {
            PricerResponse response = await _pricerService.GetPrice(url);
            if (response.Error != null || response.Price == null)
                return response;
            Console.WriteLine(email);
            _monitorItemService.Create(email, url, (double)response.Price);
            foreach (var item in _monitorItemService.GetAll())
            {
                Console.WriteLine(item.Url);
            }
            return response;
        }
    }
}