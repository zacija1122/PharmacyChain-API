using Microsoft.EntityFrameworkCore;
using PharmacyChain.Data;
using PharmacyChain.Models;
using PharmacyChain.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PharmacyChain.Repository
{
    public class PharmacyRepo : IPharmacyRepo
    {
        private readonly ApiDbContext _context;
        public PharmacyRepo(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Pharmacy entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Pharmacies.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Remove(Pharmacy entity)
        {
            _context.Pharmacies.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<Pharmacy>> Find(Expression<Func<Pharmacy, bool>> predicate)
        {
            return await _context.Pharmacies.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
           
            var listOfPharmacy = await _context.Pharmacies.ToListAsync();
            return listOfPharmacy;
        }

        public async Task<Pharmacy> GetById(int id)
        {
            var pharmacyFromContext = await _context.Pharmacies.FirstOrDefaultAsync(p => p.PharmacyId == id);
            return pharmacyFromContext;
        }


        public async Task<bool> isExists(int id)
        {
            return await _context.Pharmacies.AnyAsync(p => p.PharmacyId == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Pharmacy entity)
        {
            _context.Pharmacies.Update(entity);
            return await Save();

        }


    }
}
