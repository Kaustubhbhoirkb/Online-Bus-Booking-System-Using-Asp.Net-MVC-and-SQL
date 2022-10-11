using System.ComponentModel.DataAnnotations;

namespace rough.Models
{
    public class Bus
    {
        [Required(ErrorMessage = "Please Enter ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Bus Number")]
        public int BusNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Bus Name")]
        public string BusName { get; set; }
        [Required(ErrorMessage = "Please Enter Source")]
        public string Source { get; set; }
        [Required(ErrorMessage = "Please Enter Destination")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Please Enter Arrival")]
        public string Arrival { get; set; }
        [Required(ErrorMessage = "Please Enter Departure")]
        public string Departure { get; set; }
        [Required(ErrorMessage = "Please Enter TypeOfBus")]
        public string TypeOfBus { get; set; }
        [Required(ErrorMessage = "Please Enter ModelNumber")]
        public int ModelNumber { get; set; }
        [Required(ErrorMessage = "Please Enter NumberOfSeats")]
        public int NumberOfSeats { get; set; }
        [Required(ErrorMessage = "Please Enter Fare")]
        public int Fare { get; set; }
        }
}
