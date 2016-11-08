using AutoMapper;
using Model.Models;
using SDCTest.Models;

namespace Training.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<County, CountyViewModel>();
            Mapper.CreateMap<Province, ProvinceViewModel>();
        }
    }
}