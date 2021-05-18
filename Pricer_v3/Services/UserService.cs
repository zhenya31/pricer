using System;
using System.Collections.Generic;
using System.Linq;
using Pricer_v3.Data;

namespace Pricer_v3
{
    public interface IUserService
    {
        User Get(int id);
        void Delete(int id);
        int Create(string token);
    }
    
    public class UserService : IUserService
    {
        readonly MonitorItemDbContext _context;
        
        public UserService(MonitorItemDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<MonitorItem> GetForUser(int userId)
        {
            return _context.MonitorItems.Where(x=> x.UserId == userId).ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }

        public int Create(string token)
        {
            var user = new User()
            {
                MessageToken = token,
            };
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
    }
}