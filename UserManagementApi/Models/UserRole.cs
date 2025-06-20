using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    public class UserRole : IdentityUserRole<string>
    {
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public string? AssignedBy { get; set; } 

        public DateTime? ExpiresAt { get; set; }

        [StringLength(500)]
        public string? Reason { get; set; }

        public bool IsTemporary { get; set; } = false;

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [ForeignKey("RoleId")]
        public Role Role { get; set; } = null!;

        [ForeignKey("AssignedBy")]
        public virtual User AssignedByUser { get; set; } = null!;

        [NotMapped]
        public bool IsExpired => ExpiresAt.HasValue && ExpiresAt < DateTime.UtcNow;
    }
}
