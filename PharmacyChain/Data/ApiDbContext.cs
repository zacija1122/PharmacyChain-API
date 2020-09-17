using Microsoft.EntityFrameworkCore;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {

        }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<User> Users{ get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PharmacyEmployees>()
                .HasKey(p => new { p.EmployeeId, p.PharmacyId });

            modelBuilder.Entity<PharmacyEmployees>()
                .HasOne(p => p.Employee)
                .WithMany(p => p.EmployedPharmacyList)
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<PharmacyEmployees>()
               .HasOne(p => p.Pharmacy)
               .WithMany(p => p.PharmacyEmployees)
               .HasForeignKey(p => p.PharmacyId);
        }
    }
}
