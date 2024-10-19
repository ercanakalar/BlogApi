namespace Blog.Data;

public class UserRegistrationDto
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public string Role { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}
