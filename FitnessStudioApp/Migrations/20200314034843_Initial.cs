using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessStudioApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerPhone = table.Column<string>(nullable: false),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    ClassTitle = table.Column<int>(nullable: false),
                    TypeOfClassPass = table.Column<int>(nullable: false),
                    TypeOfMembership = table.Column<int>(nullable: false),
                    MembershipExpires = table.Column<DateTime>(nullable: false),
                    CustomerSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "FitnessClasses",
                columns: table => new
                {
                    ClassTitle = table.Column<int>(nullable: false),
                    ClassDescription = table.Column<string>(nullable: true),
                    MinimumAge = table.Column<int>(nullable: false),
                    DaysClassOffered = table.Column<int>(nullable: false),
                    ClassTimings = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    Instructor = table.Column<string>(nullable: true),
                    ClassSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTitle", x => x.ClassTitle);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_CustomerAccounts_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CustomerAccounts",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerID",
                table: "Transactions",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessClasses");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");
        }
    }
}
