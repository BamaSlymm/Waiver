using NUnit.Framework;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using DPAWaiver.Data;
using DPAWaiver.Areas.Identity.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DPAWaiver.Models;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Tests
{
    public static class UserTest
    {
        public static DPAUser SubmitterUserForSelf() {
            var _populator = new LOVPopulator();
            DPAUser _user = new DPAUser();
            _user.FirstName = "Submitter";
            _user.LastName = "ForSelf";
            _user.PhoneNumber = "303-444-3023";
            _user.Department = _populator.getDepartments().Single(x=>x.ID == Departments.OIT);
            _user.Division = "Some Division";
            return _user;
        }

    }
}