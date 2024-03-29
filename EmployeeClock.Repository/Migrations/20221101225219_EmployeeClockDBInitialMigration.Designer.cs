﻿// <auto-generated />
using System;
using EmployeeClock.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeClock.Repository.Migrations
{
    [DbContext(typeof(EmployeeClockContext))]
    [Migration("20221101225219_EmployeeClockDBInitialMigration")]
    partial class EmployeeClockDBInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("EmployeeClock.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfHire")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfQuit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyContactName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyContactPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeClock.Entities.TimeTransaction", b =>
                {
                    b.Property<Guid>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("TimeTransactions");
                });

            modelBuilder.Entity("EmployeeClock.Entities.TimeTransaction", b =>
                {
                    b.HasOne("EmployeeClock.Entities.Employee", "Employee")
                        .WithMany("TimeTransactions")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeClock.Entities.Employee", b =>
                {
                    b.Navigation("TimeTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
