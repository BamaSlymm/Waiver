using NUnit.Framework;
using System.Collections.Generic;
using System;
using DPAWaiver.Models;
using DPAWaiver.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.Waivers;
using DPAWaiver.Areas.Identity.Data;

namespace DPAWaiver.Tests
{
    public class BaseWaiverTest : BaseTest
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testInsertingBaseWaivers()
        {
            var _service = new LOVService(context);
            var _purpose = _service.getPurposes().Single(x=>x.ID == Purposes.Personnel);
            var _purposeType = _service.getPersonnelServiceTypes().Single(x=>x.ID == PersonnelServiceTypes.StateEmployee);
            
            var _user = UserTest.SubmitterUserForSelf();
            context.Users.Add(_user);
            context.BaseWaivers.RemoveRange(context.BaseWaivers);
            context.SaveChanges();
            var _list = new List<BaseWaiver> {
                new BaseWaiver(_user,null, null, _purpose, _purposeType, null)
            };
        
            _list.ForEach(element => context.BaseWaivers.Add(element));
            context.SaveChanges();
            var originalCount = context.BaseWaivers.ToList().Count();
            Console.WriteLine("Original Count {0}", originalCount);Console.WriteLine("Original Count {0}", originalCount);
            using (var anotherContext = GetAnotherDPAWaiverIdentityDbContext())
            {
                var aCount = anotherContext.BaseWaivers.ToList().Count();
                Assert.AreEqual(1, aCount, "Expected count of {0} does not match actual count {1}", 1, aCount);
            }
        }


        [Test]


        [TearDown]
        public void TearDown()
        {
        }
    }
}