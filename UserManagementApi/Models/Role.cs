using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    public class Role : IdentityRole
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;

        public bool CanManageUsers { get; set; } = false;

        public bool CanManageRoles { get; set; } = false;

        public bool CanViewReports { get; set; } = false;

        public bool CanManageSystem { get; set; } = false;

        public bool CanViewAuditLogs { get; set; } = false;

        public bool CanManageDepartment { get; set; } = false;

        //public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
