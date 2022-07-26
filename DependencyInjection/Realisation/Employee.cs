using DependencyInjection.Context;
using DependencyInjection.Interfaces;
using DependencyInjection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Realisation
{
    public class Employee : IEmployee<User>
    {
        private readonly DataBaseContext _context;
        public Employee(DataBaseContext context) => _context = context;
        
        public async Task<User> Add(User data)
        {
           await _context.Users.AddAsync(data);
           await _context.SaveChangesAsync();
           return data;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> FullInfo(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> Update(User data)
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
