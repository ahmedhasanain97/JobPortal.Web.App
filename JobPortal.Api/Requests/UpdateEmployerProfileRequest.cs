using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Requests
{

    public class UpdateEmployerProfileRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
    }

}
