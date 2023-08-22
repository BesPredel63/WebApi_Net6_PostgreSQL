using System.ComponentModel.DataAnnotations;

namespace WebApi_Net6_PostgreSQL.Models.Users {
    public class CreateRequest {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
