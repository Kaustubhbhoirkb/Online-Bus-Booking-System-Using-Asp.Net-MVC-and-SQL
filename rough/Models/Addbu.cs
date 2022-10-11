using System;
using System.Collections.Generic;

namespace rough.Models
{
    public partial class Addbu
    {
        public int Id { get; set; }
        public int BusNumber { get; set; }
        public string BusName { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public DateTime DateOfTransaction { get; set;}
        public string Arrival { get; set; } = null!;
        public string Departure { get; set; } = null!;
        public string TypeOfBus { get; set; } = null!;
        public int ModelNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public int Fare { get; set; }
    }
}
