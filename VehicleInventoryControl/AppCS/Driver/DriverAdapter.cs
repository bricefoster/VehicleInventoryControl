using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data;
using VehicleInventoryControl.Data.Model.Models;
using VehicleInventoryControl.Data.Model.ReferenceTables;

namespace VehicleInventoryControl.AppCS.Driver
{
    public class DriverAdapter : DriverInterface
    {
        //GET
        public VehicleCascadeVM GetCascade(string Id) // Unpacked from identity
        {
            VehicleCascadeVM model = new VehicleCascadeVM();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser reference = db.Users.FirstOrDefault(x => x.Id == Id);
                model.FirstName = reference.FirstName;
                model.LastName = reference.LastName;

                model.VehicleDriverCascade = new List<DriverHomeVM>(); // Here is the possible run time exception
                List<DriverHomeVM> refer = db.Drivers_Vehicles.Where(x => x.DriverId == Id && x.Vehicle.IsReserved == true && x.Vehicle.IsDeleted == false).Select(x => new DriverHomeVM() // May throw a run time null exception. If so, uncomment line 23.
                {
                    LicPlate = x.Vehicle.LicPlate,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Year = x.Vehicle.Year,
                    VehicleId = x.Vehicle.VehicleId,
                    ReservationsDates = db.Drivers_Vehicles.Where(y => y.Vehicle.LicPlate == x.Vehicle.LicPlate && y.DriverId == Id && y.Vehicle.IsReserved == true && y.Vehicle.IsDeleted == false).Select(y => new DriverReservedVM()
                    {
                        DateStart = y.Vehicle.DateReserveStart,
                        DateEnd = y.Vehicle.DateReserveEnd,
                        DateReserved = y.Vehicle.DateReserved,
                        IsReserved = true,
                        Id = y.Driver_VehicleId,
                        LicPlate = y.Vehicle.LicPlate,
                        Make = y.Vehicle.Make,
                        Model = y.Vehicle.Model,
                        VehicleId = y.VehicleId,
                        Year = y.Vehicle.Year
                        
                    }).ToList()
                }).ToList();
                foreach (DriverHomeVM vm in refer)
                {
                    if (!model.VehicleDriverCascade.Any(x => x.LicPlate == vm.LicPlate))
                    {
                        foreach (DriverReservedVM m in vm.ReservationsDates)
                        {
                            m.DateStart = new DateTime(m.DateStart.Year, m.DateStart.Month, m.DateStart.Day);
                            if (m.DateStart <= DateTime.Today && DateTime.Today <= m.DateEnd)
                            {
                                m.IsActive = true;
                            }
                            else
                            {
                                m.IsActive = false;
                            }
                        }
                        model.VehicleDriverCascade.Add(vm);
                    }
                }
            }
            return model;
        }

        //SOFT-DELETE
        public void Remove(int Id) // Cancels reservation
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Vehicles.FirstOrDefault(x => x.VehicleId == Id).IsReserved = false;
                db.SaveChanges();
            }
        }

        // Search
        public VehicleSearchCascadeVM SearchResults(SearchDateTimeVM source)
        {
            VehicleSearchCascadeVM model = new VehicleSearchCascadeVM();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Note-Cbiroan, 02 Jan 2015: Since there are two cases, I split the searching under two conditions. The first conditions searches any vehicle with a null date. The
                // second condition searches for vehicles with dates that do not conflict with the requested reservation dates.
                List<VehicleDateTimeSearchVM> challenge = db.Vehicles.Where(x => x.IsDeleted == false).Select(x => new VehicleDateTimeSearchVM()
                {
                    LicPlate = x.LicPlate,
                    Make = x.Make,
                    Model = x.Model,
                    Year = x.Year,
                    VehicleId = x.VehicleId,
                    DateEnd = x.DateReserveEnd,
                    DateStart = x.DateReserveStart,
                    IsReserved = x.IsReserved
                }).ToList();

                model.VehicleSearchCascade = new List<VehicleDateTimeSearchVM>();
                List<VehicleDateTimeSearchVM> duplicates = new List<VehicleDateTimeSearchVM>();
                foreach (VehicleDateTimeSearchVM vm in challenge)
                {
                    if ((!model.VehicleSearchCascade.Any(x => x.LicPlate == vm.LicPlate)))
                    {
                        if (((vm.DateEnd < source.DateStart) || (vm.DateStart > source.DateEnd)))
                        {
                            model.VehicleSearchCascade.Add(new VehicleDateTimeSearchVM()
                            {
                                LicPlate = vm.LicPlate,
                                Make = vm.Make,
                                Model = vm.Model,
                                Year = vm.Year,
                                VehicleId = vm.VehicleId,
                                DateEnd = source.DateEnd,
                                DateStart = source.DateStart
                            });
                        }
                    }
                    else
                    {
                        source.DateEnd = new DateTime(source.DateEnd.Year, source.DateEnd.Month, source.DateEnd.Day);
                        source.DateStart = new DateTime(source.DateStart.Year, source.DateStart.Month, source.DateStart.Day);
                        if (vm.DateStart <= source.DateEnd && source.DateStart <= vm.DateEnd && vm.IsReserved == true)
                        {
                            if (!duplicates.Any(x => x.LicPlate == vm.LicPlate))
                            {
                                duplicates.Add(vm);
                            }
                        }
                    }
                }
                foreach (VehicleDateTimeSearchVM vm in duplicates)
                {
                    model.VehicleSearchCascade.Remove(model.VehicleSearchCascade.FirstOrDefault(z => z.LicPlate == vm.LicPlate));
                }
            }
            return model;
        }

        public async Task<ReserveVM> Reserve(ReserveVM source, string Id) // Ensure the front end is sending dates without time
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if ((!db.Vehicles.Any(x => x.VehicleId == source.Id && x.IsReserved == true))) // Accounts for simultaneous reservation conflicts
                {
                    Automobile reference = db.Vehicles.FirstOrDefault(x => x.VehicleId == source.Id);
                    Automobile reservation = new Automobile()
                    {
                        LicPlate = reference.LicPlate,
                        Make = reference.Make,
                        Model = reference.Model,
                        Year = reference.Year,
                        TotalMiles = reference.TotalMiles,
                        IsDeleted = false,
                        IsReserved = true,
                        DateReserveStart = source.DateStart,
                        DateReserveEnd = source.DateEnd,
                        DateReserved = DateTime.Now.Date
                    };

                    db.Vehicles.Add(reservation); // run time exception?
                    int result = await db.SaveChangesAsync(); // Commit the changes to SQL and check to see if the changes successfully saved.
                    if (result > 0)
                    {
                        db.Drivers_Vehicles.Add(new Driver_Vehicle()
                        {
                            DriverId = Id,
                            VehicleId = reservation.VehicleId
                        });
                        int response = await db.SaveChangesAsync(); // Commit the changes to SQL and check to see if the changes successfully saved.
                        if (response > 0)
                        {
                            return new ReserveVM() { Id = reservation.VehicleId, DateStart = reservation.DateReserveStart, DateEnd = reservation.DateReserveEnd}; // Successful
                        }
                        return null; // failed
                    }
                    return null; // failed
                }
                return null; // failed
            }
        }

        public void Report(CheckInVM source)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.CheckIns.Add(new CheckIn()
                {
                    LicPlate = source.LicPlate,
                    Make = source.Make,
                    Model = source.Model,
                    Destination = source.Destination,
                    Year = source.Year,
                    EndingMileage = source.EndingMileage,
                    NumberOfPassengers = source.NumberOfPassengers,
                    Gallons = source.NumberOfPassengers,
                    Cost = source.Cost,
                    IsDeleted = false,
                    IsReserved = false,
                    EmployeeNumber = source.EmployeeNumber,
                    Comments = source.Comments,
                    DateReserveStart = source.DateStart,
                    DateReserveEnd = source.DateEnd,
                    DateReserved = source.DateReserved,
                    DateStampEnd = DateTime.Now.Date
                });

                db.Vehicles.FirstOrDefault(x => x.VehicleId == source.VehicleId).IsReserved = false;
                db.SaveChanges();
            }
        }

        // The async return methods
    }
}


