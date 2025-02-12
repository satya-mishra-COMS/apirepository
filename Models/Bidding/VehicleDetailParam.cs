using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Bidding
{
    public class VehicleDetailParam
    {
        public string? Screen { get; set; }
        public string? ParamType { get; set; }
        public string? UserId { get; set; }
        public string? Pkid { get; set; }
        
    }
    public class VehicleView
    {
        public string? Srno { get; set; }
        public int FdvehId { get; set; }
        public string? FdUserId { get; set; }
        public string? FdVehicleNo { get; set; }
        public string? FdVehicleType { get; set; }
        public string? FdInsurance { get; set; }
        public string? FdrcCopy { get; set; }
        public string? FdPollution { get; set; }

        public string? FdOtherDoc { get; set; }
        public string? FdPermits { get; set; }
        public string? FdBaseCity { get; set; }
        public string? FdBasecityPin { get; set; }
        public string? FdVehiclePhoto { get; set; }
        public string? FdStatus { get; set; }
        public string? FdCreatedOn { get; set; }
        public string FdCreatedBy { get; set; }
    }

    public class VehicleViewData
    {
        public List<VehicleView> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }

}
