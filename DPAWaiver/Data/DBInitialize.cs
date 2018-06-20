using DPAWaiver.Models;
using System;
using System.Linq;

namespace DPAWaiver.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WaiverDBContext context)
        {
            context.Database.EnsureCreated();
            
            Console.WriteLine("DB Created: ");

            if (context.BaseLOVs.Any())
            {
                return;   // DB has been seeded
            }
            var baseLOVs = new BaseLOV[]
            {
                new BaseLOV(1,"test",1, false, false),
                new BaseLOV(2,"test2",1, false, false),
            };
            foreach (BaseLOV s in baseLOVs)
            {
                context.BaseLOVs.Add(s);
            }
            context.SaveChanges();
        }
    }
}