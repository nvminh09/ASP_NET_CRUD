using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "First name is too short.")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Last name is too short.")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Birthday")]
        public DateOnly DateBirth { get; set; }
        [Required, MinLength(9, ErrorMessage = "Input the phone number.")]
        [DisplayName("Phone")]
        public string? Phone { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}