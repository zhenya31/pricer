using System;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

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
        private readonly IUserService _userService;
        
        public DailyService(IPricerService pricerService, IEmailService emailService,  IMonitorItemService monitorItemService,  IUserService userService)
        {
            _pricerService = pricerService;
            _emailService = emailService;
            _monitorItemService = monitorItemService;
            _userService = userService;
        }

        public async Task CheckPrices()
        {
            try
            {
                var items = _monitorItemService.GetAll();
                foreach (var item in items)
                { 
                    await CheckPrice(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task CheckPrice(MonitorItem item)
        {
            //Console.WriteLine($"Запущен мониторинг: {item.Email}, {item.LastPrice}");
            //Console.WriteLine(item.Url);
            PricerResponse result = await _pricerService.GetPrice(item.Url);
            //Console.WriteLine($"Для: {item.Email}, {item.LastPrice}");
            //Console.WriteLine(item.Url);
            //Console.WriteLine($"Цена стала: {result.Price}");
            if (result.Error != null)
            {

                return;
            }
            if (result.Price != item.LastPrice)
            {
                string token = _userService.Get(item.UserId).MessageToken;

                double diff = Math.Abs((double) result.Price - item.LastPrice);
                string direction = result.Price > item.LastPrice ? "выросла" : "снизилась";

                var message = new Message()
                {
                    Token = token,
                    Notification = new Notification
                    {
                        Title = $"Цена {direction} на {diff} руб.",
                        Body = $"Изменилась цена на товар: {item.Name}"
                    },
 
                };
                var messaging = FirebaseMessaging.DefaultInstance;
                
                _monitorItemService.UpdatePrice(item.UserId, (double)result.Price);
                
                Console.WriteLine(await messaging.SendAsync(message));
            }
        }
    }
}