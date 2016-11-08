using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public DateTime BirthDay { get; set; }

        [Required]
        public int CountyId { set; get; }

        [Required]
        public int ProvinceId { set; get; }

        [MaxLength(256)]
        public string Avartar { set; get; }

        public decimal Salary { set; get; }

        public string Position { set; get; }

        [MaxLength(500)]
        public string Introduce { set; get; }

        [ForeignKey("CountyId")]
        public virtual County County { set; get; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { set; get; }
    }
}