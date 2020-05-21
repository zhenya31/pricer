using System;
using System.Threading.Tasks;

namespace Pricer_v3
{
    public interface IDailyService
    {
        public Task CheckPrices();
    }
    public class DailyService : IDailyService
    {
        private readonly IPricerService _pricerService;
        private readonly IEmailService _emailService;
        private readonly IMonitorItemService _monitorItemService;
        
        public DailyService(IPricerService pricerService, IEmailService emailService,  IMonitorItemService monitorItemService)
        {
            _pricerService = pricerService;
            _emailService = emailService;
            _monitorItemService = monitorItemService;
        }

        async public Task CheckPrices()
        {
            await Task.Run( () => {
                (var items, var error) = _monitorItemService.GetAll();
                foreach (var item in items)
                {
                    CheckPrice(item);
                }
            } );
        }

        private async void CheckPrice(MonitorItem item)
        {
            Console.WriteLine($"Запущен мониторинг: {item.Email}, {item.LastPrice}");
            Console.WriteLine(item.Url);
            PricerResponse result = await _pricerService.GetPrice(item.Url);
            Console.WriteLine($"Для: {item.Email}, {item.LastPrice}");
            Console.WriteLine(item.Url);
            Console.WriteLine($"Цена стала: {result.Price}");
            if (result.Error != null)
            {
                _monitorItemService.Delete(item.Id);
                string text = $"Мониторинг товара  {item.Url} в связи с невозможносью распознать цену отменен";
                _emailService.Send(item.Email, "Мониторинг отменен", text);
                return;
            }
            if (result.Price != item.LastPrice)
            {
                _monitorItemService.Delete(item.Id);
                string text = $"Цена товара {item.Url} изменилась с {item.LastPrice} на {result.Price}";
                _emailService.Send(item.Email, "Цена изменилась", text);
            }
        }
    }
}