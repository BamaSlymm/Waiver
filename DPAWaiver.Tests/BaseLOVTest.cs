using NUnit.Framework;
using DPAWaiver.Models ;
using System.Collections.Generic;
using System;

namespace DPAWaiver.Tests.Models
{
    public class BaseLOVTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testSortOrder()
        {
            List<BaseLOV> printerList = new List<BaseLOV>();
            BaseLOV m402dn = new BaseLOV(1, "M402dn", 2, true, false);
            BaseLOV m608dn = new BaseLOV(1, "M608dn", 1, true, false);
            printerList.Add(m402dn);
            printerList.Add(m608dn);
            Assert.AreEqual(printerList[0], m402dn);
            printerList.Sort();
            TestContext.Out.WriteLine("Message to write to log");
            foreach (var printer in printerList) {
                Console.WriteLine(printer);
            }
            Assert.AreEqual(printerList[0], m608dn);
        }
        
        [Test]
        public void testSortName()
        {
            List<BaseLOV> printerList = new List<BaseLOV>();
            BaseLOV m402dn = new BaseLOV(1, "M402dn", 2, true, false);
            BaseLOV m608dn = new BaseLOV(1, "M608dn", 1, true, false);
            printerList.Add(m402dn);
            printerList.Add(m608dn);
            Assert.AreEqual(printerList[0], m402dn);
            printerList.Sort(BaseLOV.sortBasedOnName());
            foreach (var printer in printerList) {
                Console.WriteLine(printer);
            }
            Assert.AreEqual(printerList[0], m402dn);
        }
    }
}