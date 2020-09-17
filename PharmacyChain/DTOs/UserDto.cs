using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PharmacyChain.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
