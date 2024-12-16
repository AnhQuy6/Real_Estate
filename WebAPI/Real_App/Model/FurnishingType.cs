using System.ComponentModel.DataAnnotations;

namespace Real_App.Model
{
    public class FurnishingType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}