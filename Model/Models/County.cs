using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("Counties")]
    public class County
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountyId { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int ProvinceId { set; get; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { set; get; }

        public virtual IEnumerable<Employee> Employees { set; get; }
    }
}