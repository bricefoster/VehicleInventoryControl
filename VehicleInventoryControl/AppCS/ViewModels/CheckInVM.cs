using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-Cbiroan, 31 Dec 2014: This is the CheckIn report that is completed by the driver upon checkin
    public class CheckInVM : VehicleDetailVM
    {
        [Required]
        public int EmployeeNumber {get;set;}
        [Required]
        public int CheckInId {get;set;}
        [Required]
        public int EndingMileage { get; set; }
        [Required]
        public int NumberOfPassengers { get; set; }
        [Required]
        public decimal Gallons { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Comments { get; set; }
        public DateTime DateStampEnd { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public DateTime DateReserved { get; set; }
    }
}