using Microsoft.AspNetCore.Mvc;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Contract
{
    public interface IEmployeeRepo : IRepositoryBase<Employee>
    {
        Task <IEnumerable<Employee>> GetEmployeesByLastName(string lastName);


    }
}

