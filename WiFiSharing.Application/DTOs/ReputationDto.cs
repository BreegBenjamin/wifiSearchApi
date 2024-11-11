namespace WiFiSharing.Application.DTOs
{
    public class ReputationDto
    {
        public int ReputationId { get; set; }

        public int WiFiId { get; set; }

        public int UserId { get; set; }

        public int? Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
