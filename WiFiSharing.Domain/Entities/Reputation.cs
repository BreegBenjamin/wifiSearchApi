using System;
using System.Collections.Generic;

namespace WiFiSharing.Domain.Entities;

public partial class Reputation
{
    public int ReputationId { get; set; }

    public int WiFiId { get; set; }

    public int UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WiFiNetwork WiFi { get; set; } = null!;
}
