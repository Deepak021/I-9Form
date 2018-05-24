using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace I_9Form.Data.Migrations
{
    public partial class addApplicationUserToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userstage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userstage",
                table: "AspNetUsers");
        }
    }
}
