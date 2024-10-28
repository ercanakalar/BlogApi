using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Models.Error;
using Backend.Core.Models.User;
using Backend.Core.Services;
using Backend.Core.UnitOfWorks;
using Backend.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtTokenGenerator _tokenService;
        private readonly PasswordManager _passwordManager;

        public UserService(
            IUnitOfWork unitOfWork,
            JwtTokenGenerator tokenService,
            PasswordManager passwordManager
        )
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _passwordManager = passwordManager;
        }

        public async Task<UserResponse> Signup(SignupRequest request)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "User with this email already exists",
                    StatusCode = 409,
                };
            }

            var hashedPassword = _passwordManager.HashPassword(request.Password);
            var hashedConfirmPassword = _passwordManager.HashPassword(request.Password);
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hashedPassword,
                ConfirmPassword = hashedConfirmPassword,
                Role = request.Role ?? "User",
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            var roles = new List<string> { user.Role };
            var token = _tokenService.GenerateToken(user, roles);
            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token,
                IsSuccess = true,
                StatusCode = 200,
            };
        }

        public async Task<UserResponse> Signin(SigninRequest request)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (user == null)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Invalid email or password",
                    StatusCode = 400,
                };
            }

            if (!_passwordManager.VerifyPassword(user.Password, request.Password))
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Invalid email or password",
                    StatusCode = 400,
                };
            }
            var roles = new List<string> { user.Role };
            var token = _tokenService.GenerateToken(user, roles);
            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token,
                Message = "You have successfully signed in",
            };
        }
    }
}
