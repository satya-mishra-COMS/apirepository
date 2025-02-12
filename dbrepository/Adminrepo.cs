using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Models;
using Models.Admin;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using Microsoft.Extensions.Options

namespace dbrepository
{
    public class Adminrepo : IAdminRepo
    {
        private readonly IOptions<DbConnection> options;
        private readonly ICommonUtility commonUtility;
        public Adminrepo(IOptions<DbConnection> options, ICommonUtility commonUtility)
        {
            this.options = options;
            this.commonUtility = commonUtility;
        }

        public ResponseStatus ForgetPassword(ForgetPassword forgetPassword)
        {
            var data = new ResponseStatus();
            try
            {
                var outparval = 0;
                MySqlParameter p0 = new MySqlParameter("userid", MySqlDbType.VarChar) { Value = forgetPassword.UserId };
                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.Add(p0);
                var ds = commonUtility.executeReaderProcedure("sp_forgetpassword_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

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
        public ResponseStatus ChangePassword(ChangePassword changePassword)
        {
            var data = new ResponseStatus();
            try
            {
                var outparval = 0;
                
                MySqlParameter p0 = new MySqlParameter("userid", MySqlDbType.VarChar) { Value = changePassword.Username };
                MySqlParameter p1 = new MySqlParameter("oldpassword", MySqlDbType.VarChar) { Value = commonUtility.EncodePasswordToBase64(changePassword.OldPassword) };
                MySqlParameter p2 = new MySqlParameter("newpassword", MySqlDbType.VarChar) { Value = commonUtility.EncodePasswordToBase64(changePassword.Newpassword) };

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2});
                var ds = commonUtility.executeReaderProcedure("sp_changepassword_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

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

        public Userdetail LoginValidate(Login logindto)
        {
            var data = new Userdetail();
            try
            {
                var outparval = 0;
                MySqlParameter p0 = new MySqlParameter("v_pusername", MySqlDbType.VarChar) { Value = logindto.Username };
                MySqlParameter p1 = new MySqlParameter("v_phost", MySqlDbType.VarChar) { Value = logindto.Host };
                MySqlParameter p2 = new MySqlParameter("v_ppin", MySqlDbType.VarChar) { Value = logindto.Pin };
                MySqlParameter p4 = new MySqlParameter("v_password", MySqlDbType.VarChar) { Value = commonUtility.EncodePasswordToBase64(logindto.Password) };
                MySqlParameter p5 = new MySqlParameter("v_loginip", MySqlDbType.VarChar) { Value = logindto.Loginip };
                MySqlParameter p6 = new MySqlParameter("v_plocation", MySqlDbType.VarChar) { Value = logindto.Location };
                MySqlParameter p7 = new MySqlParameter("v_pcountry", MySqlDbType.VarChar) { Value = logindto.Country };
                MySqlParameter p8 = new MySqlParameter("v_porg", MySqlDbType.VarChar) { Value = logindto.Org };
                MySqlParameter p9 = new MySqlParameter("v_out", MySqlDbType.Int32) { Value = outparval };
                p9.Direction = System.Data.ParameterDirection.Output;

                var lstMySqlparam = new List<MySqlParameter>();
                
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2,p4,p5,p6,p7,p8,p9 });

                var ds = commonUtility.executeReaderProcedure("LoginAuthenticatepassword_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    data.fdUserId = Convert.ToInt32(ds.Tables[0].Rows[0]["fdUserId"]);
                    data.fdUserName = Convert.ToString(ds.Tables[0].Rows[0]["fdUserName"]);
                    //data.fdEmployeeName = Convert.ToString(ds.Tables[0].Rows[0]["fdEmployeeName"]);
                    data.fdPassword = Convert.ToString(ds.Tables[0].Rows[0]["fdPassword"]);
                    data.fdContactNo = Convert.ToString(ds.Tables[0].Rows[0]["fdContactNo"]);
                    data.fdEmailId = Convert.ToString(ds.Tables[0].Rows[0]["fdEmailId"]);
                    data.fdUserType = Convert.ToString(ds.Tables[0].Rows[0]["fdUserType"]);

                    data.StatusText = "Success";
                    data.StatusId = 1;

                }
                else
                {
                    data.StatusText = "User doesn’t exists. Please check";
                    data.StatusId = 0;
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

        public ResponseStatus OtpVerify(UserVerify userVerify)
        {
            var data = new Userdetail();
            try
            {
                var outparval = 0;
                MySqlParameter p0 = new MySqlParameter("p_userid", MySqlDbType.VarChar) { Value = userVerify.UserId };
                MySqlParameter p1 = new MySqlParameter("p_type", MySqlDbType.VarChar) { Value = userVerify.OtpType };
                MySqlParameter p2 = new MySqlParameter("p_otp", MySqlDbType.VarChar) { Value = userVerify.Otp };
                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2 });

                var ds = commonUtility.executeReaderProcedure("sp_verify_contactotp_bytype_api", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    data.StatusText = Convert.ToString(ds.Tables[0].Rows[0]["StatusText"]);
                    data.StatusId = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusId"]); ;

                }
                else
                {
                    data.StatusText = "No Data found";
                    data.StatusId = 0;
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


        public ResponseStatus UserRegister(UserRegister userRegisterdto)
        {
            var data = new ResponseStatus();
            try
            {
                var outparval = 0;

                MySqlParameter p0 = new MySqlParameter("v_pusername", MySqlDbType.VarChar) { Value = userRegisterdto.UserName };
                MySqlParameter p1 = new MySqlParameter("v_pusertype", MySqlDbType.VarChar) { Value = userRegisterdto.Usertype };
                MySqlParameter p2 = new MySqlParameter("v_pcontactno", MySqlDbType.VarChar) { Value = userRegisterdto.ContactNo };
                MySqlParameter p4 = new MySqlParameter("v_pmailid", MySqlDbType.VarChar) { Value = userRegisterdto.EmailId };
                MySqlParameter p5 = new MySqlParameter("v_ppickup", MySqlDbType.VarChar) { Value = userRegisterdto.Pickup };
                MySqlParameter p6 = new MySqlParameter("v_ppassword", MySqlDbType.VarChar) { Value = commonUtility.EncodePasswordToBase64(userRegisterdto.Password) };
                MySqlParameter p7 = new MySqlParameter("v_paddress", MySqlDbType.VarChar) { Value = userRegisterdto.Address };
                MySqlParameter p8 = new MySqlParameter("v_pcity", MySqlDbType.VarChar) { Value = userRegisterdto.City };
                MySqlParameter p9 = new MySqlParameter("v_prefno", MySqlDbType.VarChar) { Value = userRegisterdto.ReferenceNo };
                MySqlParameter p10 = new MySqlParameter("v_ppincode", MySqlDbType.VarChar) { Value = userRegisterdto.Pin };
                MySqlParameter p11 = new MySqlParameter("v_pstate", MySqlDbType.VarChar) { Value = userRegisterdto.State };
                MySqlParameter p12 = new MySqlParameter("v_pcountry", MySqlDbType.VarChar) { Value = userRegisterdto.Country };
                MySqlParameter p13 = new MySqlParameter("v_createuser", MySqlDbType.VarChar) { Value = userRegisterdto.UserName };
                MySqlParameter p14 = new MySqlParameter("v_trtype", MySqlDbType.VarChar) { Value = userRegisterdto.Trtype };
                MySqlParameter p15 = new MySqlParameter("v_out", MySqlDbType.Int32) { Value = outparval };
                p9.Direction = System.Data.ParameterDirection.Output;

                var lstMySqlparam = new List<MySqlParameter>();
                lstMySqlparam.AddRange(new List<MySqlParameter>() { p0, p1, p2, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15 });

                var ds = commonUtility.executeReaderProcedure("SP_USERREGISTRATIONINSERT_API", lstMySqlparam, Convert.ToString(this.options.Value.DefaultConnection));

                if (ds.Tables.Count>0 )
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

        public string GetEncryptedPassword(string password)
        {
            var generatedPassword = "";
            try
            {
                generatedPassword = commonUtility.EncodePasswordToBase64(password);


            }
            catch (Exception ex)
            {
                 generatedPassword = "Error in generating password";
            }
            return generatedPassword;
        }
        public string GetDecryptPassword(string encryptedPassword)
        {
            var decryptedPassword = "";
            try
            {
                decryptedPassword = commonUtility.DecodePasswordToBase64(encryptedPassword);


            }
            catch (Exception ex)
            {
                decryptedPassword = "Error in Decrypting password";
            }
            return decryptedPassword;
        }

    }
}
