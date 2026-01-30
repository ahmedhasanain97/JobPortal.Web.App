using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Common.Models
{
    public class UpdateEmployerProfileDto
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
    }
}
