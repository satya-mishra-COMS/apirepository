using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    public class UserVerify
    {
        public string UserId { get; set; }
        public string OtpType { get; set; }
        public string Otp { get; set; }
    }
}
