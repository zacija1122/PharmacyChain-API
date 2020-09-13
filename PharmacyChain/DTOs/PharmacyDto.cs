using Newtonsoft.Json;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Dtos
{
    public class PharmacyCreateDto:BaseEntity
    {
        public PharmacyCreateDto()
        {          
            base.CreatedAt = DateTime.Now;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
              
    }
    public class PharmacyUpdateDto : BaseEntity
    {
        public PharmacyUpdateDto()
        {
            base.UpdatedAt = DateTime.Now;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

    }
}
