using System.ComponentModel.DataAnnotations;

namespace CrudAPI8.Model
{
    public class EmployeeDTO
    {
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = " Age should be between 18 and 100")]
        public string? Age { get; set; }
        [Required(ErrorMessage = "Gender is requied")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "state is required")]
        public string? State { get; set; }
    }
}
