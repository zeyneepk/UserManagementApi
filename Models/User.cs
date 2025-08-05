using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(1)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MinLength(1)]
        public string LastName { get; set; } = string.Empty;

        [Required, MinLength(1)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        // Opsiyonel
        public string? Address { get; set; } 
    }
}