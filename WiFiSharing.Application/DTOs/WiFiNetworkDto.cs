using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiFiSharing.Application.DTOs
{
    public class WiFiNetworkDto
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
    }
}
