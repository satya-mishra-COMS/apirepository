using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class BiddingfilingParam
    {
        public string BidId { get; set; }
        public string BidderId { get; set; }
        public decimal BidAmount { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string TranType { get; set; }

    }
}
