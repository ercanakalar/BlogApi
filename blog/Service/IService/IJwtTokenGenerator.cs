using Blog.Data;

namespace Blog.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IEnumerable<string> roles);
        string GenerateExpiredToken(User user, IEnumerable<string> roles);
    }
}
