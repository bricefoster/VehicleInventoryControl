using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
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
            DriverSearchCascadeVM model = new DriverSearchCascadeVM();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.DriverSearchCascade = db.Users.Select(x => new DriverSearchVM()
                {
                    EmployeeNumber = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();
            }
            return model;
        }

        public bool Post(RegistrationVM source)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Users.Any(x => x.UserName == source.EmployeeNumber)) // Note-Cbiroan, 31 Dec 2014: Checks for duplicates
                {
                    return false; // Note-Cbiroan, 31 Dec 2014: Duplicate, notify controller to return an error
                }
                else
                {
                    db.Users.Add(new ApplicationUser()
                    {
                        UserName = source.EmployeeNumber,
                        FirstName = source.FirstName,
                        LastName = source.LastName,
                        DLExpDate = source.DLExpDate,
                        InsExpDate = source.InsExpDate,
                        Email = source.Email
                    });
                    db.SaveChanges();
                    return true; // Note-Cbiroan, 31 Dec 2014: "Successful" save. In order to truly validate, we would need to build a try-catch block
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
        public RegistrationVM Edit(RegistrationVM source, string EmployeeNumber)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser reference = db.Users.FirstOrDefault(x => x.UserName == EmployeeNumber);
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
        public RegistrationVM Get(string EmployeeNumber)
        {
            RegistrationVM model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser reference = db.Users.FirstOrDefault(x => x.UserName == EmployeeNumber);
                model = new RegistrationVM()
                {
                    EmployeeNumber = reference.UserName,
                    FirstName = reference.FirstName,
                    LastName = reference.LastName,
                    DLExpDate = reference.DLExpDate,
                    InsExpDate = reference.InsExpDate,
                    Email = reference.Email
                };
            }
            return model;

        }
    }
}














