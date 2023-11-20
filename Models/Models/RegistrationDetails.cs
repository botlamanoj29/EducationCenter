using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class RegistrationDetails
    {
        public string UserName { get; set; }


        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]

        [RegularExpression(@"^(?=(.*\d){2})[A-Za-z\d]{0,}$", ErrorMessage = "The password must contain at least 2 numbers")]
        public string Password { get; set; }
    }
}
