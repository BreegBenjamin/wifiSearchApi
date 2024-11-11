using System;
using System.Collections.Generic;

namespace WiFiSharing.Domain.Entities;

public partial class Admin
{
    public int AdminId { get; set; }

    public int UserId { get; set; }

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
