using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.Data.Model.Models;

namespace VehicleInventoryControl.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool roles = false, bool drivers = false, bool vehicles = false)
        {
            if (roles) SeedRoles(db);
            if (drivers) SeedDrivers(db);
            if (vehicles) SeedVehicles(db);
            // Seed additional content?
        }
        private static void SeedRoles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            if (!db.Roles.Any(x => x.Name == "Driver"))
            {
                manager.Create(new IdentityRole() { Name = "Driver" });
            }
            if (!db.Roles.Any(x => x.Name == "Admin"))
            {
                manager.Create(new IdentityRole() { Name = "Admin" });
            }
            db.SaveChanges();
        }

        private static void SeedDrivers(ApplicationDbContext db)
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);

            // Users
            if (!db.Users.Any(x => x.UserName == "Driver1"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "Driver1",
                    Email = "Driver1@test.com",
                    EmailConfirmed = true,
                    FirstName = "firstName",
                    LastName = "LastName",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123456");
                if (db.Users.Any(x => x.Id == User.Id))
                {
                    manager.AddToRole(User.Id, "Driver");
                    db.SaveChanges();
                }
            }
            db.SaveChanges();

            if (!db.Users.Any(x => x.UserName == "Driver2"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "Driver2",
                    Email = "Driver2@test.com",
                    EmailConfirmed = true,
                    FirstName = "firstName",
                    LastName = "LastName",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123546");
                if (db.Users.Any(x => x.Id == User.Id)) // make async
                {
                    manager.AddToRole(User.Id, "Driver");
                    db.SaveChanges();
                }
            }

            if (!db.Users.Any(x => x.UserName == "Driver3"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "Driver3",
                    Email = "Driver3@test.com",
                    EmailConfirmed = true,
                    FirstName = "firstName",
                    LastName = "LastName",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123546");
                if (db.Users.Any(x => x.Id == User.Id))
                {
                    manager.AddToRole(User.Id, "Driver");
                    db.SaveChanges();
                }
            }

            if (!db.Users.Any(x => x.UserName == "Driver4"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "Driver4",
                    Email = "Driver4@test.com",
                    EmailConfirmed = true,
                    FirstName = "firstName",
                    LastName = "LastName",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123546");
                if (db.Users.Any(x => x.Id == User.Id))
                {
                    manager.AddToRole(User.Id, "Driver");
                    db.SaveChanges();
                }
            }

            if (!db.Users.Any(x => x.UserName == "Driver5"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "Driver5",
                    Email = "Driver5@test.com",
                    EmailConfirmed = true,
                    FirstName = "firstName",
                    LastName = "LastName",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123546");
                if (db.Users.Any(x => x.Id == User.Id))
                {
                    manager.AddToRole(User.Id, "Driver");
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception();
                }
            }

            if (!db.Users.Any(x => x.UserName == "Driver6"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "Driver6",
                    Email = "Driver6@test.com",
                    EmailConfirmed = true,
                    FirstName = "firstName",
                    LastName = "LastName",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123546");
                if (db.Users.Any(x => x.Id == User.Id))
                {
                    manager.AddToRole(User.Id, "Driver");
                    db.SaveChanges();
                }
            }
            // End Users
            db.SaveChanges();

            // Admin
            if (!db.Users.Any(x => x.UserName == "Admin"))
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = "kcrump",
                    Email = "kcrump@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Kevin",
                    LastName = "Krump",
                    DLExpDate = DateTime.Now,
                    InsExpDate = DateTime.Now
                };
                manager.Create(User, "123456");
                if (db.Users.Any(x => x.Id == User.Id))
                {
                    manager.AddToRole(User.Id, "Admin");
                    db.SaveChanges();
                }
            }
            // End Admin
            db.SaveChanges();
        }

        private static void SeedVehicles(ApplicationDbContext db)
        {
            // Base vehicles
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "475-S3D", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 23852, IsDeleted = false, IsReserved = false, DateReserveStart = DateTime.Today, DateReserveEnd = DateTime.Today, DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = false, DateReserveStart = DateTime.Today, DateReserveEnd = DateTime.Today, DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "936-JAC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 24163, IsDeleted = false, IsReserved = false, DateReserveStart = DateTime.Today, DateReserveEnd = DateTime.Today, DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "205-YLS", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 76372, IsDeleted = false, IsReserved = false, DateReserveStart = DateTime.Today, DateReserveEnd = DateTime.Today, DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "49X-J3X", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 76372, IsDeleted = false, IsReserved = false, DateReserveStart = DateTime.Today, DateReserveEnd = DateTime.Today, DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "5J2-58X", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 76372, IsDeleted = false, IsReserved = false, DateReserveStart = DateTime.Today, DateReserveEnd = DateTime.Today, DateReserved = DateTime.Today });
            // End base vehicles
            // Active
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "205-YLS", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 76372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 01, 05), DateReserveEnd = DateTime.Today, DateReserved = new DateTime(2015, 01, 04) });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = DateTime.Today, DateReserveEnd = new DateTime(2015, 01, 07), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "5J2-58X", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 76372, IsDeleted = false, IsReserved = true, DateReserveStart = DateTime.Today, DateReserveEnd = new DateTime(2015, 01, 07), DateReserved = DateTime.Today });
            // End Active
            // Only reserved
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 01, 29), DateReserveEnd = new DateTime(2015, 01, 30), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,
                new Automobile() { LicPlate = "205-YLS", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 01, 15), DateReserveEnd = new DateTime(2015, 01, 16), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "936-JAC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 01, 23), DateReserveEnd = new DateTime(2015, 01, 24), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "205-YLS", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 03, 29), DateReserveEnd = new DateTime(2015, 03, 30), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 02, 02), DateReserveEnd = new DateTime(2015, 02, 05), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "475-S3D", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 04, 29), DateReserveEnd = new DateTime(2015, 05, 01), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "49X-J3X", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 04, 05), DateReserveEnd = new DateTime(2015, 04, 06), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 05, 29), DateReserveEnd = new DateTime(2015, 05, 30), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "475-S3D", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 06, 29), DateReserveEnd = new DateTime(2015, 06, 30), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 07, 01), DateReserveEnd = new DateTime(2015, 07, 01), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "49X-J3X", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 03, 22), DateReserveEnd = new DateTime(2015, 03, 24), DateReserved = DateTime.Today });
            db.Vehicles.AddOrUpdate(x => x.LicPlate,                                                                                                                    
                new Automobile() { LicPlate = "528-XRC", Year = 2014, Make = "Cheverolet", Model = "Express", TotalMiles = 15372, IsDeleted = false, IsReserved = true, DateReserveStart = new DateTime(2015, 02, 14), DateReserveEnd = new DateTime(2015, 02, 15), DateReserved = DateTime.Today });
        }
    }
}

