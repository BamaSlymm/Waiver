using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Areas.Identity.Data
{
    public class DPAWaiverIdentityDbContext : IdentityDbContext<DPAUser>
    {

        public DPAWaiverIdentityDbContext(DbContextOptions<DPAWaiverIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<BaseLOV> BaseLOVs { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<PurposeType> PurposeTypes { get; set; }
        public DbSet<PurposeSubtype> PurposeSubtypes { get; set; }
        public DbSet<MicrofilmOutputType> MicrofilmOutputTypes { get; set; }

    }
}
