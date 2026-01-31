using JobPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Common.Models
{
    public class CreateJobDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public JobLocation JobLocation { get; set; }
        public JobType JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public double SalaryFrom { get; set; }
        public double SalaryTo { get; set; }
        public DateTime ApplicationDeadline { get; set; }
    }
}
