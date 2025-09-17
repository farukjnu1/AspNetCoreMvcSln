using System;
using System.Collections.Generic;

namespace AspNetCoreMvc.Models
{
    public partial class UserPermission
    {
        public int PermissionId { get; set; }
        public int MenuIid { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsCreate { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
        public int? UserId { get; set; }
    }
}
