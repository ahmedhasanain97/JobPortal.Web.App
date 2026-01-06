using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Interfaces;
using JobPortal.Application.Common.Models;
using JobPortal.Application.Errors;
using JobPortal.Application.Exceptions;


namespace JobPortal.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result> RegisterAsync(
           string firstName,
           string lastName,
           string username,
           string email,
           string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
                return AuthErrors.AlreadyRegistered;

            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new ValidationException(result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description }));
            }

            // todo: add default role and then implement role management to allow user to choose his role
            //await _userManager.AddToRoleAsync(user, role);

            var token = await _tokenService.GenerateTokenAsync(user, _userManager);

            return Result<AuthDto>.Success(new AuthDto
            {
                IsAuthenticated = true,
                email = user.Email,
                Token = token
            });
        }

        public async Task<Result> LoginAsync(
            string email,
            string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return AuthErrors.InvalidUserOrPassword;

            var valid = await _userManager.CheckPasswordAsync(user, password);
            if (!valid)
                return AuthErrors.WrongPassword;

            var token = await _tokenService.GenerateTokenAsync(user, _userManager);

            return Result<AuthDto>.Success(new AuthDto
            {
                IsAuthenticated = true,
                email = user.Email!,
                Token = token
            });
        }
    }
}
