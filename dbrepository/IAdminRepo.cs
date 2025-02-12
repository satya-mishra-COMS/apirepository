using Models;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbrepository
{
    public interface IAdminRepo
    {
        Userdetail LoginValidate(Login logindto);
        ResponseStatus ForgetPassword(ForgetPassword forgetPassword);
        ResponseStatus UserRegister(UserRegister userRegisterdto);
        ResponseStatus ChangePassword(ChangePassword changePassword);
        string GetEncryptedPassword(string password);
        string GetDecryptPassword(string encryptedPassword);
        ResponseStatus OtpVerify(UserVerify userVerify);

    }
}

