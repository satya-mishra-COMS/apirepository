using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class CommunicationView
    {
        public int Slno { get; set; }
        public int FdCommid { get; set; }
        public string? FdBiddID { get; set; }
        public string? FdDiscussionDate { get; set; }
        public string? FdTopic { get; set; }
        public string? FdDetail { get; set; }
        public string? FdWithWhom { get; set; }
        public string? FdRemarks { get; set; }
        public string? FdStatus { get; set; }
        public string? FdCreatedOn { get; set; }
        public string? FdCreatedBy { get; set; }
        public string? FdUpdatedOn { get; set; }
        public string? FdUpdatedBy { get; set; }


    }
    public class CommunicationViewData
    {
        public List<CommunicationView> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }
    public class CommunicationViewParam
    {
        public string? BidId { get; set; }
        public string? UserType { get; set; }
        public string? UserId { get; set; }
        public string? listtype { get; set; }
    }


}
