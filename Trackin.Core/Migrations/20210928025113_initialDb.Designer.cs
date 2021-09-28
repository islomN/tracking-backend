﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracking.Core;

namespace Tracking.Core.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20210928025113_initialDb")]
    partial class initialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tracking.Core.Tables.OperationSystem", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.ToTable("operation_systems");
                });

            modelBuilder.Entity("Tracking.Core.Tables.Tracking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientCountry")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("client_country");

                    b.Property<string>("ClientId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("client_id");

                    b.Property<string>("ClientIp")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("client_ip");

                    b.Property<string>("Domain")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("domain");

                    b.Property<byte>("OperationSystemId")
                        .HasColumnType("tinyint")
                        .HasColumnName("operation_system_id");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("request_date");

                    b.Property<string>("SiteCountry")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("site_country");

                    b.Property<string>("SiteIp")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("site_ip");

                    b.HasKey("Id");

                    b.HasIndex("ClientCountry");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[client_id] IS NOT NULL");

                    b.HasIndex("OperationSystemId");

                    b.HasIndex("RequestDate");

                    b.HasIndex("SiteCountry");

                    b.ToTable("tracking");
                });

            modelBuilder.Entity("Tracking.Core.Tables.Tracking", b =>
                {
                    b.HasOne("Tracking.Core.Tables.OperationSystem", "OperationSystem")
                        .WithMany()
                        .HasForeignKey("OperationSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationSystem");
                });
#pragma warning restore 612, 618
        }
    }
}
