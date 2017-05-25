using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CarRental.Models;
using CarRental.Dtos;

namespace CarRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Caar, CarDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<carType, CarTypeDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id, opt=>opt.Ignore());

            Mapper.CreateMap<CarDto, Caar>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}