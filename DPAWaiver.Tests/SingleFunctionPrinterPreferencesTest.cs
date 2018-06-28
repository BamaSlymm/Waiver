using NUnit.Framework;
using DPAWaiver.Models;
using System.Collections.Generic;
using System;

namespace DPAWaiver.Tests.Models
{
    public class SingleFunctionPrinterPreferencesTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testSortOrder()
        {
            var printerList = new List<SingleFunctionPrinterPreferences>();
            var m402dn =
                new SingleFunctionPrinterPreferences(1, "M402dn", 1, true,  false, 229.0m, 206.99m, 4500);
            var m608dn =
                new SingleFunctionPrinterPreferences(1, "M608dn", 2, true, false,  867.0m, 292.99m, 12500);
            var m506dn =
                new SingleFunctionPrinterPreferences(1, "M506dn", 3, true, false, 574.0m, 305.99m, 9000);
            var m609dn =
                new SingleFunctionPrinterPreferences(1, "M609dn", 4, true, false, 1316.0m, 292.99m, 12500);
            var officeJet200 =
                new SingleFunctionPrinterPreferences(1, "OfficeJet 200", 5, true, false, 232.0m, 37.99m, 300);
            var m553dn =
                new SingleFunctionPrinterPreferences(1, "M553dn", 6, true, false, 610.0m, 221.99m, 6250) ;
            m553dn.cyanTonerCost = 306.99m;
            m553dn.pageYieldForCyanToner = 0; 
            m553dn.magentaTonerCost = 306.99m ;  
            m553dn.pageYieldForMagentaToner = 4750;
            m553dn.yellowTonerCost = 306.99m ;
            m553dn.pageYieldForYellowToner = 4750;

            printerList.Add(m402dn);
            printerList.Add(m608dn);
            printerList.Add(m506dn);
            printerList.Add(m609dn);
            printerList.Add(officeJet200);
            printerList.Add(m553dn);
            Assert.AreEqual(printerList[0], m402dn);
            printerList.Sort();
            Assert.AreEqual(printerList[0], m402dn);
        }
    }
}