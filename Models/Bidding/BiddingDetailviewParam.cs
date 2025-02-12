using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class BiddingDetailviewParam
    {
        public int Bidid { get; set; }
        public string UserId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Usertype { get; set; }
        public string Type { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }

    }
    public class BiddingDetailview
    {
        public int Fdid { get; set; }
        public int FdBidderid { get; set; }
        public string FdBidderName { get; set; }
        public string? FdBidAmount { get; set; }
        public string FdRemarks { get; set; }
        public string Fdrating { get; set; }
      

    }
    public class BiddingDetailData
    {
        public List<BiddingDetailview> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }
}
