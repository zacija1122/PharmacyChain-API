using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Models
{
    public class Pharmacy:BaseEntity
    {
        public int PharmacyId { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public List<PharmacyEmployees> PharmacyEmployees { get; set; }
    }
}
