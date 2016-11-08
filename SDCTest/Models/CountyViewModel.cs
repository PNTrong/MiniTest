using System.Collections.Generic;

namespace SDCTest.Models
{
    public class CountyViewModel
    {
        public int CountyId { set; get; }

        public string Name { set; get; }

        public int ProvinceId { set; get; }

        public virtual ProvinceViewModel Province { set; get; }

        public virtual IEnumerable<EmployeeViewModel> Employees { set; get; }
    }
}