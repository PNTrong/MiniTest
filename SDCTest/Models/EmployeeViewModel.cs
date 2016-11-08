using System;

namespace SDCTest.Models
{
    public class EmployeeViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public DateTime BirthDay { get; set; }

        public int CountyId { set; get; }

        public int ProvinceId { set; get; }

        public string Avartar { set; get; }

        public decimal Salary { set; get; }

        public string Position { set; get; }

        public string Introduce { set; get; }

        public virtual CountyViewModel County { set; get; }

        public virtual ProvinceViewModel Province { set; get; }
    }
}