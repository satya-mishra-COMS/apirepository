using Models.Bidding;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace dbrepository
{
    public interface IBiddingFiling
    {
        ResponseStatus BidFiling(BiddingfilingParam biddingfilingParam);
        ResponseStatus BidFilingUpdate(BiddingInsertUpdateParam biddingInsertUpdate);
        BiddingviewData BiddingOdView(BiddingOdViewParam biddingOdViewParam);
        ResponseStatus BiddingProcess(BiddingProcessParam biddingProcessParam);
        lovData GetLovByType(string lovtype);
        BiddingDetailData BiddingDetailsView(BiddingDetailviewParam biddingDetailviewParam);
        ResponseStatus UpdateFeedback(FeedbackParam feedbackParam);
        lovData GetLovByUser(string lovtype, string User);







    }
}
