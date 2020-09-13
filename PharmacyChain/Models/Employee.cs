using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Models
{
    public class Employee:BaseEntity
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public int MyProperty { get; set; }
        [Required]
        public EGender Gender { get; set; }
        public enum EGender {NA,M,F}
        [Required]
        public DateTime BirthDate { get; set; }

        public List<PharmacyEmployees> EmployedPharmacyList { get; set; }
    }
}
