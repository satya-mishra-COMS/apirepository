using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class BiddingProcessParam
    {
        public string Biddid { get; set; }
        public string Bidderid { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public string? Trtype { get; set; }

    }
}
