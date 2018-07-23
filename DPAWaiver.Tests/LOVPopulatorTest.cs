using NUnit.Framework;
using System.Collections.Generic;
using System;
using DPAWaiver.Models;
using DPAWaiver.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Tests
{
    public class LOVPopulatorTest : BaseTest
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testInsertingPurpose()
        {
            var purposes = new List<Purpose> {
                new Purpose(1,name: "Service",sortOrder:1,isDeletable:false,isDisabled:false),
                new Purpose(2,name: "Personnel Request",sortOrder:2,isDeletable:false,isDisabled:false),
                new Purpose(3,name: "Equipment",sortOrder:3,isDeletable:false,isDisabled:false),
                new Purpose(4,name: "Software Related To Services",sortOrder:4,isDeletable:false,isDisabled:false),
            };
            context.Purposes.RemoveRange(context.Purposes);
            context.SaveChanges();
            purposes.ForEach(purpose => context.Purposes.Add(purpose));
            context.SaveChanges();
            var originalCount = context.Purposes.ToList().Count();
            Console.WriteLine("Original Count {0}", originalCount);
            using (var anotherContext = GetAnotherDPAWaiverIdentityDbContext())
            {
                var aCount = anotherContext.Purposes.ToList().Count();
                Assert.AreEqual(4, aCount, "Expected count of {0} does not match actual count {1}", 4, aCount);
            }

        }


        [Test]


        [TearDown]
        public void TearDown()
        {
        }
    }
}