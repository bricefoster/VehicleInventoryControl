using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data.Model.Models;

namespace VehicleInventoryControl.AppCS.Admin.Vehicles
{
    public interface AdminVehicleInterface
    {
        VehicleAdminCascadeVM GetAllVehiclesAdmin();
        Task<bool> AddVehicle(VehicleAddVM source);
        Task<bool> EditVehicleDetail(VehicleDetailVM source);
        Task<bool> Remove(string LicPlate); //Soft Delete
        CheckInVM EditCheckInVM(CheckInVM checkin);
        void RemoveCheckIn(int Id);
        VehicleDetailCascadeVM GetVehicleDetail(int Id);
    }
}
