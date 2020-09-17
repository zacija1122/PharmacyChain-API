using AutoMapper;
using PharmacyChain.Dtos;
using PharmacyChain.DTOs;
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

            // Pharmacy
            CreateMap<PharmacyCreateDto, Pharmacy>().ReverseMap();
            CreateMap<PharmacyUpdateDto, Pharmacy>();

            //User
            CreateMap<UserCreateDto, User>();

            //Employee
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<EmployeePatchDto, Employee>().ReverseMap();
        }
    }
}
