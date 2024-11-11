using Microsoft.EntityFrameworkCore;
using WiFiSharing.Domain.Entities;

namespace WiFiSharing.Infrastructure.DataAccess;

public partial class WifiSearchContext : DbContext
{
    public WifiSearchContext()
    {
    }

    public WifiSearchContext(DbContextOptions<WifiSearchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reputation> Reputations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WiFiNetwork> WiFiNetworks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE488B8CCF715");

            entity.HasIndex(e => e.UserId, "idx_admins_userid");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admins__UserId__52593CB8");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__CE74FAD5D59FBE9A");

            entity.HasIndex(e => e.UserId, "idx_favorites_userid");

            entity.HasIndex(e => e.WiFiId, "idx_favorites_wifiid");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__UserI__47DBAE45");

            entity.HasOne(d => d.WiFi).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.WiFiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__WiFiI__48CFD27E");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__D5BD4805F6603E69");

            entity.HasIndex(e => e.UserId, "idx_reports_userid");

            entity.HasIndex(e => e.WiFiId, "idx_reports_wifiid");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__UserId__4E88ABD4");

            entity.HasOne(d => d.WiFi).WithMany(p => p.Reports)
                .HasForeignKey(d => d.WiFiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__WiFiId__4D94879B");
        });

        modelBuilder.Entity<Reputation>(entity =>
        {
            entity.HasKey(e => e.ReputationId).HasName("PK__Reputati__1C5FCCED0BB22076");

            entity.ToTable("Reputation");

            entity.HasIndex(e => e.UserId, "idx_reputation_userid");

            entity.HasIndex(e => e.WiFiId, "idx_reputation_wifiid");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Reputations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reputatio__UserI__440B1D61");

            entity.HasOne(d => d.WiFi).WithMany(p => p.Reputations)
                .HasForeignKey(d => d.WiFiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reputatio__WiFiI__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C55850F57");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534CEAE9C00").IsUnique();

            entity.HasIndex(e => e.Email, "idx_users_email");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WiFiNetwork>(entity =>
        {
            entity.HasKey(e => e.WiFiId).HasName("PK__WiFiNetw__14ADCDC6101F198D");

            entity.HasIndex(e => new { e.Latitude, e.Longitude }, "idx_wifi_lat_lng");

            entity.HasIndex(e => e.UserId, "idx_wifi_userid");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ssid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SSID");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.WiFiNetworks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WiFiNetwo__UserI__3E52440B");
        });

    }
}
