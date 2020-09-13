using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Models
{
    public class UserWithToken:AuthTest
    {
        public string AccessToken{ get; set; }

        public UserWithToken(AuthTest user)
        {         //baca exception provjeri to
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
        }
    }
}
