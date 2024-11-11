using System;
using System.Collections.Generic;

namespace WiFiSharing.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Reputation> Reputations { get; set; } = new List<Reputation>();

    public virtual ICollection<WiFiNetwork> WiFiNetworks { get; set; } = new List<WiFiNetwork>();
}
