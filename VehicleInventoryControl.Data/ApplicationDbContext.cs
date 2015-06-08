using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.Data.Model.Models;
using VehicleInventoryControl.Data.Model.ReferenceTables;

namespace VehicleInventoryControl.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		// Model tables
        public DbSet<Automobile> Vehicles { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        // End model tables
        
        // Reference tables
        public DbSet<Driver_Vehicle> Drivers_Vehicles { get; set; }
        // End reference tables
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
