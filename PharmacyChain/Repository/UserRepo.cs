using Microsoft.EntityFrameworkCore;
using PharmacyChain.Contract;
using PharmacyChain.Data;
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
        public async Task<bool> Create(AuthTest entity)
        {
            await _context.AuthTests.AddAsync(entity);
            return await Save();

        }

        public Task<IEnumerable<AuthTest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthTest> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(AuthTest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
           var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> Update(AuthTest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthTest> GetByEmailAndPassworkd(AuthTest user)
        {
            return await _context.AuthTests.Where(p => p.Email.ToLower() == user.Email.ToLower() &&
            p.Name.ToLower() == user.Name.ToLower()).FirstOrDefaultAsync();
        }
    }
}
