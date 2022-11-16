using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeClock.Repository.Migrations
{
    public partial class dataSeedTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimeTransactions",
                columns: new[] { "TransactionID", "EmployeeID", "EndTime", "StartTime" },
                values: new object[] { new Guid("2b781937-3e38-4754-aab9-d7c8c526bf2d"), new Guid("b01273d5-4056-4100-b1e4-43b720583c71"), new DateTime(2022, 4, 10, 15, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 10, 8, 29, 52, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TimeTransactions",
                columns: new[] { "TransactionID", "EmployeeID", "EndTime", "StartTime" },
                values: new object[] { new Guid("a2dfd946-74b9-4397-8004-215f434fa9a5"), new Guid("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"), new DateTime(2022, 4, 11, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 11, 7, 15, 2, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TimeTransactions",
                columns: new[] { "TransactionID", "EmployeeID", "EndTime", "StartTime" },
                values: new object[] { new Guid("cc632ef1-9bdb-46f8-b278-c0a00bea9580"), new Guid("b01273d5-4056-4100-b1e4-43b720583c71"), new DateTime(2022, 4, 11, 16, 32, 24, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 11, 7, 30, 2, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TimeTransactions",
                columns: new[] { "TransactionID", "EmployeeID", "EndTime", "StartTime" },
                values: new object[] { new Guid("d259e39e-bef1-44f3-a040-a1b373fb748a"), new Guid("2e773a8e-a50b-4c05-aa8c-4dfdb332d831"), new DateTime(2022, 4, 10, 16, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 10, 7, 30, 42, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeTransactions",
                keyColumn: "TransactionID",
                keyValue: new Guid("2b781937-3e38-4754-aab9-d7c8c526bf2d"));

            migrationBuilder.DeleteData(
                table: "TimeTransactions",
                keyColumn: "TransactionID",
                keyValue: new Guid("a2dfd946-74b9-4397-8004-215f434fa9a5"));

            migrationBuilder.DeleteData(
                table: "TimeTransactions",
                keyColumn: "TransactionID",
                keyValue: new Guid("cc632ef1-9bdb-46f8-b278-c0a00bea9580"));

            migrationBuilder.DeleteData(
                table: "TimeTransactions",
                keyColumn: "TransactionID",
                keyValue: new Guid("d259e39e-bef1-44f3-a040-a1b373fb748a"));
        }
    }
}
