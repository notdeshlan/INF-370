using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; } = null!;
        public string PermissionDescription { get; set; } = null!;

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
