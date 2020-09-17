using Microsoft.EntityFrameworkCore;
using PharmacyChain.Contract;
using PharmacyChain.Data;
using PharmacyChain.DTOs;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ApiDbContext _context;
        public UserRepo(ApiDbContext context)
        {
            _context = context;

        }
        public async Task<bool> Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            return await Save();

        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
           var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmailAndPassworkd(User user)
        {
            return await _context.Users.Where(p => p.Email.ToLower() == user.Email.ToLower() &&
            p.Name.ToLower() == user.Name.ToLower()).FirstOrDefaultAsync();
        }
    }
}
