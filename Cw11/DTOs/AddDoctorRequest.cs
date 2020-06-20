using System.ComponentModel.DataAnnotations;

namespace Cw11.DTOs
{
    public class AddDoctorRequest
    {
        [Required(ErrorMessage = "ID is required")]
        public int IdDoctor { get; set; }
        [Required(ErrorMessage = "NAME is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "SURNAME is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "EMAIL is required")]
        public string Email { get; set; }
    }
}