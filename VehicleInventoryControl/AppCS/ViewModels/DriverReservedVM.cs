using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class DriverReservedVM : VehicleSearchVM
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateReserved { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
    }
}