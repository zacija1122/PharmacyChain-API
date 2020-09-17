using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyChain.Contract;
using PharmacyChain.Data;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace PharmacyChain.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApiDbContext _context;

        public EmployeeRepo(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Employee entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Employees.AddAsync(entity);
            return await Save();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
           return await _context.Employees.ToListAsync();
        }


        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
        }

        public async Task <IEnumerable<Employee>> GetEmployeesByLastName(string lastName)
        {
            return await _context.Employees.Where(p => p.LastName.ToLower() == lastName.ToLower()).ToListAsync();
            
        }

        public async Task<bool> isExists(int id)
        {
            return await _context.Employees.AllAsync(p => p.EmployeeId == id);
                
        }


        public async Task<bool> Remove(Employee entity)
        {
             _context.Employees.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Employee entity)
        {
            _context.Employees.Update(entity);
            return await Save();
        }
    }
}
