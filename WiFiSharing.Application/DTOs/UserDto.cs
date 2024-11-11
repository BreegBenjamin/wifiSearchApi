namespace WiFiSharing.Application.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public bool? IsAdmin { get; set; }
    }

    public class LoginData() 
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
