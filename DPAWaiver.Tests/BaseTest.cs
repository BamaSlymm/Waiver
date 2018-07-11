using NUnit.Framework;
using System.Collections.Generic;
using System;
using DPAWaiver.Models;
using DPAWaiver.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;

namespace DPAWaiver.Tests
{
    public class BaseTest
    {
        private const string DatabaseName = "testing";
        public WaiverDBContext context;
        public SqliteConnection connection;

        public Random rnd { get; set; }
        [SetUp]
        public void BaseSetup()
        {
            Console.WriteLine("Starting");

            // In-memory database only exists while the connection is open
            var options = new DbContextOptionsBuilder<WaiverDBContext>()
                .UseInMemoryDatabase(databaseName: DatabaseName)
                .Options;
            context = new WaiverDBContext(options);
            context.Database.EnsureCreated();
            Console.WriteLine("BaseText context created Auto Transactions Enabled {0}", context.Database.AutoTransactionsEnabled);
            rnd = new Random();
        }
        public WaiverDBContext GetAnotherWaiverDBContext()
        {
            var options = new DbContextOptionsBuilder<WaiverDBContext>()
                .UseInMemoryDatabase(databaseName: DatabaseName)
                .Options;
            var anotherContext = new WaiverDBContext(options);
            anotherContext.Database.EnsureCreated();
            return anotherContext;
        }

        [TearDown]
        public void BaseTearDown()
        {
            context.Dispose();
        }

        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }


    }
}