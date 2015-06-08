using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class CheckInDatesVM : SearchDateTimeVM
    {
        public DateTime DateReserved { get; set; }
    }
}