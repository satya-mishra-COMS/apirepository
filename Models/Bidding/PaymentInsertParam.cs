using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class PaymentInsertParam
    {
        public string? BidId { get; set; }
        public string? DateVal { get; set; }
        public string? RefNo { get; set; }
        public string? Amount { get; set; }
        public string? PayType { get; set; }
        public string? Paidby { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedUser { get; set; }
        public string? TranType { get; set; }
        public IFormFile? FilePath { get; set; }
      // new code


    }
    public class PaymentView
    {
        public string? Fdid { get; set; }
        public string? Fdbidid { get; set; }
        public string? FdPayDate { get; set; }
        public string? FdRefno { get; set; }
        public string? FdAmount { get; set; }
        public string? FdPayType { get; set; }
        public string? fdPaidBy { get; set; }
        public string? fdRemarks { get; set; }
        public string? fdStatus { get; set; }
        public string? fdCreatedBy { get; set; }
        public string? fdcreatedon { get; set; }

        public string? fdfilename { get; set; }


    }

    public class PaymentViewData
    {
        public List<PaymentView> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }

}
