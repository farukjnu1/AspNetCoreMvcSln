using AspNetCoreMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc.ViewModels
{
    public class VmUserPermission
    {
        public UserLogin UserLogin { get; set; }
        public List<UserPermission> ListUserPermission { get; set; }
    }
}
