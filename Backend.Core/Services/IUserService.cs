using Backend.Core.Models.User;

namespace Backend.Core.Services
{
    public interface IUserService
    {
        Task<UserResponse> Signup(SignupRequest request);
        Task<UserResponse> Signin(SigninRequest request);
        // Task<UserResponse> GetAllUsers(LoginRequest request);
        // Task UpdateUser(User user);
        // Task DeleteUser(User user);
        // Task GetUserById(int id);
    }
}
