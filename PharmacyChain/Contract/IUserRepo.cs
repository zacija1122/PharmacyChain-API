using PharmacyChain.Data;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Contract
{
    public interface IUserRepo : IRepositoryBase<AuthTest>
    {

        Task<AuthTest> GetByEmailAndPassworkd(AuthTest user);
    }
}
