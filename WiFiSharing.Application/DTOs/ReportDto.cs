namespace WiFiSharing.Application.DTOs
{
    public class ReportDto
    {
        public int ReportId { get; set; }

        public int WiFiId { get; set; }

        public int UserId { get; set; }

        public string Reason { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public string? Status { get; set; }

    }
}
