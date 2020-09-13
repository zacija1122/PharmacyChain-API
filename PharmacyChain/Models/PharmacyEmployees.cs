using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Models
{
    public class PharmacyEmployees
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int PharmacyId { get; set; }
        [Required]
        public DateTime EmployedSince { get; set; }
        public DateTime EmployedUntil { get; set; }


        public Employee Employee { get; set; }
        public Pharmacy Pharmacy { get; set; }

    }
}
