using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Add_Data_In_Column_Duckbill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Duckbill",
                columns: new[] { "ID", "DateOfBirth", "Name" },
                values: new object[] { new Guid("c9f777a1-6166-471a-87db-2ef29ed1cd5a"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duckbill1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Duckbill",
                keyColumn: "ID",
                keyValue: new Guid("c9f777a1-6166-471a-87db-2ef29ed1cd5a"));
        }
    }
}
