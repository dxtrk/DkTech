using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DKTech.Migrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "
                ", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "f4e6ff19-cafa-4711-8324-e4177d3de7d5", "admin123@gmail.com", true, false, null, "ADMIN123@GMAIL.COM", "ADMIN123@GMAIL.COM", "AQAAAAIAAYagAAAAEEC/U+LIGGRd+D3N2ChGcQqXVjUTVuA7FGLNHfM/YwoI4FFGu8PSZlbtGiZEt/Pj5A==", null, false, "b5ff7112-1a66-468e-a31a-a976b08b2686", false, "admin123@gmail.com" },
                    { "2", 0, "5fda5ad5-2958-47ca-bd94-f3cb858316e5", "employee123@gmail.com", true, false, null, "EMPLOYEE123@GMAIL.COM", "EMPLOYEE123@GMAIL.COM", "AQAAAAIAAYagAAAAEEGoQDnLMsgBLM/LoeDpYKGLHYd+vDbTY10871dfc0I68qi3F+a+C/MUbDyFsWtPtw==", null, false, "36556e13-8687-407e-bca9-4ce58658d323", false, "employee123@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
