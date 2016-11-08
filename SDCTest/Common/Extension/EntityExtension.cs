using Model.Models;
using SDCTest.Models;

namespace SDCTest.Common.Extension
{
    public static class EntityExtension
    {
        public static void UpdateEmployee(this Employee emp, EmployeeViewModel empVm)
        {
            emp.ID = empVm.ID;
            emp.Avartar = empVm.Avartar;
            emp.BirthDay = empVm.BirthDay;
            emp.CountyId = empVm.CountyId;
            emp.Introduce = empVm.Introduce;
            emp.Position = empVm.Position;
            emp.Salary = empVm.Salary;
            emp.ProvinceId = empVm.ProvinceId;
            
        }
    }
}