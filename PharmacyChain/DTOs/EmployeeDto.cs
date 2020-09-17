using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PharmacyChain.Models.Employee;

namespace PharmacyChain.DTOs
{
    //CREATE
    public class EmployeeCreateDto:BaseEntity
    {
        public EmployeeCreateDto()
        {
            base.CreatedAt = DateTime.Now;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public int MyProperty { get; set; }
        [Required]
        public EGender Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
    }

    public class EmployeeUpdateDto:BaseEntity
    {
        public EmployeeUpdateDto()
        {
            base.UpdatedAt = DateTime.Now;
        }
        public string Name { get; set; }

        public string LastName { get; set; }
        public int MyProperty { get; set; }

        public EGender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
    }

    public class EmployeePatchDto:BaseEntity
    {
        public EmployeePatchDto()
        {
            base.UpdatedAt = DateTime.Now;
        }
        public string Name { get; set; }

        public string LastName { get; set; }
        public int MyProperty { get; set; }

        public EGender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
    }

}
