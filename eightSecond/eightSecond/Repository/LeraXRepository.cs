using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eightSecond.Repository
{
    public class LeraXRepository : Ilerax
    {
        LeraXContext _context;
        public LeraXRepository(DbContextOptions<LeraXContext> options)
        {
            _context = new LeraXContext(options);
        }
        public void Add(LeraX entity)
        {
            _context.Set<LeraX>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<LeraX> GetAll()
        {
            return _context.Set<LeraX>().ToList();
        }

        public LeraX GetById(int id)
        {
            return _context.Set<LeraX>().Find(id);
        }

        public void Remove(LeraX entity)
        {
            _context.LeraXes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(LeraX entity)
        {
            var a = _context.LeraXes.Find(entity.Id);
            if (a == null)
            {
                return;
            }
            a.Firstname = entity.Firstname;
            a.Lastname = entity.Lastname;
            a.Password = entity.Password;
            a.Role = entity.Role;
            a.Status = entity.Status;
            a.Email = entity.Email;
            _context.LeraXes.Update(a);
            _context.SaveChanges();
        }
    }
}
