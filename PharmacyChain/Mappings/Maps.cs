using AutoMapper;
using PharmacyChain.Dtos;
using PharmacyChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyChain.Mappings
{
    public class Maps:Profile
    {
        public Maps()
        {
            //source => destination
            CreateMap<PharmacyCreateDto, Pharmacy>().ReverseMap();
            CreateMap<PharmacyUpdateDto, Pharmacy>();
           
        }
    }
}
