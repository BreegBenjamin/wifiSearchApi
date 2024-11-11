using System;
using System.Collections.Generic;

namespace WiFiSharing.Domain.Entities;

public partial class WiFiNetwork
{
    public int WiFiId { get; set; }

    public int UserId { get; set; }

    public string Ssid { get; set; } = null!;

    public string? Password { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Reputation> Reputations { get; set; } = new List<Reputation>();

    public virtual User User { get; set; } = null!;
}
