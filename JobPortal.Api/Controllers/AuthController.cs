using JobPortal.Application.Common.Models;
using JobPortal.Application.Features.ApplicationUsers.Commands.LoginUser;
using JobPortal.Application.Features.ApplicationUsers.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDto>> Register([FromBody] RegisterRequestDto requestDto)
        {
            var result = await _mediator.Send(new RegisterUserCommand(requestDto.FirstName, requestDto.LastName, requestDto.Username, requestDto.Email, requestDto.Password));

            if (!result.IsAuthenticated)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthDto>> Login([FromBody] LoginRequestDto requestDto)
        {
            //var user = User.Identity;
            //var claims = User.Claims.Where(c => c.Type == "userId").FirstOrDefault()?.Value;
            //var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            var result = await _mediator.Send(new LoginCommand(requestDto.Email, requestDto.Password));
            if (!result.IsAuthenticated)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
