using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    public class User : IdentityUser 
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public bool IsActive { get; set; } = true;

        public int FailedLoginAttempts { get; set; } = 0;

        public DateTime? LockedUntil { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();

        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [NotMapped]
        public bool IsAccountLocked => LockoutEnabled && LockoutEnd.HasValue && LockoutEnd > DateTimeOffset.UtcNow;
    }
}
