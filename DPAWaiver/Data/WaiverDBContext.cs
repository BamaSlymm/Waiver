using DPAWaiver.Models;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Data
{
    public class WaiverDBContext : DbContext
    {
        public WaiverDBContext(DbContextOptions<WaiverDBContext> options) : base(options)
        {
        }

        public DbSet<BaseLOV> BaseLOVs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseLOV>().ToTable("BaseLOV");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<SingleFunctionPrinterPreferences>().ToTable("SingleFunctionPrinterPreferences");
        }

    }
}