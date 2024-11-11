namespace WiFiSharing.Application.DTOs
{
    public class AdminDto
    {
        public int AdminId { get; set; }

        public int UserId { get; set; }

        public string Role { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
