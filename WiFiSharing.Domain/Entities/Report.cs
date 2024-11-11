namespace WiFiSharing.Domain.Entities;

public partial class Report
{
    public int ReportId { get; set; }

    public int WiFiId { get; set; }

    public int UserId { get; set; }

    public string Reason { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WiFiNetwork WiFi { get; set; } = null!;
}
