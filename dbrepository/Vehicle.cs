using Models.Bidding;
using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Models.Admin;

namespace dbrepository
{
    public class Vehicle:IVehicle
    {
        private readonly IOptions<DbConnection> options;
        private readonly ICommonUtility commonUtility;
        public Vehicle(IOptions<DbConnection> options, ICommonUtility commonUtility)
        {
            this.options = options;
            this.commonUtility = commonUtility;
        }
        public ResponseStatus VehicleAssign(VehicleAssignParam vehicleAssignParam)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = vehicleAssignParam.Bidid };
                MySqlParameter p1 = new MySqlParameter("v_pbidderid", MySqlDbType.VarChar) { Value = vehicleAssignParam.BidderId };
                MySqlParameter p2 = new MySqlParameter("v_pvehicleno", MySqlDbType.VarChar) { Value = vehicleAssignParam.VehicleNo };
                MySqlParameter p3 = new MySqlParameter("v_pdrivername", MySqlDbType.VarChar) { Value = vehicleAssignParam.DriverName };
                MySqlParameter p4 = new MySqlParameter("v_pmobileno", MySqlDbType.VarChar) { Value = vehicleAssignParam.MobileNo };
                MySqlParameter p5 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = vehicleAssignParam.Remarks };
                MySqlParameter p6 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = vehicleAssignParam.CreatedBy };
                MySqlParameter p7 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = vehicleAssignParam.TranType };


                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7 });


                var ds = commonUtility.executeReaderProcedure("SP_BIDDVEHICLEASSIGN_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

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
        public ResponseStatus Communication(Communication communication)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = communication.Bidid };
                MySqlParameter p1 = new MySqlParameter("v_pusertype", MySqlDbType.VarChar) { Value = communication.Usertype };
                MySqlParameter p2 = new MySqlParameter("v_ptopic", MySqlDbType.VarChar) { Value = communication.Topic };
                MySqlParameter p3 = new MySqlParameter("v_pdetail", MySqlDbType.VarChar) { Value = communication.Detail };
                MySqlParameter p4 = new MySqlParameter("v_pwhom", MySqlDbType.VarChar) { Value = communication.Whom };
                MySqlParameter p5 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = communication.Remarks };
                MySqlParameter p6 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = communication.CreatedBy };
                MySqlParameter p7 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = communication.TranType };
                MySqlParameter p8 = new MySqlParameter("v_pcommid", MySqlDbType.Int32) { Value = communication.CommunicationId };


                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7, p8 });


                var ds = commonUtility.executeReaderProcedure("sp_COMMUNICATIONINSERTUPDATE_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

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

        public CommunicationViewData CommunicationView(CommunicationViewParam communicationViewParam)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new CommunicationViewData();
            List<CommunicationView> biddingdetailViews = new List<CommunicationView>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("pbiddid", MySqlDbType.VarChar) { Value = communicationViewParam.BidId };
                MySqlParameter p1 = new MySqlParameter("pusertype", MySqlDbType.VarChar) { Value = communicationViewParam.UserType };
                MySqlParameter p2 = new MySqlParameter("puserid", MySqlDbType.VarChar) { Value = communicationViewParam.UserId };
                MySqlParameter p3 = new MySqlParameter("listtype", MySqlDbType.VarChar) { Value = communicationViewParam.listtype };



                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3 });


                var ds = commonUtility.executeReaderProcedure("sp_Communicationview", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    biddingdetailViews = commonUtility.ConvertToList<CommunicationView>(dt);



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
        public VehicleViewData VehicleView(VehicleDetailParam vehicleDetailParam)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new VehicleViewData();
            List<VehicleView> vehicleViews = new List<VehicleView>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("pscreen", MySqlDbType.VarChar) { Value = vehicleDetailParam.Screen };
                MySqlParameter p1 = new MySqlParameter("ptype", MySqlDbType.VarChar) { Value = vehicleDetailParam.ParamType };
                MySqlParameter p2 = new MySqlParameter("puserid", MySqlDbType.VarChar) { Value = vehicleDetailParam.UserId };
                MySqlParameter p3 = new MySqlParameter("ppkid", MySqlDbType.VarChar) { Value = vehicleDetailParam.Pkid };



                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3 });


                var ds = commonUtility.executeReaderProcedure("sp_vehicledetailview_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    vehicleViews = commonUtility.ConvertToList<VehicleView>(dt);



                }

                retData.data = vehicleViews;

               


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



      
        public ResponseStatus VehicleAdd(VehicleAddParam  vehicleAddParam,VehiclePath vehiclePath)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pvenid", MySqlDbType.VarChar) { Value = vehicleAddParam.VendorId };
                MySqlParameter p1 = new MySqlParameter("v_pvehicleno", MySqlDbType.VarChar) { Value = vehicleAddParam.VehicleNo };
                MySqlParameter p2 = new MySqlParameter("v_pvehicletype", MySqlDbType.VarChar) { Value = vehicleAddParam.VehicleType };
                MySqlParameter p3 = new MySqlParameter("v_pbasecity", MySqlDbType.VarChar) { Value = vehicleAddParam.BaseCity };
                MySqlParameter p4 = new MySqlParameter("v_ppin", MySqlDbType.VarChar) { Value = vehicleAddParam.Pin };
                MySqlParameter p5 = new MySqlParameter("v_pstatus", MySqlDbType.VarChar) { Value = vehicleAddParam.Status };
                MySqlParameter p6 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = vehicleAddParam.CreatedBy };
                MySqlParameter p7 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = vehicleAddParam.TranType };
                MySqlParameter p8 = new MySqlParameter("t_insurance", MySqlDbType.VarChar) { Value = vehiclePath.InsurancePath };
                MySqlParameter p9 = new MySqlParameter("t_rccopy", MySqlDbType.VarChar) { Value = vehiclePath.RcCopyPath };
                MySqlParameter p10 = new MySqlParameter("t_pollution", MySqlDbType.VarChar) { Value = vehiclePath.PollutionPath };
                MySqlParameter p11 = new MySqlParameter("t_permits", MySqlDbType.VarChar) { Value = vehiclePath.PermitPath };
                MySqlParameter p12 = new MySqlParameter("t_vehiclephoto", MySqlDbType.VarChar) { Value = vehiclePath.VehiclePhotoPath };

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });


                var ds = commonUtility.executeReaderProcedure("sp_VenVehicleINSERTUPDATE_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

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

        public VehicleTrackDetailData VehicleTrackView(VehicleTrackParam vehicleTrackParam)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new VehicleTrackDetailData();
            List<VehicleTrackDetails> vehicleViews = new List<VehicleTrackDetails>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("pbidid", MySqlDbType.Int32) { Value = vehicleTrackParam.Pbidid };
                MySqlParameter p1 = new MySqlParameter("puserid", MySqlDbType.VarChar) { Value = vehicleTrackParam.Puserid };
                MySqlParameter p2 = new MySqlParameter("ptype", MySqlDbType.VarChar) { Value = vehicleTrackParam.Ptype };
               



                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2 });


                var ds = commonUtility.executeReaderProcedure("sp_vehicle_tracking_api", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    vehicleViews = commonUtility.ConvertToList<VehicleTrackDetails>(dt);



                }

                retData.data = vehicleViews;




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

        public PaymentViewData PaymentView(PaymentInsertParam  paymentInsertParam)
        {
            var data = new ResponseStatus();
            DataTable dt = new DataTable();
            var retData = new PaymentViewData();
            List<PaymentView> paymentViews = new List<PaymentView>();

            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = paymentInsertParam.BidId };
                MySqlParameter p1 = new MySqlParameter("v_pdate", MySqlDbType.VarChar) { Value = paymentInsertParam.DateVal };
                MySqlParameter p2 = new MySqlParameter("v_prefno", MySqlDbType.VarChar) { Value = paymentInsertParam.RefNo };
                MySqlParameter p3 = new MySqlParameter("v_pamount", MySqlDbType.VarChar) { Value = paymentInsertParam.Amount };
                MySqlParameter p4 = new MySqlParameter("v_ppaytype", MySqlDbType.VarChar) { Value = paymentInsertParam.PayType };
                MySqlParameter p5 = new MySqlParameter("v_ppaidby", MySqlDbType.VarChar) { Value = paymentInsertParam.Paidby };
                MySqlParameter p6 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = paymentInsertParam.Remarks };
                MySqlParameter p7 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = paymentInsertParam.CreatedUser };
                MySqlParameter p8 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = paymentInsertParam.TranType };
                MySqlParameter p9 = new MySqlParameter("v_filepath", MySqlDbType.VarChar) { Value = string.Empty };



                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2,p3,p4,p5,p6,p7,p8, p9 });


                var ds = commonUtility.executeReaderProcedure("sp_PAYMENTINSERTUPDATE_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    paymentViews = commonUtility.ConvertToList<PaymentView>(dt);



                }

                retData.data = paymentViews;




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


        public ResponseStatus BidPaymentAdd(PaymentInsertParam paymentInsertParam,string filePath)
        {
            var data = new ResponseStatus();
            try
            {

                MySqlParameter p0 = new MySqlParameter("v_pbiddid", MySqlDbType.VarChar) { Value = paymentInsertParam.BidId };
                MySqlParameter p1 = new MySqlParameter("v_pdate", MySqlDbType.VarChar) { Value = paymentInsertParam.DateVal };
                MySqlParameter p2 = new MySqlParameter("v_prefno", MySqlDbType.VarChar) { Value = paymentInsertParam.RefNo };
                MySqlParameter p3 = new MySqlParameter("v_pamount", MySqlDbType.VarChar) { Value = paymentInsertParam.Amount };
                MySqlParameter p4 = new MySqlParameter("v_ppaytype", MySqlDbType.VarChar) { Value = paymentInsertParam.PayType };
                MySqlParameter p5 = new MySqlParameter("v_ppaidby", MySqlDbType.VarChar) { Value = paymentInsertParam.Paidby };
                MySqlParameter p6 = new MySqlParameter("v_premarks", MySqlDbType.VarChar) { Value = paymentInsertParam.Remarks };
                MySqlParameter p7 = new MySqlParameter("v_pcreateuser", MySqlDbType.VarChar) { Value = paymentInsertParam.CreatedUser };
                MySqlParameter p8 = new MySqlParameter("v_ptrtype", MySqlDbType.VarChar) { Value = paymentInsertParam.TranType };
                MySqlParameter p9 = new MySqlParameter("v_filepath", MySqlDbType.VarChar) { Value = filePath };


                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 });


                var ds = commonUtility.executeReaderProcedure("sp_PAYMENTINSERTUPDATE_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null)
                {
                    data.StatusText = Convert.ToString(ds.Tables[0].Rows[0]["StatusText"]);
                    data.StatusId = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusId"]);
                    data.CustomValue= Convert.ToString(ds.Tables[0].Rows[0]["CustomValue"]);
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
