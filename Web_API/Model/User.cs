using System.ComponentModel.DataAnnotations;

namespace Real_App.Model
{
    public class User : BaseEntity
    {
        
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }
    }
}
