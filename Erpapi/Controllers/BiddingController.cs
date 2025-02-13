using dbrepository;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Admin;
using Models.Bidding;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Erpapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BiddingController : ControllerBase
    {
        private readonly IBiddingFiling bidding;
       
        public BiddingController(IBiddingFiling bidding, IWebHostEnvironment env)
        {
            this.bidding = bidding;
          //commenting

        }

        [HttpPost]
        [Route("bidfiling")]
        public async Task<IActionResult> BidFiling(BiddingfilingParam biddingfilingParam)
        {
            return Ok(this.bidding.BidFiling(biddingfilingParam));
        }
        [HttpPost]
        [Route("bidfilingUpdate")]
        public async Task<IActionResult> BidFilingUpdate(BiddingInsertUpdateParam biddingInsertUpdate)
        {
            return Ok(this.bidding.BidFilingUpdate(biddingInsertUpdate));
        }
        [HttpPost]
        [Route("bidfilingOdView")]
        public async Task<IActionResult> BidFilingUpdate(BiddingOdViewParam biddingOdView)
        {
            return Ok(this.bidding.BiddingOdView(biddingOdView));
        }
        [HttpPost]
        [Route("biddingDetailsView")]
        public async Task<IActionResult> BiddingDetailView(BiddingDetailviewParam biddingDetailviewParam)
        {
            return Ok(this.bidding.BiddingDetailsView(biddingDetailviewParam));
        }
        [HttpPost]
        [Route("biddingProcess")]
        public async Task<IActionResult> BiddingProcess(BiddingProcessParam biddingProcessParam)
        {
            return Ok(this.bidding.BiddingProcess(biddingProcessParam));
        }
        [HttpGet]
        [Route("getLovByType/{lovtype}")]
        public async Task<IActionResult> GetDecryptedPassword(string lovtype)
        {
            return Ok(this.bidding.GetLovByType(lovtype));

            //return this.bidding.GetLovByType(lovtype);
        }
        [HttpPost]
        [Route("updatefeedback")]
        public async Task<IActionResult> UpdateFeedback(FeedbackParam feedbackParam)
        {
            return Ok(this.bidding.UpdateFeedback(feedbackParam));
        }

    }
}

