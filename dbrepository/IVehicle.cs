using Models.Bidding;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbrepository
{
    public interface IVehicle
    {
        ResponseStatus VehicleAssign(VehicleAssignParam vehicleAssignParam);
        ResponseStatus Communication(Communication communication);
        CommunicationViewData CommunicationView(CommunicationViewParam communicationViewParam);
        VehicleViewData VehicleView(VehicleDetailParam vehicleDetailParam);
        ResponseStatus VehicleAdd(VehicleAddParam vehicleAddParam, VehiclePath vehiclePath);
        VehicleTrackDetailData VehicleTrackView(VehicleTrackParam vehicleTrackParam);
        ResponseStatus BidPaymentAdd(PaymentInsertParam paymentInsertParam, string filePath);
        PaymentViewData PaymentView(PaymentInsertParam paymentInsertParam);
    }
}
