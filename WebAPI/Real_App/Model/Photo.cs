﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_App.Model
{
    [Table("Photos")]
    public class Photo : BaseEntity
    {
        [Required]
        public string ImageURL { get; set; }
        public bool IsPrimary { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}