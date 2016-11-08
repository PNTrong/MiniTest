using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("Provinces")]
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvinceId { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public virtual IEnumerable<County> Counties { set; get; }

        public virtual IEnumerable<Employee> Employees { set; get;}
    }
}