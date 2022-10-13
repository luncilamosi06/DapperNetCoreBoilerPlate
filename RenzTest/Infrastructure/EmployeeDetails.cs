
using System;

namespace RenzTest.Infrastructure
{
    public class EmployeeDetails
    {
        public Guid Id { get; set; }
        public Int64 employeeID { get; set; }
        public Int64 estimatedHours { get; set; }
        public Int64 actualHours { get; set; }
        public Guid projectDetailsID { get; set; }
        public Int64 createdBy { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
