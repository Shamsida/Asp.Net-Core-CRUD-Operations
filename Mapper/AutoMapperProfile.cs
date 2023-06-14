using AutoMapper;
using DemoProject.Models;
using DemoProject.Models.Dto;

namespace DemoProject.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Employee,UserDTO>().ReverseMap();
        }

    }
}
