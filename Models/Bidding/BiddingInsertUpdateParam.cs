using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class BiddingInsertUpdateParam
    {
        public string Commodity { get; set; }
        public string Packagetype { get; set; }
        public string Qty { get; set; }
        public string Cargotype { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Fromamount { get; set; }
        public double Toamount { get; set; }
        public DateTime Requiredon { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string Trtype { get; set; }
        public int Bidid { get; set; }
        
        
    }
}
