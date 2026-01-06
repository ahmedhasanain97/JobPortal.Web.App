using JobPortal.Application.Abstractions;
using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.LoginUser
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
    {
        private readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(
                request.Email, request.Password);
        }
    }
}
