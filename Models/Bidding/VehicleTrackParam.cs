using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Bidding
{
    public class VehicleTrackParam
    {
        public int Pbidid { get; set; }
        public string? Puserid { get; set; }
        public string? Ptype { get; set; }

    }
    public class VehicleTrackDetails
    {
        public string? Fdid { get; set; }
        public string? Fdorigin { get; set; }
        public string? Fddestination { get; set; }
        public string? Fdcommodity { get; set; }
        public string? FdVehicleno { get; set; }
        public string? FdDriverName { get; set; }
        public string? FdMobileNo { get; set; }
        public string? Fdlatitude { get; set; }
        public string? fdlongitude { get; set; }
        public string TripStatus { get; set; }


    }

    public class VehicleTrackDetailData
    {
        public List<VehicleTrackDetails> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }


}
