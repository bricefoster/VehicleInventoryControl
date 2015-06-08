using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data.Model.Models;

namespace VehicleInventoryControl.AppCS.Admin.Vehicles
{
    interface AdminVehicleInterface
    {
        Vehicle DetailCascadeVM Get();
        bool Post(VehicleAddVM);
        VehicleDetailVM EditVehicleDetail(VehicleDetailVM);
        bool Remove(string LicPlate); //Soft Delete
        CheckInVM EditCheckInVM(int Id);
        bool RemoveCheckIn(int Id);
    }
}
