using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data;
using VehicleInventoryControl.Data.Model.Models;

namespace VehicleInventoryControl.AppCS.Admin.Drivers
{
    public class AdminDriverAdapter : AdminDriverInterface
    {
        //GET
        public DriverSearchCascadeVM GetCascade()
        {
            DriverSearchCascadeVM model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = new DriverSearchCascadeVM()
                {
                    DriverSearchCascade = db.Users.Where(x => x.IsDeleted == false).Select(x => new DriverSearchVM()
                    {
                        EmployeeNumber = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Id = x.Id
                    }).ToList()
                };
            }
            return model;
        }

        public async Task<bool> Post(RegistrationVM source) // Note-Cbiroan, 03 Jan 2015: Change this to actually create the user using identity. This is where Async becomes essential.
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Users.Any(x => x.UserName == source.EmployeeNumber)) // Note-Cbiroan, 31 Dec 2014: Checks for duplicates
                {
                    return false; // Note-Cbiroan, 31 Dec 2014: Duplicate, notify controller to return an error
                }
                else
                {
                    var store = new UserStore<ApplicationUser>(db);
                    var manager = new UserManager<ApplicationUser>(store);

                    // Users
                    ApplicationUser User = new ApplicationUser()
                    {
                        UserName = source.EmployeeNumber,
                        FirstName = source.FirstName,
                        LastName = source.LastName,
                        DLExpDate = source.DLExpDate,
                        InsExpDate = source.InsExpDate,
                        Email = source.Email,
                        EmailConfirmed = false,
                        IsDeleted = false
                    };
                    manager.Create(User, source.Password);

                    if (db.Users.Any(x => x.UserName == source.EmployeeNumber)) // DO NOT USE ASYNC CREATEASYNC
                    {
                        manager.AddToRole(User.Id, source.Role);
                    }
                    else
                    {
                        return false;
                    }

                    int check = await db.SaveChangesAsync();

                    if (check > 0)
                    {
                        // Send email
                        return true;  // Note-Cbiroan, 31 Dec 2014: "Successful" save.
                    } // Note-Cbiroan, 04 Jan 2014: Follow up to previous note; this may suffice for the time being.
                    return false;
                }
            }
        }

        //SOFT DELETE
        public bool Delete(string EmployeeNumber)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser reference = db.Users.FirstOrDefault(x => x.UserName == EmployeeNumber);
                reference.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }

        //EDIT
        public RegistrationVM Edit(RegistrationVM source)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser reference = db.Users.FirstOrDefault(x => x.Id == source.Id);
                reference.UserName = source.EmployeeNumber;
                reference.FirstName = source.FirstName;
                reference.LastName = source.LastName;
                reference.DLExpDate = source.DLExpDate;
                reference.InsExpDate = source.InsExpDate;
                reference.Email = source.Email;
                db.SaveChanges();
            }
            return source;
        }

        //GET (single driver)
        public RegistrationVM Get(string ID)
        {
            RegistrationVM model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser reference = db.Users.FirstOrDefault(x => x.Id == ID);
                model = new RegistrationVM()
                {
                    EmployeeNumber = reference.UserName,
                    FirstName = reference.FirstName,
                    LastName = reference.LastName,
                    DLExpDate = reference.DLExpDate,
                    InsExpDate = reference.InsExpDate,
                    Email = reference.Email,
                    Id = reference.Id
                };
            }
            return model;

        }
    }
}














