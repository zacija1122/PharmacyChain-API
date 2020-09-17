using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Models
{
    public class UserWithToken:User
    {
        public string AccessToken{ get; set; }

        public UserWithToken(User user)
        {       
            //baca exception provjeri to
            this.Name = user.Name;
            this.Email = user.Email;
        }
    }
}
