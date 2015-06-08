using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.Data.Model.Abstracts;

namespace VehicleInventoryControl.Data.Model.Models
{
    public class CheckIn : AbstractVehicle
    {
        [Key]
        public int CheckInId { get; set; }
        [Required]
        public int EmployeeNumber {get;set;}
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

    }
}
