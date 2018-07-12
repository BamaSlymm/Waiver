using DPAWaiver.Models;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Data
{
    public class WaiverDBContext : DbContext
    {
        public WaiverDBContext(DbContextOptions<WaiverDBContext> options) : base(options)
        {
        }

        public DbSet<BaseLOV> BaseLOVs { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<PurposeType> PurposeTypes { get; set; }
        public DbSet<PurposeSubtype> PurposeSubtypes { get; set; }
        public DbSet<MicrofilmOutputType> MicrofilmOutputTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /** BaseLOV is not currently used due to EF Core only supports tph (table per hierarchy) */
            /** It leads to a very convoluted table structure for LOV */
            modelBuilder.Entity<BaseLOV>().HasDiscriminator<string>("LOVType");
            modelBuilder.Entity<BaseLOV>().HasKey(c=>new {c.ID, c.LOVType});
            modelBuilder.Entity<PurposeType>()
                .HasOne(t=>t.purpose)
                .WithMany(c=>c.purposeTypes);
            modelBuilder.Entity<PurposeSubtype>()
                .HasOne(t=>t.purposeType)
                .WithMany(c=>c.purposeSubtypes);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging();
        }     

    }
}