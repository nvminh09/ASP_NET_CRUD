using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "First name is too short.")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Last name is too short.")]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
