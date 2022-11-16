using EmployeeClock.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.DBContext
{
    public class EmployeeClockContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<TimeTransaction> TimeTransactions { get; set; } = null!;


        public EmployeeClockContext(DbContextOptions<EmployeeClockContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                 new Employee("Berry", "Griffin Beak Eldritch", "Legacy Gate SE", "4033077577", "test@gmail.com")
                 {
                     EmployeeID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                     DateOfBirth = new DateTime(1993, 7, 23),
                     DateOfHire = new DateTime(2022, 1, 24),
                     EmergencyContactName = "Bob",
                     EmergencyContactPhone = "4033077997",

                 },
                 new Employee("Vladislav", "Bordick", "Shevcheko Str", "4033071277", "vladislav@gmail.com")
                 {
                     EmployeeID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb23f9b23"),
                     DateOfBirth = new DateTime(1980, 12, 23),
                     DateOfHire = new DateTime(2021, 1, 1),
                     EmergencyContactName = "Vika",
                     EmergencyContactPhone = "4033012997",

                 },
                  new Employee("Anrew", "Borisuk", "Bow River", "4033071111", "andrew@gmail.com")
                  {
                      EmployeeID = Guid.Parse("d28888e9-2cd1-473a-a23f-e38cb23f9b23"),
                      DateOfBirth = new DateTime(1990, 3, 23),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  },
                  new Employee("Teddy", "Karchenko", "Red Deer", "4033071111", "teddyw@gmail.com")
                  {
                      EmployeeID = Guid.Parse("b6fad037-0750-4c38-b615-56e8951840dc"),
                      DateOfBirth = new DateTime(1990, 3, 23),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  },
                  new Employee("Scott", "Phoel", "Edmonton", "4033071111", "scott@gmail.com")
                  {
                      EmployeeID = Guid.Parse("20c031bd-6b6d-4880-8532-4524922d5a47"),
                      DateOfBirth = new DateTime(1990, 3, 23),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  },
                  new Employee("Vika", "Pigan", "Brandon", "4033071111", "vika@gmail.com")
                  {
                      EmployeeID = Guid.Parse("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"),
                      DateOfBirth = new DateTime(1990, 3, 23),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  },
                  new Employee("Lana", "Radevych", "Stryi", "4033071111", "lana@gmail.com")
                  {
                      EmployeeID = Guid.Parse("f80a777c-5f7b-4da3-954e-814a7ea171e5"),
                      DateOfBirth = new DateTime(1990, 3, 23),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  },
                  new Employee("Roksolana", "Bondziak", "Stryi", "4033071111", "lana@gmail.com")
                  {
                      EmployeeID = Guid.Parse("b01273d5-4056-4100-b1e4-43b720583c71"),
                      DateOfBirth = new DateTime(1993, 8, 24),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  });
            modelBuilder.Entity<TimeTransaction>().HasData(
            new TimeTransaction()
            {
                TransactionID = Guid.Parse("2b781937-3e38-4754-aab9-d7c8c526bf2d"),
                StartTime = new DateTime(2022, 4, 10, 08, 29, 52),
                EndTime = new DateTime(2022, 4, 10, 15, 30, 52),
                EmployeeID = Guid.Parse("b01273d5-4056-4100-b1e4-43b720583c71"),
            },
            new TimeTransaction()
            {
                TransactionID = Guid.Parse("cc632ef1-9bdb-46f8-b278-c0a00bea9580"),
                StartTime = new DateTime(2022, 04, 11, 07, 30, 02),
                EndTime = new DateTime(2022, 04, 11, 16, 32, 24),
                EmployeeID = Guid.Parse("b01273d5-4056-4100-b1e4-43b720583c71"),
            },
            new TimeTransaction()
            {
                TransactionID = Guid.Parse("d259e39e-bef1-44f3-a040-a1b373fb748a"),
                StartTime = new DateTime(2022, 4, 10, 07, 30, 42),
                EndTime = new DateTime(2022, 4, 10, 16, 30, 52),
                EmployeeID = Guid.Parse("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"),
            },
            new TimeTransaction()
            {
                TransactionID = Guid.Parse("a2dfd946-74b9-4397-8004-215f434fa9a5"),
                StartTime = new DateTime(2022, 04, 11, 07, 15, 02),
                EndTime = new DateTime(2022, 04, 11, 16, 30, 00),
                EmployeeID = Guid.Parse("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"),
            });
        }



        //protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionString");
        //    base.OnConfiguring (optionsBuilder);
        //}
    }
}
