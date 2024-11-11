namespace WiFiSharing.Application.DTOs
{
    public class FavoriteDto
    {
        public int FavoriteId { get; set; }

        public int UserId { get; set; }

        public int WiFiId { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
