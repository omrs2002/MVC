using AutoMapper;
using MVCCourse2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCourse2017.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<MovieDto, MovieDto>();
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Genre, GenreDto>();
            



        }

    }
}