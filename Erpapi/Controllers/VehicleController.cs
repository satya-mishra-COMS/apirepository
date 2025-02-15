using dbrepository;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Bidding;
using System;

namespace Erpapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicle vehicle;
        private readonly IWebHostEnvironment _env;
        public VehicleController(IWebHostEnvironment env, IVehicle vehicle)
        {
            _env = env;
            this.vehicle = vehicle;
        }
        [HttpPost]
        [Route("bidvehicleassign")]
        public IActionResult VehicleAssignj(VehicleAssignParam vehicleAssignParam)
        {
            return Ok(this.vehicle.VehicleAssign(vehicleAssignParam));
        }
        [HttpPost]
        [Route("bidcommunication")]
        public IActionResult Communication(Communication communication)
        {
            return Ok(this.vehicle.Communication(communication));
        }
        [HttpPost]
        [Route("communicationView")]
        public IActionResult CommunicationView(CommunicationViewParam communicationViewParam)
        {
            return Ok(this.vehicle.CommunicationView(communicationViewParam));
        }

        //    [HttpGet]
        //    public async Task<IActionResult> GetFileById()
        //    {
        //        string path = "\path\to\the\file.txt"


        //if (System.IO.File.Exists(path))
        //        {
        //            return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
        //        }
        //        return NotFound();
        //    }

        [HttpPost]
        [Route("vehicleView")]
        public IActionResult VehicleView(VehicleDetailParam vehicleDetailParam)
        {
            var getData = this.vehicle.VehicleView(vehicleDetailParam);

            return Ok(getData);
        }
        [HttpPost]
        [Route("paymentInsert")]
        public IActionResult AddPayment(PaymentInsertParam paymentInsertParam)
        {

            var files = new List<IFormFile>();
            var vehiclePath = new VehiclePath();
            var uploadtype = string.Empty;
            string filePathval = string.Empty;

            var result = this.vehicle.BidPaymentAdd(paymentInsertParam, paymentInsertParam.FilePath == null ? "" : paymentInsertParam.FilePath.FileName);
            if (paymentInsertParam.FilePath != null && result.CustomValue != null)
            {
                //vehiclePath.InsurancePath = vehicleAddParam.InsurancePath.FileName;
                files.Add(paymentInsertParam.FilePath);
                filePathval = Paymentscreenshotupload(paymentInsertParam.FilePath, paymentInsertParam.BidId, paymentInsertParam.CreatedUser, result.CustomValue);
            }


            return Ok(this.vehicle.BidPaymentAdd(paymentInsertParam, filePathval));
        }

        [HttpPost]
        [Route("addVehicle")]
        public IActionResult AddVehicle(VehicleAddParam vehicleAddParam)
        {

            var files = new List<IFormFile>();
            var vehiclePath = new VehiclePath();
            var uploadtype = string.Empty;

            if (vehicleAddParam.InsurancePath != null)
            {
                //vehiclePath.InsurancePath = vehicleAddParam.InsurancePath.FileName;
                files.Add(vehicleAddParam.InsurancePath);
                uploadtype = "Insurance";
                vehiclePath.InsurancePath = photoupload(vehicleAddParam.InsurancePath, vehicleAddParam.VehicleNo, vehicleAddParam.CreatedBy, uploadtype);
            }
            if (vehicleAddParam.RcCopyPath != null)
            {
                //vehiclePath.RcCopyPath = vehicleAddParam.RcCopyPath.FileName;
                files.Add(vehicleAddParam.RcCopyPath);
                uploadtype = "RC";
                vehiclePath.RcCopyPath = photoupload(vehicleAddParam.RcCopyPath, vehicleAddParam.VehicleNo, vehicleAddParam.CreatedBy, uploadtype);
            }
            if (vehicleAddParam.PollutionPath != null)
            {
                //vehiclePath.PollutionPath = vehicleAddParam.PollutionPath.FileName;
                files.Add(vehicleAddParam.PollutionPath);
                uploadtype = "Pollution";
                vehiclePath.PollutionPath = photoupload(vehicleAddParam.PollutionPath, vehicleAddParam.VehicleNo, vehicleAddParam.CreatedBy, uploadtype);
            }
            if (vehicleAddParam.PermitPath != null)
            {
                //vehiclePath.PermitPath = vehicleAddParam.PermitPath.FileName;
                files.Add(vehicleAddParam.PermitPath);
                uploadtype = "Permit";
                vehiclePath.PermitPath = photoupload(vehicleAddParam.PermitPath, vehicleAddParam.VehicleNo, vehicleAddParam.CreatedBy, uploadtype);
            }
            if (vehicleAddParam.VehiclePhotoPath != null)
            {
                vehiclePath.VehiclePhotoPath = vehicleAddParam.VehiclePhotoPath.FileName;
                files.Add(vehicleAddParam.VehiclePhotoPath);
                uploadtype = "Vehicle";
                vehiclePath.VehiclePhotoPath = photoupload(vehicleAddParam.VehiclePhotoPath, vehicleAddParam.VehicleNo, vehicleAddParam.CreatedBy, uploadtype);
            }

            return Ok(this.vehicle.VehicleAdd(vehicleAddParam, vehiclePath));
        }
        [NonAction]
        public string photoupload(IFormFile file, string vehicleNo, string transporterId, string uploadtype)
        {
            string folderpath = Path.Combine(_env.ContentRootPath, "DespatchCopy");
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            string finalFilename = "";


            if (file != null && file.Length > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderpath, transporterId + "_" + vehicleNo + "_" + uploadtype + extension);
                finalFilename = Path.GetFileName(filePath);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }


            return finalFilename;

        }
        [NonAction]
        public string Paymentscreenshotupload(IFormFile file, string bidId, string transporterId, string filenamefrmDb)
        {
            string folderpath = Path.Combine(_env.ContentRootPath, "PaymentFiles");
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            string finalFilename = "";


            if (file != null && file.Length > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderpath, filenamefrmDb);
                finalFilename = Path.GetFileName(filePath);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }


            return finalFilename;

        }
        [HttpPost]
        [Route("vehicleTrackingView")]
        public IActionResult VehicleTrackingView(VehicleTrackParam vehicleTrackParam)
        {
            var getData = this.vehicle.VehicleTrackView(vehicleTrackParam);

            return Ok(getData);
        }

        [HttpPost]
        [Route("paymentView")]
        public IActionResult PaymentView(PaymentInsertParam paymentView)
        {
            var getData = this.vehicle.PaymentView(paymentView);

            return Ok(getData);
        }

    }
}
