using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IcBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2250a09b-45d4-4cea-a11a-faaefc1d142a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a7e3b29-f993-4576-9ae1-7385d5b845d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b262607-39f2-49a4-bf39-02bc98afd74c", null, "user", "user" },
                    { "3b355e54-9555-4e63-aa06-a6847faa2233", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b262607-39f2-49a4-bf39-02bc98afd74c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b355e54-9555-4e63-aa06-a6847faa2233");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2250a09b-45d4-4cea-a11a-faaefc1d142a", null, "user", null },
                    { "5a7e3b29-f993-4576-9ae1-7385d5b845d2", null, "admin", "user" }
                });
        }
    }
}
