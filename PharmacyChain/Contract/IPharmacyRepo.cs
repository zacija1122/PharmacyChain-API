using Microsoft.AspNetCore.Mvc;
using PharmacyChain.Contract;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PharmacyChain.Repository.IRepository
{
   public interface IPharmacyRepo:IRepositoryBase<Pharmacy>
    {
        Task<IEnumerable<Pharmacy>> Find(Expression<Func<Pharmacy, bool>> predicate);

    }
}
