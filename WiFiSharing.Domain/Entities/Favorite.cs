namespace WiFiSharing.Domain.Entities;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int UserId { get; set; }

    public int WiFiId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WiFiNetwork WiFi { get; set; } = null!;
}
