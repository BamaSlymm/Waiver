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

namespace DPAWaiver.Tests
{
    public class BaseTest
    {
        private const string DatabaseName = "testing";
        public DPAWaiverIdentityDbContext context;
        private DbContextOptions<DPAWaiverIdentityDbContext> options = new DbContextOptionsBuilder<DPAWaiverIdentityDbContext>()
                .UseMySql("server=localhost;database=ef;user=test;password=test123456",
                    mysqlOptions =>
                    {
                        mysqlOptions.MaxBatchSize(AppConfig.EfBatchSize);
                        mysqlOptions.CommandTimeout(180);
                    }
                ).Options;

        public Random rnd { get; set; }
        [SetUp]
        public void BaseSetup()
        {
            Console.WriteLine("Starting");

            // In-memory database only exists while the connection is open
            context = new DPAWaiverIdentityDbContext(options);
            context.Database.EnsureCreated();
            Console.WriteLine("BaseText context created Auto Transactions Enabled {0}", context.Database.AutoTransactionsEnabled);
            rnd = new Random();
            var dbInit = new DbInitializer(context, new LOVPopulator());
            dbInit.Initialize();
        }
        public DPAWaiverIdentityDbContext GetAnotherDPAWaiverIdentityDbContext()
        {
            
            var anotherContext = new DPAWaiverIdentityDbContext(options);
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