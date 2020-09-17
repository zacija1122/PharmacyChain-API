using PharmacyChain.Data;
using PharmacyChain.DTOs;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Contract
{
    public interface IUserRepo : IRepositoryBase<User>
    {

        Task<User> GetByEmailAndPassworkd(User user);
    }
}
