using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } // Nullable for system actions

        [Required]
        [StringLength(100)]
        public string Action { get; set; } // e.g., "Login", "RoleAssigned", "RoleRemoved", "UserCreated"

        [Required]
        [StringLength(100)]
        public string EntityType { get; set; } // e.g., "User", "Role", "UserRole"

        public string EntityId { get; set; } // ID of the affected entity

        [StringLength(2000)]
        public string Details { get; set; } // Description of changes or additional context

        [StringLength(45)]
        public string IpAddress { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public bool IsSuccessful { get; set; } = true;

        [StringLength(500)]
        public string ErrorMessage { get; set; }

        [StringLength(100)]
        public string AffectedUserName { get; set; } // For easier reporting

        [StringLength(100)]
        public string AffectedRoleName { get; set; } // For easier reporting

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
