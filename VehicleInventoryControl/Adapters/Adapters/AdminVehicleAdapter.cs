using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data;
using VehicleInventoryControl.Data.Model.Models;

namespace VehicleInventoryControl.AppCS.Admin.Vehicles
{
    public class AdminVehicleAdapter : AdminVehicleInterface
    {
        public List<VehicleDetailCascadeVM> GetAllVehiclesAdmin()
        {
            VehicleDetailCascadeVM model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Vehicles.Where( x => x.IsDeleted == false).Select(x => new VehicleDetailCascadeVM()
                {
                    LicPlate = x.LicPlate,
                    Make = x.Make,
                    Model = x.Model,
                    Year = x.Year,
                    TotalMiles = x.TotalMiles,
                    //Note-Cbiroan, 31 Dec 2014: lines 27 to 40 need to be redone. I was getting an error on line 27. At the moment, the (DateTime(year, month, 1) is throwing an error.
                    CheckInCascade = db.CheckIns.Where(y => y.DateStampEnd <= (DateTime(year, month, 1).AddMonths(1).AddDays(-1)) && y.DateStampEnd >= (DateTime(now.year, now.month, 1) && y.LicPlate == x.LicPlate).Select(y => new CheckInVM()
                    {
                        TotalMilesForMonth = x.TotalMilesForMonth,
                        CurrentlyUsedBy = x.CurrentlyUsedBy,
                        Id = y.EmployeeId,
                        EndingMileage = y.EndingMileage,
                        Destination = y.Destination,
                        NumberOfPassengers = y.NumberOfPassengers,
                        Gallons = y.Gallons,
                        PricePerGallon = y.PricePerGallon,
                        Comment = y.Comment,
                        DateStampEnd = y.DateStampEnd
                    }).ToList())
                });
                return model;
                }
            }
        }
    }
}


// //GET
public VehicleCascadeVM(string Id);
{
using(ApplicationDbContext db = new ApplicationDbContext)
{
    VehicleCascadeVM = model;
    model = db.Vehicles.Where(x => x.Id == string Id && IsDeleted == false);
    return model;
}
}

//    //SOFT-DELETE
public Remove(string LicPlate); 
{
using(ApplicationDbContext db = new ApplicationDbContext)
{
model = db.Vehicles.Select(x => x.LicPlate == LicPlate);
model.IsDeleted = true;
}
}
//public VehicleCascadeVM SearchResults(SearchDateTimeVM source)
//using(ApplicationDbContext db = new ApplicationDbContext)
//{
//using(ApplicationDbContext db = new ApplicationDbContext)
//{
//model = db.Vehicles.Where.Select((x => x.DateReserveStart < source.DateReserveEnd && source.DateReserveStart < x.DateReserveEnd) && IsDeleted == False);
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
//using(ApplicationDbContext db = new ApplicationDbContext)
//{
//CheckInVM model = new CheckInVM() {
//EndingMileage = source.EndingMileage,
//Destination = source.Destination,
//NumberOfPassengers = source.NumberOfPassengers,
//Gallons = source.Gallons,
//PricePerGallon = source.PricePerGallon,
//Comments = source.Comments,
//DateStampEnd = source.DateStampEnd,
//EmployeeNumber = source.EmployeeNumber};
//if(modelstate.IsValid){
//_adapter.Report(source);
//}
//else{
//return Ok(new HTTPResponseMessage(HTTPStatusCode.NotAccepted)); //returns 409
//};
//}
//public bool AddVehicle(VehicleAddVM source)
//using(ApplicationDbContext db = new ApplicationDbContext)
//if(db.Vehicles.Any(x => x.LicPlate == source.LicPlate)) {
//return (false);
//}
//else
//{
//db.Vehicles.AddOrUpdate( x => x.LicPlate, new Vehicle() {
//source.LicPlate = x.LicPlate,
//source.Make = x.Make,
//source.Model = x.Model,
//source.Year = x.Year,
//source.Miles = x.Miles};
//db.SaveChanges();
//return (true);)
//}

//public void VehicleDetailVM Edit(VehicleDetailVM source)
//using(ApplicationDbContext db = new ApplicationDbContext)
//VehicleDetailVM model = db.Vehicles.Find(source.LicPlate);
//model.LicPlate = source.LicPlate;
//model.Make = source.Make;
//model.Model = source.Model;
//model.Year = source.Year;
//model.TotalMiles = source.TotalMiles;
//model.TotalMilesForMonth = source.TotalMilesForMonth;
//model.CurrentlyUsedBy = source.CurrentlyUsedBy;
//db.SaveChanges();
//}
////SOFT DELETE
//Public bool Remove (string LicPlate)
//using(ApplicationDbContext db = new ApplicationDbContext)
//{
//model = db.Vehicles.Select(x => x.LicPlate == LicPlate);
//model.IsDeleted = true;
//db.SaveChanges();
//}
//public void CheckInVM EditCheckInVM(int Id)
//using(ApplicationDbContext db = new ApplicationDbContext)
//{
//CheckInVM model = db.CheckIns.Find(x => x.Id == Id);
//x.EndingMileage = model.EndingMileage;
//x.Destination = model.Destination;
//x.NumberOfPassengers = model.NumberOfPassengers;
//x.Gallons = model.Gallons;
//x.PricePerGallon = model.PricePerGallon;
//x.Comments = model.Comments;
//x.DateStampEnd = model.DateStampEnd;
//x.EmployeeNumber = model.EmployeeNumber;
//db.SaveChanges();

//}