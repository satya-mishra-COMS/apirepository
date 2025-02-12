using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class BiddingOdView
    {
        public int BiddingId { get; set; }

        public string FdRemarks { get; set; }
        public string Origin { get; set; }
        public string Dest { get; set; }
        public string ReqDate { get; set; }
        public string NoBid { get; set; }
        public string Status { get; set; }
        public string Commodity { get; set; }
        public string Ctype { get; set; }
        public string PkgType { get; set; }
        public string TotalWt { get; set; }
        public string MinAmount { get; set; }
        public string MaxAmt { get; set; }
        public int Fdid { get; set; }
        public string ConsignorRemarks { get; set; }
        public string Rating { get; set; }
        public string? BidderDetail { get; set; }
        public string? TrailerDetail { get; set; }

    }
    public class BiddingviewData
    {
        public List<BiddingOdView> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }
}
