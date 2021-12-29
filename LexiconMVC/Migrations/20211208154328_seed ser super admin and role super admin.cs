using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVCData.Migrations
{
    public partial class seedsersuperadminandrolesuperadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d9ea164-8644-4eb4-b635-42a0506da0c6", "878709a5-c031-4dbc-92cb-39b6a26e0350", "Super Admin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c612ee6-fbef-4ea4-9d0c-8c3532a8430c", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32c425ce-113e-4afc-8817-8cf547b36d42", "superadmin@mail.com", false, "Super", "Admin", false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEOgsjSvrGcalA87Uk3YS+qIHLXkRdYdcs/zwCG0ijFtlfVv0s3toLyJtBQb4ikL+rw==", null, false, "4e19cca9-e416-4344-b57b-b730c309e29d", false, "superadmin@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "9c612ee6-fbef-4ea4-9d0c-8c3532a8430c", "9d9ea164-8644-4eb4-b635-42a0506da0c6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9c612ee6-fbef-4ea4-9d0c-8c3532a8430c", "9d9ea164-8644-4eb4-b635-42a0506da0c6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d9ea164-8644-4eb4-b635-42a0506da0c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c612ee6-fbef-4ea4-9d0c-8c3532a8430c");
        }
    }
}
