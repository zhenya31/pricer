using System;
using System.Collections.Generic;
using System.Linq;
using Pricer_v3.Data;

namespace Pricer_v3
{
    public interface IMonitorItemService
    {
        IEnumerable<MonitorItem> GetAll();
        IEnumerable<MonitorItem> GetForUser(int userId);
        MonitorItem Get(int id);
        void Delete(int id);
        void UpdatePrice(int id, double price);
        void Create(string email, string url, double price);
        void Create(int userId, string url, string image, double price, string name, string site);
    }
    
    public class MonitorItemService : IMonitorItemService
    {
        readonly MonitorItemDbContext _context;
        
        public MonitorItemService(MonitorItemDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<MonitorItem> GetForUser(int userId)
        {
            return _context.MonitorItems.Where(x=> x.UserId == userId).ToList();
        }

        public MonitorItem Get(int id)
        {
            return _context.MonitorItems.Find(id);
        }
        public IEnumerable<MonitorItem> GetAll()
        {
            return _context.MonitorItems.ToList();
        }

        public void Delete(int id)
        {
            _context.MonitorItems.Remove(_context.MonitorItems.Find(id));
            _context.SaveChanges();
        }

        public void UpdatePrice(int id, double price)
        {
            var item = _context.MonitorItems.Find(id);
            item.LastPrice = price;
            _context.MonitorItems.Update(item);
            _context.SaveChanges();
        }

        public void Create(string email, string url, double price)
        {
            var item = new MonitorItem() { Email = email, Url = url, LastPrice = price };
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Create(int userId, string url, string image, double price, string name, string site)
        {
            var item = new MonitorItem()
            {
                UserId = userId, 
                Url = url,
                Name = name,
                LastPrice = price,
                FirstPrice = price,
                Site = site,
                ImageUrl = image,
            };
            _context.Add(item);
            _context.SaveChanges();
        }
    }
}