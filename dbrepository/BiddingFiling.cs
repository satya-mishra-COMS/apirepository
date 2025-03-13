using Microsoft.Extensions.Options;
using Models;
using Models.Admin;
using Models.Bidding;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System.Data;
using System.Xml;
namespace dbrepository
{
    public class BiddingFiling : IBiddingFiling
    {
        private readonly IOptions<DbConnection> options;
        private readonly ICommonUtility commonUtility;
        public BiddingFiling(IOptions<DbConnection> options, ICommonUtility commonUtility)
        {
            this.options = options;
            this.commonUtility = commonUtility;
        }
        public ResponseStatus BidFiling(BiddingfilingParam biddingfilingParam)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = biddingfilingParam.BidId };
                MySqlParameter p1 = new MySqlParameter("v_pbidderid", MySqlDbType.VarChar) { Value = biddingfilingParam.BidderId };
                MySqlParameter p2 = new MySqlParameter("v_pamount", MySqlDbType.Decimal) { Value = biddingfilingParam.BidAmount };
                MySqlParameter p3 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = biddingfilingParam.Remarks };
                MySqlParameter p4 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = biddingfilingParam.CreatedBy };
                MySqlParameter p5 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = biddingfilingParam.TranType };

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5 });


                var ds = commonUtility.executeReaderProcedure("SP_BIDDINGFILING_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    data.StatusText = Convert.ToString(ds.Tables[0].Rows[0]["StatusText"]);
                    data.StatusId = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusId"]);
                }


            }
            catch (Exception ex)
            {
                data.StatusText = ex.Message;
                data.StatusId = 0;
                // throw;
            }
            return data;
        }

        public ResponseStatus BidFilingUpdate(BiddingInsertUpdateParam biddingInsertUpdate)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pcommodity", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Commodity };
                MySqlParameter p1 = new MySqlParameter("v_ppackagetype", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Packagetype };
                MySqlParameter p2 = new MySqlParameter("v_pQty", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Qty };
                MySqlParameter p3 = new MySqlParameter("v_pcargotype", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Cargotype };
                MySqlParameter p4 = new MySqlParameter("v_porigin", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Origin };
                MySqlParameter p5 = new MySqlParameter("v_pdestination", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Destination };
                MySqlParameter p6 = new MySqlParameter("v_pfromamount", MySqlDbType.Double) { Value = biddingInsertUpdate.Fromamount };
                MySqlParameter p7 = new MySqlParameter("v_ptoamount", MySqlDbType.Double) { Value = biddingInsertUpdate.Toamount };
                MySqlParameter p8 = new MySqlParameter("v_prequiredon", MySqlDbType.Date) { Value = biddingInsertUpdate.Requiredon };
                MySqlParameter p9 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Remarks };
                MySqlParameter p10 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = biddingInsertUpdate.CreatedBy };
                MySqlParameter p11 = new MySqlParameter("v_pbidid", MySqlDbType.Int32) { Value = biddingInsertUpdate.Bidid };
                MySqlParameter p12 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = biddingInsertUpdate.Trtype };

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });


                var ds = commonUtility.executeReaderProcedure("SP_BIDDINGINSERTUPDATE_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    data.StatusText = Convert.ToString(ds.Tables[0].Rows[0]["StatusText"]);
                    data.StatusId = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusId"]);
                }


            }
            catch (Exception ex)
            {
                data.StatusText = ex.Message;
                data.StatusId = 0;
                // throw;
            }
            return data;
        }

        public BiddingviewData BiddingOdView(BiddingOdViewParam biddingOdViewParam)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new BiddingviewData();
            List<BiddingOdView> biddingOdViews = new List<BiddingOdView>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("pbidid", MySqlDbType.VarChar) { Value = biddingOdViewParam.Bidid };
                MySqlParameter p1 = new MySqlParameter("puserid", MySqlDbType.VarChar) { Value = biddingOdViewParam.UserName };
                MySqlParameter p2 = new MySqlParameter("porigin", MySqlDbType.VarChar) { Value = biddingOdViewParam.Origin };
                MySqlParameter p3 = new MySqlParameter("pdestination", MySqlDbType.VarChar) { Value = biddingOdViewParam.Destination };
                MySqlParameter p4 = new MySqlParameter("pusertype", MySqlDbType.VarChar) { Value = biddingOdViewParam.Usertype };
                MySqlParameter p5 = new MySqlParameter("ptype", MySqlDbType.VarChar) { Value = biddingOdViewParam.Type };
                MySqlParameter p6 = new MySqlParameter("varfromdate", MySqlDbType.Date) { Value = biddingOdViewParam.FromDate };
                MySqlParameter p7 = new MySqlParameter("vartodate", MySqlDbType.Date) { Value = biddingOdViewParam.ToDate };
                MySqlParameter p8 = new MySqlParameter("varstatus", MySqlDbType.VarChar) { Value = biddingOdViewParam.Status };


                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7,p8 });


                var ds = commonUtility.executeReaderProcedure("sp_BIDDINGODVIEW_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    biddingOdViews = commonUtility.ConvertToList<BiddingOdView>(dt);



                }

                retData.data = biddingOdViews;
                retData.StatusId = 1;
                retData.StatusText = "Success";

            }
            catch (Exception ex)
            {
                retData.StatusId = 0;
                retData.StatusText = ex.Message.ToString();
                // dt.Rows.Add(data);
                // throw;
            }
            return retData;
        }
        public BiddingDetailData BiddingDetailsView(BiddingDetailviewParam biddingDetailviewParam)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new BiddingDetailData();
            List<BiddingDetailview> biddingdetailViews = new List<BiddingDetailview>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("pbidid", MySqlDbType.VarChar) { Value = biddingDetailviewParam.Bidid };
                MySqlParameter p1 = new MySqlParameter("puserid", MySqlDbType.VarChar) { Value = biddingDetailviewParam.UserId };
                MySqlParameter p2 = new MySqlParameter("porigin", MySqlDbType.VarChar) { Value = biddingDetailviewParam.Origin };
                MySqlParameter p3 = new MySqlParameter("pdestination", MySqlDbType.VarChar) { Value = biddingDetailviewParam.Destination };
                MySqlParameter p4 = new MySqlParameter("pusertype", MySqlDbType.VarChar) { Value = biddingDetailviewParam.Usertype };
                MySqlParameter p5 = new MySqlParameter("pfromdate", MySqlDbType.VarChar) { Value = biddingDetailviewParam.FromDate };
                MySqlParameter p6 = new MySqlParameter("ptodate", MySqlDbType.VarChar) { Value = biddingDetailviewParam.ToDate };
                MySqlParameter p7 = new MySqlParameter("pstatus", MySqlDbType.VarChar) { Value = biddingDetailviewParam.Status };
                MySqlParameter p8 = new MySqlParameter("ptype", MySqlDbType.VarChar) { Value = biddingDetailviewParam.Type };


                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7, p8 });


                var ds = commonUtility.executeReaderProcedure("sp_BIDDINGVIEW_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    biddingdetailViews = commonUtility.ConvertToList<BiddingDetailview>(dt);



                }

                retData.data = biddingdetailViews;
                retData.StatusId = 1;
                retData.StatusText = "Success";

            }
            catch (Exception ex)
            {
                retData.StatusId = 0;
                retData.StatusText = ex.Message.ToString();
                // dt.Rows.Add(data);
                // throw;
            }
            return retData;
        }

        public ResponseStatus BiddingProcess(BiddingProcessParam biddingProcessParam)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = biddingProcessParam.Biddid };
                MySqlParameter p1 = new MySqlParameter("v_pbidderid", MySqlDbType.VarChar) { Value = biddingProcessParam.Bidderid };
                MySqlParameter p2 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = biddingProcessParam.Remarks };
                MySqlParameter p3 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = biddingProcessParam.CreatedBy };
                MySqlParameter p4 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = biddingProcessParam.Trtype };

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4 });


                var ds = commonUtility.executeReaderProcedure("SP_BIDDINGPROCESS_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    data.StatusText = Convert.ToString(ds.Tables[0].Rows[0]["StatusText"]);
                    data.StatusId = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusId"]);
                }


            }
            catch (Exception ex)
            {
                data.StatusText = ex.Message;
                data.StatusId = 0;
                // throw;
            }
            return data;
        }




        public lovData GetLovByType(string lovtype)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new lovData();
            List<LovDto> lovDataList = new List<LovDto>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("vType", MySqlDbType.VarChar) { Value = lovtype };
                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0 });


                var ds = commonUtility.executeReaderProcedure("sp_lov_api", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        //jsonString = JsonConvert.SerializeObject(ds.Tables);
                        dt = ds.Tables[0];
                        lovDataList = commonUtility.ConvertToList<LovDto>(dt);
                    }



                }

                retData.data = lovDataList;
                retData.StatusId = 1;
                retData.StatusText = "Success";
                //return jsonString;
            }
            catch (Exception ex)
            {
                retData.StatusId = 0;
                retData.StatusText = ex.Message.ToString();
                //jsonString = JsonConvert.SerializeObject(data);
                dt.Rows.Add(data);
                // throw;
            }
            return retData;
        }

        public lovData GetLovByUser(string lovtype,string User)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new lovData();
            List<LovDto> lovDataList = new List<LovDto>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("vType", MySqlDbType.VarChar) { Value = lovtype };
                MySqlParameter p1 = new MySqlParameter("vUser", MySqlDbType.VarChar) { Value = User };
                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0 });
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p1 });


                var ds = commonUtility.executeReaderProcedure("sp_lov_api_user_specific", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        //jsonString = JsonConvert.SerializeObject(ds.Tables);
                        dt = ds.Tables[0];
                        lovDataList = commonUtility.ConvertToList<LovDto>(dt);
                    }



                }

                retData.data = lovDataList;
                retData.StatusId = 1;
                retData.StatusText = "Success";
                //return jsonString;
            }
            catch (Exception ex)
            {
                retData.StatusId = 0;
                retData.StatusText = ex.Message.ToString();
                //jsonString = JsonConvert.SerializeObject(data);
                dt.Rows.Add(data);
                // throw;
            }
            return retData;
        }

        public ResponseStatus UpdateFeedback(FeedbackParam feedbackParam)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_puserid", MySqlDbType.VarChar) { Value = feedbackParam.UserId };
                MySqlParameter p1 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = feedbackParam.BidId };
                MySqlParameter p2 = new MySqlParameter("v_pusertype", MySqlDbType.VarChar) { Value = feedbackParam.UserType };
                MySqlParameter p3 = new MySqlParameter("v_psrno", MySqlDbType.VarChar) { Value = feedbackParam.Srno };
                MySqlParameter p4 = new MySqlParameter("v_pfeedback", MySqlDbType.VarChar) { Value = feedbackParam.Feedback };
                MySqlParameter p5 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = feedbackParam.Remarks };
                MySqlParameter p6 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = feedbackParam.CreatedBy };
                MySqlParameter p7 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = feedbackParam.TranType };
                MySqlParameter p8 = new MySqlParameter("v_pcheckid", MySqlDbType.VarChar) { Value = feedbackParam.CheckId };

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4,p5,p6,p7,p8 });


                var ds = commonUtility.executeReaderProcedure("sp_FEEDBACKINSERTUPDATE_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    data.StatusText = Convert.ToString(ds.Tables[0].Rows[0]["StatusText"]);
                    data.StatusId = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusId"]);
                }


            }
            catch (Exception ex)
            {
                data.StatusText = ex.Message;
                data.StatusId = 0;
                // throw;
            }
            return data;
        }

       


    }
}
