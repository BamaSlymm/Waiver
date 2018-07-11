using NUnit.Framework;
using System.Collections.Generic;
using System;
using DPAWaiver.Models;
using DPAWaiver.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Tests
{
    public class DBInitializeHelperTest : BaseTest
    {

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("BaseText context created Auto Transactions Enabled {0}", context.Database.AutoTransactionsEnabled);
        }

        [Test]
        public void testEF()
        {
            var purposes = new List<Purpose> {
                new Purpose(1,name: "Service",sortOrder:1,isDeletable:false,isDisabled:false),
                new Purpose(2,name: "Personnel Request",sortOrder:2,isDeletable:false,isDisabled:false),
                new Purpose(3,name: "Equipment",sortOrder:3,isDeletable:false,isDisabled:false),
                new Purpose(4,name: "Software Related To Services",sortOrder:4,isDeletable:false,isDisabled:false),
            };

            context.RemoveRange(context.Purposes);
            context.SaveChanges();
            purposes.ForEach(x => context.Purposes.Add(x));
            context.SaveChanges();

            var aList = context.Purposes.Where(x => x.ID == 1).ToList();
            aList.ForEach(x => x.name = "xyz");
            context.Purposes.Add(new Purpose(5, name: "Junk", sortOrder: 4, isDeletable: false, isDisabled: false));
            context.SaveChanges();

            using (var anotherContext = GetAnotherWaiverDBContext())
            {
                var savedPurposes = anotherContext.Purposes;
                Assert.AreEqual(5, savedPurposes.Count(),
                    "Expected {0} does not match actual count {1}", 5, savedPurposes.Count());
                Assert.AreEqual("xyz", savedPurposes.Single(x => x.ID == 1).name,
                    "Expected {0} does not match actual count {1}", "xyz",
                    savedPurposes.Single(x => x.ID == 1).name);
                anotherContext.SaveChanges();
            }

        }

        public void testMergingPurpose()
        {

            var purposes = new List<Purpose> {
                new Purpose(1,name: "Service",sortOrder:1,isDeletable:false,isDisabled:false),
                new Purpose(2,name: "Personnel Request",sortOrder:2,isDeletable:false,isDisabled:false),
                new Purpose(3,name: "Equipment",sortOrder:3,isDeletable:false,isDisabled:false),
                new Purpose(4,name: "Software Related To Services",sortOrder:4,isDeletable:false,isDisabled:false),
            };
            context.RemoveRange(context.Purposes);
            context.SaveChanges();
            purposes.ForEach(x => context.Purposes.Add(x));
            context.SaveChanges();

            var randomString = "Service" + rnd.Next(1, 1200);
            using (var anotherContext = GetAnotherWaiverDBContext())
            {
                var savedPurposes = anotherContext.Purposes;
                Assert.AreEqual(4, savedPurposes.Count(),
                    "Expected {0} does not match actual count {1}", 4, savedPurposes.Count());
                purposes.Find(x => x.ID == 1).name = randomString;
                DBInitializeHelper.MergePurposes(savedPurposes, purposes);
                Assert.AreEqual(randomString, savedPurposes.Single(x => x.ID == 1).name,
                    "Expected {0} does not match actual count {1}", randomString, savedPurposes.Single(x => x.ID == 1).name);
                anotherContext.SaveChanges();
            }

            using (var anotherContext = GetAnotherWaiverDBContext())
            {
                var savedPurposes = anotherContext.Purposes.ToList();
                Assert.AreEqual(randomString, savedPurposes.Single(x => x.ID == 1).name,
                    "Expected {0} does not match actual count {1}", randomString, savedPurposes.Single(x => x.ID == 1).name);
            }
        }

        [Test]
        public void testPurposeTypesUpdating()
        {
            var mock = new Mock<ILOVPopulator>();
            var serviceTypes = new List<PurposeType> {
                new PurposeType(1,name: "Data Entry",sortOrder:1,isDeletable:false,isDisabled:false),
            };
            context.Purposes.RemoveRange(context.Purposes);
            context.PurposeTypes.RemoveRange(context.PurposeTypes);
            context.SaveChanges();
            context.Purposes.Add(new Purpose(1, name: "Service", sortOrder: 1, isDeletable: false, isDisabled: false));
            context.SaveChanges();
            mock.Setup(x => x.getServiceTypes()).Returns(serviceTypes);
            DbInitializer dbinit = new DbInitializer(context, mock.Object);
            var allPurposeTypes = context.PurposeTypes.ToList();
            dbinit.SaveServiceTypes();
            using (var anotherContext = GetAnotherWaiverDBContext())
            {
                var afterServiceTypes = anotherContext.PurposeTypes.Where(x => x.purpose.ID == 1);
                Assert.AreEqual(serviceTypes.Count, afterServiceTypes.Count(),
                                "Expected {0} count of service types does not match the database count {1}",
                                serviceTypes.Count, afterServiceTypes.Count());
            }
            var updatedTypes = new List<PurposeType> {
                new PurposeType(1,name: "Data W Entry",sortOrder:1,isDeletable:false,isDisabled:false),
            };
            mock.Setup(x => x.getServiceTypes()).Returns(updatedTypes);
            dbinit.SaveServiceTypes();
            using (var anotherContext = GetAnotherWaiverDBContext())
            {
                var afterServiceTypes = anotherContext.PurposeTypes.Where(x => x.purpose.ID == 1);
                Assert.AreEqual(serviceTypes.Count, afterServiceTypes.Count(),
                                "Expected {0} count of service types does not match the database count {1}",
                                serviceTypes.Count, afterServiceTypes.Count());
                Assert.AreEqual("Data W Entry", afterServiceTypes.ToList()[0].name,
                                "Expected name {0} does not match the database name {1}",
                                "Data W Entry", afterServiceTypes.ToList()[0].name);

            }


        }


        [TearDown]
        public void TearDown()
        {
        }
    }
}