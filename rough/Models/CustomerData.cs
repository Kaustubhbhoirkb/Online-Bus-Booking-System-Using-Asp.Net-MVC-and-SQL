using System.ComponentModel.DataAnnotations;

namespace rough.Models
{
    public class CustomerData
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Admin_Id { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Mobile_No { get; set; }


    }
}
