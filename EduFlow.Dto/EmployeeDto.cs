using System;
using System.ComponentModel.DataAnnotations;

namespace EduFlow_Odev2.Dto
{
    public class EmployeeDto
    {
        
        [Required]
        [MaxLength(100)]
        [Display(Name = "EmpID")]
        public int EmpID { get; set; }

        [Required]
        [MaxLength(230)]
        [Display(Name = "EmpName")]
        public string EmpName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "DeptId")]
        public int DeptId { get; set; }
    }
}
