using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    public class ChangePassword
    {
        public string? Username { get; set; }
        public string? Newpassword { get; set; }
        public string? OldPassword { get; set; }

    }
}
