using System;
using System.Collections.Generic;

namespace rough.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? EmployeeId { get; set; }
        public string? Password { get; set; }
        public string? EmpName { get; set; }
        public int? Age { get; set; }
        public decimal? Salary { get; set; }
        public string? Gender { get; set; }
    }
}
