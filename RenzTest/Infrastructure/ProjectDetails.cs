

using System;

namespace RenzTest.Infrastructure
{
    public class ProjectDetails
    {
        public Guid Id { get; set; }
        public Int64 projectID { get; set; }
        public string? TaskDescription { get; set; }
        public string? TotalEstimate { get; set; }
        public string? TaskTitle { get; set; }
        public Guid InsertedBy { get; set; }
    }
}
