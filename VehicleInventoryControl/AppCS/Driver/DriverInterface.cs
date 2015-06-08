using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.AppCS.ViewModels;

namespace VehicleInventoryControl.AppCS.Driver
{
    public interface DriverInterface
    {
        VehicleCascadeVM GetCascade(string Id); // Unpacked from the controller. This should be done whenever the driver goes to the home view
        VehicleSearchCascadeVM SearchResults(SearchDateTimeVM source); // Search results gathered from the SearchDateTimeVM
        Task<ReserveVM> Reserve(ReserveVM source, string Id); // Reserve. Also, ensure the front end is sending a date without a time to the back end
        void Report(CheckInVM source); // Check in report
        void Remove (int Id); // Soft delete that cancels reservation. Targeting the specific table row.
    }
}
