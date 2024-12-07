using System.ComponentModel.DataAnnotations;

namespace Real_App.Model
{
    public class PropertyType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}