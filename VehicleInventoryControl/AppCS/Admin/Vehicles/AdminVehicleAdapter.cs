using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data;
using VehicleInventoryControl.Data.Model.Models;


namespace VehicleInventoryControl.AppCS.Admin.Vehicles
{
    public class AdminVehicleAdapter : AdminVehicleInterface
    {
        public VehicleAdminCascadeVM GetAllVehiclesAdmin()
        {
            VehicleAdminCascadeVM model = new VehicleAdminCascadeVM();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.VehicleAdminInfoCascade = new List<VehicleInfoVM>();
                model.VehicleAdminInfoReservedCascade = new List<DriverHomeVM>();
                model.VehicleInventory = new List<VehicleInfoVM>();
                // Gather a reference. Find all vehicles that are either active.
                model.VehicleAdminInfoCascade = db.Vehicles.Where(x => x.IsDeleted == false && x.DateReserveStart == DateTime.Today).Select(x => new VehicleInfoVM()
                {
                    LicPlate = x.LicPlate,
                    Make = x.Make,
                    Model = x.Model,
                    Year = x.Year,
                    IsActive = true,
                    VehicleId = x.VehicleId
                }).ToList();

                List<VehicleInfoVM> refer = db.Vehicles.Where(x => x.IsDeleted == false).Select(x => new VehicleInfoVM()
                {
                    LicPlate = x.LicPlate,
                    Model = x.Model,
                    Make = x.Make,
                    Year = x.Year
                }).ToList();

                // List of reserved, non-active vehicles
                List<DriverHomeVM> reference = db.Vehicles.Where(x => x.IsReserved == true && x.IsDeleted == false && x.DateReserveStart != DateTime.Today).Select(x => new DriverHomeVM()
                {
                    LicPlate = x.LicPlate,
                    Make = x.Make,
                    Model = x.Model,
                    Year = x.Year,
                    VehicleId = x.VehicleId,
                    ReservationsDates = db.Vehicles.Where(y => y.IsReserved == true && y.IsDeleted == false && y.LicPlate == x.LicPlate ).Select(y => new DriverReservedVM()
                    {
                        DateStart = y.DateReserveStart,
                        DateEnd = y.DateReserveEnd,
                        DateReserved = y.DateReserved,
                        IsReserved = true,
                        LicPlate = y.LicPlate,
                        Make = y.Make,
                        Model = y.Model,
                        VehicleId = y.VehicleId,
                        Year = y.Year
                    }).ToList()
                }).ToList();

                foreach (DriverHomeVM vm in reference)
                {
                    // Check for duplicates
                    if (!model.VehicleAdminInfoReservedCascade.Any(x => x.LicPlate == vm.LicPlate))
                    {
                        model.VehicleAdminInfoReservedCascade.Add(vm);
                    }
                }

                foreach (VehicleInfoVM vm in refer)
                {
                    if (!model.VehicleInventory.Any(x => x.LicPlate == vm.LicPlate))
                    {
                        model.VehicleInventory.Add(vm);
                    }
                }
                
            }
            return model;
        }

        public VehicleDetailCascadeVM GetVehicleDetail(int Id)
        {
            VehicleDetailCascadeVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Automobile reference = db.Vehicles.FirstOrDefault(x => x.IsDeleted == false && x.VehicleId == Id);
                
                model = new VehicleDetailCascadeVM()
                {
                    LicPlate = reference.LicPlate,
                    Make = reference.Make,
                    Model = reference.Model,
                    Year = reference.Year,
                    //CurrentlyUsedBy = x.CurrentlyUsedBy,
                    //Note-Cbiroan, 31 Dec 2014: lines 27 to 40 need to be redone. I was getting an error on line 27. At the moment, the (DateTime(year, month, 1) is throwing an error.                    
                };

                model.CheckInCascade = new List<CheckInVM>();
                DateTime Begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime End =  new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

                if (db.CheckIns.Any(y => y.DateStampEnd <= End && y.DateStampEnd >= Begin && y.LicPlate == reference.LicPlate))
                {

                    model.CheckInCascade = db.CheckIns.Where(y => y.DateStampEnd <= End && y.DateStampEnd >= Begin && y.LicPlate == reference.LicPlate).Select(y => new CheckInVM()
                        // //changed y to z and yeat to 2015 and month to Jan
                        {
                            CheckInId = y.CheckInId,
                            Comments = y.Comments,
                            Cost = y.Cost,
                            DateEnd = y.DateReserveEnd,
                            DateReserved = y.DateReserved,
                            DateStart = y.DateReserveStart,
                            EmployeeNumber = y.EmployeeNumber,
                            Destination = y.Destination,
                            DateStampEnd = y.DateStampEnd,
                            EndingMileage = y.EndingMileage,
                            Gallons = y.Gallons,
                            LicPlate = y.LicPlate,
                            Make = y.Make,
                            Model = y.Model,
                            NumberOfPassengers = y.NumberOfPassengers,
                            TotalMiles = y.EndingMileage,
                            Year = y.Year
                        }).ToList();
                }

                List<int> calculate = new List<int>();
                
                foreach (CheckInVM vm in model.CheckInCascade)
                {
                    calculate.Add(vm.EndingMileage);
                }
                calculate.OrderByDescending(x => x);

                if (calculate.Count != 0)
                {
                    int val = 0; 
                    for (int a = 0; a < calculate.Count; a++)
                    {
                        if (a < calculate.Count && (a + 1) != calculate.Count)
                        {
                            val = val + (calculate[a] - calculate[a + 1]);
                        }
                    }
                    model.TotalMilesForMonth = val;
                    model.TotalMiles = calculate[0];
                }
            }
            return model;
        }
        // //GET
        //    public VehicleCascadeVM(string Id);
        //{
        //    VehicleCascadeVM  model;
        //    using(ApplicationDbContext db = new ApplicationDbContext())
        //{

        //        model = db.Vehicles.Where(x => x.Id == string Id && IsDeleted == false);
        //{

        //}

        //return model;
        //}
        //   }

        //SOFT-DELETE
        //    public Remove(string LicPlate); 
        //{
        //    using(ApplicationDbContext db = new ApplicationDbContext())
        //{
        //    model = db.Vehicles.Select(x => x.LicPlate == LicPlate);
        //    model.IsDeleted = true;
        //}
        //}
        //public VehicleCascadeVM SearchResults(SearchDateTimeVM source)
        ////using(ApplicationDbContext db = new ApplicationDbContext())
        //{
        //using(ApplicationDbContext db = new ApplicationDbContext())
        //{
        //model = db.Vehicles.Where((x => x.DateReserveStart < source.DateReserveEnd && source.DateReserveStart < x.DateReserveEnd) && IsDeleted == False);
        //Vehicle model = new Vehicle() {
        //DateReserved  = DateTime.Now(),
        //DateReserveEnd = source.DateReserveEnd,
        //LicPlate = source.LicPlate,
        //Make = source.Make,
        //Model = source.Model,
        //Year = source.Year};
        //if(DateTime.Now == DateReserveStart) {
        //IsReserved = true;
        //IsActive = True;
        //}
        //else{
        //IsReserved = True;
        //IsActive = False;
        //}
        //db.Vehicles.Add(model);
        //}
        //}

        //public bool Report(CheckInVM source)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        CheckInVM model = new CheckInVM()
        //        {
        //            EndingMilage = source.EndingMilage,
        //            Destination = source.Destination,
        //            NumberOfPassengers = source.NumberOfPassengers,
        //            Gallons = source.Gallons,
        //            PricePerGallon = source.PricePerGallon,
        //            Comments = source.Comments,
        //            DateStampEnd = source.DateStampEnd,
        //            EmployeeNumber = source.EmployeeNumber
        //        };
        //        //if (ModelState.IsValid)
        //        //{
        //        //Report(source);
        //        //}
        //        //else
        //        //{
        //        //    //return Ok(new HTTPResponseMessage(HTTPStatusCode.NotAccepted)); //returns 409
        //        //}
        //    }
        //    return model
        //}
        public async Task<bool> AddVehicle(VehicleAddVM source)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Vehicles.Any(x => x.LicPlate == source.LicPlate)) // Prevent duplicates
                {
                    return false;
                }
                else
                {
                    db.Vehicles.Add(new Automobile()
                   {
                       LicPlate = source.LicPlate,
                       Make = source.Make,
                       Model = source.Model,
                       Year = source.Year,
                       TotalMiles = source.Miles,
                       DateReserveStart = new DateTime(2000, 1, 1, 0, 0, 0),
                       DateReserveEnd = new DateTime(2000, 1, 1, 0, 0, 0),
                       DateReserved = new DateTime(2000, 1, 1, 0, 0, 0),
                       IsDeleted = false,
                       IsReserved = false
                   });
                }
                int check = await db.SaveChangesAsync();
                if (check > 0)
                {
                    return true; // Successful change.
                }
                return false; // Failed to change.
            }
        }
        public async Task<bool> EditVehicleDetail(VehicleDetailVM source)
        {
           
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Automobile reference = db.Vehicles.FirstOrDefault(x => x.LicPlate == source.LicPlate);
                
                reference.LicPlate = source.LicPlate;
                reference.Make = source.Make;
                reference.Model = source.Model;
                reference.Year = source.Year;
                reference.TotalMiles = source.TotalMiles;
                //reference.CurrentlyUsedBy = source.CurrentlyUsedBy; // Stretch goal

                if (await db.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
        }
        //SOFT DELETE
         public async Task<bool> Remove(string LicPlate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // We must go through the entire vehicles table.
                List<int> reference = db.Vehicles.Where(x => x.LicPlate == LicPlate).Select(x => x.VehicleId).ToList();

                foreach (int index in reference)
                {
                    Automobile refer = db.Vehicles.FirstOrDefault(x => x.VehicleId == index);
                    refer.IsDeleted = true;
                    refer.IsReserved = false;
                }

                int challenge = await db.SaveChangesAsync(); // Please note that we could check for a specific amount of changes.
                if (challenge > 0)
                {
                    return true; // Successful change
                }
                return false;
            }
        }
        public CheckInVM EditCheckInVM(CheckInVM checkin)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CheckIn model = db.CheckIns.FirstOrDefault(x => x.CheckInId == checkin.CheckInId);

                model.EndingMileage = checkin.EndingMileage;
                model.Destination =  checkin.Destination;
                model.NumberOfPassengers = checkin.NumberOfPassengers;
                model.Gallons = checkin.Gallons;
                model.Cost = checkin.Cost;
                model.Comments = checkin.Comments;
                model.DateStampEnd = checkin.DateStampEnd;
                model.EmployeeNumber = checkin.EmployeeNumber;
                db.SaveChanges();
             
            }
            return checkin;
        }

        public void RemoveCheckIn(int Id) // This Id must be the primary key
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.CheckIns.Find(Id).IsDeleted = true;
                db.SaveChanges();
            }
        }
    }
}