using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventoryControl.Data.Model.Abstracts
{
    public abstract class AbstractVehicle
    {
        [Required]
        public int Year { get; set; }
        [Required]
        public string LicPlate { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public bool IsReserved { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime DateReserved { get; set; }
        public DateTime DateReserveStart { get; set; }
        public DateTime DateReserveEnd { get; set; }
    }
}
