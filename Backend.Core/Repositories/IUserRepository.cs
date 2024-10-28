using System.Threading.Tasks;
using Backend.Core.Models.User;

namespace Backend.Core.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<UserResponse> Signup(SignupRequest request);
        Task<UserResponse> Signin(SigninRequest request);
        Task<User> GetByEmailAsync(string email);
        // Task<User> GetUserById(int id);
        // Task<IEnumerable<User>> GetAllUsers();
        // Task AddUser(User user);
        // Task UpdateUser(User user);
        // Task DeleteUser(User user);
    }
}
