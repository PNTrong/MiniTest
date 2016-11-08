using Model.Models;
using SDCTest.Models;

namespace SDCTest.Common.Extension
{
    public static class EntityExtension
    {
        public static void UpdateEmployee(this Employee emp, EmployeeViewModel empVm)
        {
            emp.ID = empVm.ID;
            emp.Name = empVm.Name;
            emp.Avartar = empVm.Avartar;
            emp.BirthDay = empVm.BirthDay;
            emp.CountyId = empVm.CountyId;
            emp.Introduce = empVm.Introduce;
            emp.Position = empVm.Position;
            emp.Salary = empVm.Salary;
            emp.ProvinceId = empVm.ProvinceId;
        }


        public static void UpdateProvince(this Province province, ProvinceViewModel provinceVm)
        {
            province.ProvinceId = provinceVm.ProvinceId;
            province.Name = provinceVm.Name;
        }

        public static void UpdateCounty(this County county, CountyViewModel countyVm)
        {
            county.CountyId = countyVm.CountyId;
            county.Name = countyVm.Name;
            county.ProvinceId = countyVm.ProvinceId;
        }
    }
}