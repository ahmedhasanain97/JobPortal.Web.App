using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, AuthDto>
    {
        private readonly IAuthService _authService;
        public RegisterUserHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<AuthDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Username,
                request.Email,
                request.Password);
        }
    }
}
