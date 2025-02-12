using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class BiddingOdViewParam
    {
        public int Bidid { get; set; }
        public string UserName { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string Usertype { get; set; }
        public string Type { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Status { get; set; }

    }
}
