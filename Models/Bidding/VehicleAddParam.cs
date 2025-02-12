using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Models.Bidding
{
    public class VehicleAddParam
    {
        public string? VendorId { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? BaseCity { get; set; }
        public string? Pin { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public string? TranType { get; set; }
        public IFormFile? InsurancePath { get; set; }
        public IFormFile? RcCopyPath { get; set; }
        public IFormFile? PollutionPath { get; set; }
        public IFormFile? PermitPath { get; set; }
        public IFormFile? VehiclePhotoPath { get; set; }
       
    }
    public class VehiclePath
    {
        public string? InsurancePath { get; set; }
        public string? RcCopyPath { get; set; }
        public string? PollutionPath { get; set; }
        public string? PermitPath { get; set; }
        public string? VehiclePhotoPath { get; set; }
    }

}
