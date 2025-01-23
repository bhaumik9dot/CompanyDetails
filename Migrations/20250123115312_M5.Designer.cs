﻿// <auto-generated />
using System;
using CompanyDetails.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyDetails.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250123115312_M5")]
    partial class M5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CompanyDetails.Models.CompanyInformation", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("AccountsCreatorURL")
                        .HasColumnType("text");

                    b.Property<string>("AcquisitionDate")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("AndroidBuild")
                        .HasColumnType("text");

                    b.Property<string>("ApiBaseUrl")
                        .HasColumnType("text");

                    b.Property<string>("Canceled")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("DemoAccountNodeId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("text");

                    b.Property<string>("ForceUpgrade")
                        .HasColumnType("text");

                    b.Property<string>("HelpPageUrl")
                        .HasColumnType("text");

                    b.Property<string>("IpAddressV4")
                        .HasColumnType("text");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("text");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("text");

                    b.Property<string>("MacAddress")
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddress")
                        .HasColumnType("text");

                    b.Property<string>("PlatformFeatures")
                        .HasColumnType("text");

                    b.Property<string>("PrivacyPolicyUrl")
                        .HasColumnType("text");

                    b.Property<string>("Suspended")
                        .HasColumnType("text");

                    b.Property<string>("TermsOfServiceUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("text");

                    b.Property<string>("WhatsNew")
                        .HasColumnType("text");

                    b.Property<string>("XUrl")
                        .HasColumnType("text");

                    b.Property<string>("YouTubeUrl")
                        .HasColumnType("text");

                    b.Property<string>("iOSBuild")
                        .HasColumnType("text");

                    b.HasKey("CompanyId");

                    b.ToTable("CompanyInformation");
                });

            modelBuilder.Entity("CompanyDetails.Models.RoleMaster", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("RoleMaster");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            CreatedDate = new DateTime(2025, 1, 23, 11, 53, 12, 440, DateTimeKind.Utc).AddTicks(2100),
                            Description = "Administrator with full access",
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            CreatedDate = new DateTime(2025, 1, 23, 11, 53, 12, 440, DateTimeKind.Utc).AddTicks(2149),
                            Description = "Client with limited access",
                            RoleName = "Client"
                        });
                });

            modelBuilder.Entity("CompanyDetails.Models.UserMaster", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Otp")
                        .HasColumnType("integer");

                    b.Property<bool>("OtpDisable")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("OtpExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("UserMaster");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2025, 1, 23, 11, 53, 12, 440, DateTimeKind.Utc).AddTicks(2023),
                            Email = "abcadmin@yopmail.com",
                            FirstName = "ABC",
                            IsActive = true,
                            IsDelete = false,
                            LastName = "Technology",
                            Otp = 0,
                            OtpDisable = false,
                            Password = "R/fmAZyZOsgvjGYMEwqWHQ==",
                            PhoneNo = "1234567890",
                            RoleId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
