using System.ComponentModel.DataAnnotations;

namespace XpressMart.Core.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

    }
}
