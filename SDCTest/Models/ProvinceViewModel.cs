using System.Collections.Generic;

namespace SDCTest.Models
{
    public class ProvinceViewModel
    {
        public int ProvinceId { set; get; }

        public string Name { set; get; }

        public virtual IEnumerable<CountyViewModel> Counties { set; get; }

        public virtual IEnumerable<EmployeeViewModel> Employees { set; get; }

    }
}