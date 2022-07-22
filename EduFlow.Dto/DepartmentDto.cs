using System;
using System.ComponentModel.DataAnnotations;

namespace EduFlow_Odev2.Dto
{
    public class DepartmentDto
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(230)]
        [Display(Name = "DeptName")]
        public string DeptName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "CountryId")]
        public int CountryId { get; set; }

    }
}
