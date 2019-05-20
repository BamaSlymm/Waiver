using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.Waivers;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Areas.Identity.Data
{
    public class DPAWaiverIdentityDbContext : IdentityDbContext<DPAUser, DPARole, Guid>
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
            builder.Entity<BaseLOV>().HasDiscriminator<string>("LOVType");
            builder.Entity<BaseLOV>().HasKey(c => new { c.ID, c.LOVType });
            builder.Entity<PurposeType>()
                .HasOne(t => t.purpose)
                .WithMany(c => c.purposeTypes);
            builder.Entity<PurposeSubtype>()
                .HasOne(t => t.purposeType)
                .WithMany(c => c.purposeSubtypes);
            builder.Entity<BaseWaiver>()
            .Property(e => e.Status)
            .HasConversion<string>();
            builder.Entity<BaseWaiver>()
            .HasKey(b => b.ID);
            builder.Entity<BaseWaiver>()
                .HasAlternateKey(b => b.WaiverNumber);
        
        
            builder.Entity<BaseWaiverAction>()
                .Property(e => e.ActionTaken)
                .HasConversion<string>();    
            builder.Entity<BaseWaiverAction>()
                .HasOne(t => t.BaseWaiver)
                .WithMany(c => c.Actions); 

            builder.Entity<BaseWaiverAttachment>()
                .HasOne(t => t.BaseWaiver)
                .WithMany(c => c.Attachments);                            

            builder.Entity<BaseWaiverInvoice>()
                .HasOne(t => t.BaseWaiver)
                .WithMany(c => c.Invoices);
        }

        public DbSet<BaseLOV> BaseLOVs { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<PurposeType> PurposeTypes { get; set; }
        public DbSet<PurposeSubtype> PurposeSubtypes { get; set; }
        public DbSet<MicrofilmOutputType> MicrofilmOutputTypes { get; set; }
        public DbSet<DesignType> DesignType { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BaseWaiver> BaseWaivers { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.BaseWaiver> BaseWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.DataEntryWaiver> DataEntryWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.BaseWaiverAction> BaseWaiverActions { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.BaseWaiverAttachment> BaseWaiverAttachments { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.BaseWaiverInvoice> BaseWaiverInvoice { get; set; }  
        public DbSet<DPAWaiver.Models.Waivers.EquipmentMailWaiver> EquipmentMailWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentPrintWaiver> EquipmentPrintWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentPrintA3Waiver> EquipmentPrintA3Waiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentPrintA4Waiver> EquipmentPrintA4Waiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentPrintLabelWaiver> EquipmentPrintLabelWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentPrintLargeFormatWaiver> EquipmentPrintLargeFormatWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentPrintPressWaiver> EquipmentPrintPressWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.EquipmentScanningWaiver> EquipmentScanningWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.PersonnelRequestWaiver> PersonnelRequestWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.PersonnelContractorWaiver> PersonnelContractorWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.ServiceDesignWaiver> ServiceDesignWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.ServiceMailWaiver> ServiceMailWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.ServiceMicrofilmWaiver> ServiceMicrofilmWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.ServiceMicrofilmConversionWaiver> ServiceMicrofilmConversionWaiver { get; set; } 
        public DbSet<DPAWaiver.Models.Waivers.ServicePrintWaiver> ServicePrintWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.ServiceScanningWaiver> ServiceScanningWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.SoftwareDataEntryWaiver> SoftwareDataEntryWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.SoftwareDesignWaiver> SoftwareDesignWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.SoftwareMailProcessingWaiver> SoftwareMailProcessingWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.SoftwarePrintWaiver> SoftwarePrintWaiver { get; set; }
        public DbSet<DPAWaiver.Models.Waivers.SoftwareScanningWaiver> SoftwareScanningWaiver { get; set; }



       

        
      

        

    }
}
