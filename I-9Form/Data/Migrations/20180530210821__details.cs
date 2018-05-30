using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace I_9Form.Data.Migrations
{
    public partial class _details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeOtherDetailsViewModels",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ALienRegNumber = table.Column<string>(nullable: false),
                    AlienAuthToWork = table.Column<bool>(nullable: false),
                    CitizenOfUS = table.Column<bool>(nullable: false),
                    CountryOfIssue = table.Column<string>(nullable: true),
                    ExpDate = table.Column<string>(nullable: true),
                    ForeignPassPortNumber = table.Column<string>(nullable: true),
                    I94AdmissionNum = table.Column<string>(nullable: true),
                    LawfulParmanentResidence = table.Column<bool>(nullable: false),
                    NonCitizenUS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOtherDetailsViewModels", x => x.EmployeeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOtherDetailsViewModels");
        }
    }
}
