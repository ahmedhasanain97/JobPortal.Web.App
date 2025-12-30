using JobPortal.Application.Common.Interfaces;
using JobPortal.Application.Common.Models;

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

        public async Task<AuthDto> RegisterAsync(
           string firstName,
           string lastName,
           string username,
           string email,
           string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return new AuthDto
                {
                    IsAuthenticated = false,
                    Message = "Email already registered"
                };
            }

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
                return new AuthDto
                {
                    IsAuthenticated = false,
                    Message = string.Join(", ",
                        result.Errors.Select(e => e.Description))
                };
            }

            // todo: add default role and then implement role management to allow user to choose his role
            //await _userManager.AddToRoleAsync(user, role);

            var token = await _tokenService.GenerateTokenAsync(user, _userManager);

            return new AuthDto
            {
                IsAuthenticated = true,
                email = user.Email,
                //Roles = roles,
                Token = token
            };
        }

        public async Task<AuthDto> LoginAsync(
            string email,
            string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AuthDto { IsAuthenticated = false };

            var valid = await _userManager.CheckPasswordAsync(user, password);
            if (!valid)
                return new AuthDto { IsAuthenticated = false };

            var token = await _tokenService.GenerateTokenAsync(user, _userManager);

            return new AuthDto
            {
                IsAuthenticated = true,
                email = user.Email!,
                //Roles = roles,
                Token = token
            };
        }
    }
}
