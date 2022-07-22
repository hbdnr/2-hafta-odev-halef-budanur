using System;
using System.ComponentModel.DataAnnotations;

namespace EduFlow_Odev2.Dto
{
    public class FolderDto
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "FolderId")]
        public int FolderId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "EmpId")]
        public int EmpId { get; set; }

        [Required]
        [MaxLength(230)]
        [Display(Name = "AccessType")]
        public int AccessType { get; set; }
    }
}
