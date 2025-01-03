﻿using System.ComponentModel.DataAnnotations;

namespace Real_App.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50), MinLength(3)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
