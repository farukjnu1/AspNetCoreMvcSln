using System;
using System.Collections.Generic;

namespace AspNetCoreMvc.Models
{
    public partial class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public int? UserType { get; set; }
    }
}
