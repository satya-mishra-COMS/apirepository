using dbrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Admin;

namespace Erpapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo adminRepo;
        private readonly ICommonUtility commonUtility;


        public AdminController(IAdminRepo adminRepo,ICommonUtility commonUtility)
        {
            this.adminRepo= adminRepo;
            this.commonUtility = commonUtility;
            // code comment byt satta
            // this is the change
            // Sahoo babu


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login logindto)
        {
          
            var data = this.adminRepo.LoginValidate(logindto);
            

            return Ok(data);
        }
       

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> CreateUser(UserRegister userRegisterdto)
        {
            return Ok(this.adminRepo.UserRegister(userRegisterdto));
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPassword forgetPassword)
        {
            return Ok(this.adminRepo.ForgetPassword(forgetPassword));
        }
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            return Ok(this.adminRepo.ChangePassword(changePassword));
        }
        [HttpGet]       
        [Route("encryptPassword/{password}")]
        public string GetEncryptedPassword(string password)
        {
            return commonUtility.EncodePasswordToBase64(password);
        }
        [HttpGet]
        [Route("decryptPassword/{encryptedPassword}")]
        public string GetDecryptedPassword(string encryptedPassword)
        {
            return commonUtility.DecodePasswordToBase64(encryptedPassword);
        }
        [HttpPost]
        [Route("OtpVerify")]
        public async Task<IActionResult> OtpVerify(UserVerify userVerify)
        {
            var data = this.adminRepo.OtpVerify(userVerify);
            return Ok(data);
        }

    }
}
