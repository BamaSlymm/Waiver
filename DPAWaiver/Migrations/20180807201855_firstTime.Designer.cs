﻿// <auto-generated />
using System;
using DPAWaiver.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DPAWaiver.Migrations
{
    [DbContext(typeof(DPAWaiverIdentityDbContext))]
    [Migration("20180807201855_firstTime")]
    partial class firstTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DPAWaiver.Areas.Identity.Data.DPARole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("DPAWaiver.Areas.Identity.Data.DPAUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Division")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhoneNumberExtension");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DPAWaiver.Models.BaseLOV", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("LOVType");

                    b.Property<bool>("isDeletable");

                    b.Property<bool>("isDisabled");

                    b.Property<string>("name");

                    b.Property<int>("sortOrder");

                    b.HasKey("ID", "LOVType");

                    b.ToTable("BaseLOVs");

                    b.HasDiscriminator<string>("LOVType").HasValue("BaseLOV");
                });

            modelBuilder.Entity("DPAWaiver.Models.LOV.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDeletable");

                    b.Property<bool>("isDisabled");

                    b.Property<string>("name");

                    b.Property<int>("sortOrder");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DPAWaiver.Models.LOV.MicrofilmOutputType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDeletable");

                    b.Property<bool>("isDisabled");

                    b.Property<string>("name");

                    b.Property<int>("sortOrder");

                    b.HasKey("ID");

                    b.ToTable("MicrofilmOutputTypes");
                });

            modelBuilder.Entity("DPAWaiver.Models.WaiverSelection.Purpose", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDeletable");

                    b.Property<bool>("isDisabled");

                    b.Property<string>("name");

                    b.Property<int>("sortOrder");

                    b.HasKey("ID");

                    b.ToTable("Purposes");
                });

            modelBuilder.Entity("DPAWaiver.Models.WaiverSelection.PurposeSubtype", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDeletable");

                    b.Property<bool>("isDisabled");

                    b.Property<string>("name");

                    b.Property<int?>("purposeTypeID");

                    b.Property<int>("sortOrder");

                    b.HasKey("ID");

                    b.HasIndex("purposeTypeID");

                    b.ToTable("PurposeSubtypes");
                });

            modelBuilder.Entity("DPAWaiver.Models.WaiverSelection.PurposeType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDeletable");

                    b.Property<bool>("isDisabled");

                    b.Property<string>("name");

                    b.Property<int?>("purposeID");

                    b.Property<int>("sortOrder");

                    b.HasKey("ID");

                    b.HasIndex("purposeID");

                    b.ToTable("PurposeTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DPAWaiver.Models.Equipment", b =>
                {
                    b.HasBaseType("DPAWaiver.Models.BaseLOV");


                    b.ToTable("Equipment");

                    b.HasDiscriminator().HasValue("Equipment");
                });

            modelBuilder.Entity("DPAWaiver.Areas.Identity.Data.DPAUser", b =>
                {
                    b.HasOne("DPAWaiver.Models.LOV.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DPAWaiver.Models.WaiverSelection.PurposeSubtype", b =>
                {
                    b.HasOne("DPAWaiver.Models.WaiverSelection.PurposeType", "purposeType")
                        .WithMany("purposeSubtypes")
                        .HasForeignKey("purposeTypeID");
                });

            modelBuilder.Entity("DPAWaiver.Models.WaiverSelection.PurposeType", b =>
                {
                    b.HasOne("DPAWaiver.Models.WaiverSelection.Purpose", "purpose")
                        .WithMany("purposeTypes")
                        .HasForeignKey("purposeID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("DPAWaiver.Areas.Identity.Data.DPARole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DPAWaiver.Areas.Identity.Data.DPAUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DPAWaiver.Areas.Identity.Data.DPAUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("DPAWaiver.Areas.Identity.Data.DPARole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DPAWaiver.Areas.Identity.Data.DPAUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DPAWaiver.Areas.Identity.Data.DPAUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}