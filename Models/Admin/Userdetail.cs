using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    public class Userdetail: ResponseStatus
    {
        public int fdUserId { get; set; }
        public string fdUserName { get; set; }
        public string fdEmployeeName { get; set; }
        public string fdPassword { get; set; }
        public string fdContactNo { get; set; }
        public string fdEmailId { get; set; }
        public string fdUserType { get; set; }
        public DateTime fdFirstLoginDate { get; set; }
        public DateTime fdLastLoginDate { get; set; }
        
       
    }
}
