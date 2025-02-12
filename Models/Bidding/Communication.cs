using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class Communication
    {
        public string? Bidid { get; set; }
        public string? Usertype { get; set; }
        public string? Topic { get; set; }
        public string? Detail { get; set; }
        public string? Whom { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public int CommunicationId { get; set; }
        public string TranType { get; set; }
    }
}
