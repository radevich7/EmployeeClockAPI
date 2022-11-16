using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeClock.Repository.Migrations
{
    public partial class dataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("20c031bd-6b6d-4880-8532-4524922d5a47"), "4033071111", new DateTime(1990, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "scott@gmail.com", "Kira", "4031112997", "Scott", "Phoel", "Edmonton" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"), "4033071111", new DateTime(1990, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vika@gmail.com", "Kira", "4031112997", "Vika", "Pigan", "Brandon" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b01273d5-4056-4100-b1e4-43b720583c71"), "4033071111", new DateTime(1993, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lana@gmail.com", "Kira", "4031112997", "Roksolana", "Bondziak", "Stryi" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b6fad037-0750-4c38-b615-56e8951840dc"), "4033071111", new DateTime(1990, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "teddyw@gmail.com", "Kira", "4031112997", "Teddy", "Karchenko", "Red Deer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb23f9b23"), "4033071277", new DateTime(1980, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vladislav@gmail.com", "Vika", "4033012997", "Vladislav", "Bordick", "Shevcheko Str" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "4033077577", new DateTime(1993, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "test@gmail.com", "Bob", "4033077997", "Berry", "Griffin Beak Eldritch", "Legacy Gate SE" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("d28888e9-2cd1-473a-a23f-e38cb23f9b23"), "4033071111", new DateTime(1990, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "andrew@gmail.com", "Kira", "4031112997", "Anrew", "Borisuk", "Bow River" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "DateOfHire", "DateOfQuit", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("f80a777c-5f7b-4da3-954e-814a7ea171e5"), "4033071111", new DateTime(1990, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lana@gmail.com", "Kira", "4031112997", "Lana", "Radevych", "Stryi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("20c031bd-6b6d-4880-8532-4524922d5a47"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("b01273d5-4056-4100-b1e4-43b720583c71"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("b6fad037-0750-4c38-b615-56e8951840dc"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb23f9b23"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("d28888e9-2cd1-473a-a23f-e38cb23f9b23"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: new Guid("f80a777c-5f7b-4da3-954e-814a7ea171e5"));
        }
    }
}
