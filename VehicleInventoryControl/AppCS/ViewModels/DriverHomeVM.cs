using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-Cbiroan, 31 Dec 2014: This class is for returning a view model displaying what vehicles are reserved for the driver at specific dates.
    // This corresponds to the driver's home page. 
    public class DriverHomeVM : VehicleSearchVM
    {
        public List<DriverReservedVM> ReservationsDates { get; set; } //Note-Cbiroan, 5 Jan 2015: THIS WILL NOT WORK. MOVE THIS LIST TO ANOTHER VM
    }
}