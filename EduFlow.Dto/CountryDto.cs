using System;
using System.ComponentModel.DataAnnotations;

namespace EduFlow_Odev2.Dto
{
    public class CountryDto
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "CountryId")]
        public int CountryId { get; set; }
        
        [Required]
        [MaxLength(230)]
        [Display(Name = "CountryName")]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(230)]
        [Display(Name = "Continent")]
        public string Continent { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Currency")]
        public string Currency { get; set; }


    }
}
