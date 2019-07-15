using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class CoreDatabaseApiDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Cvv = table.Column<string>(nullable: true),
                    ExpiryMonth = table.Column<int>(nullable: false),
                    ExpiryYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    MerchantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRequest_Card_CardNumber",
                        column: x => x.CardNumber,
                        principalTable: "Card",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentResponse",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    PaymentRequestId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentResponse_Card_CardNumber",
                        column: x => x.CardNumber,
                        principalTable: "Card",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequest_CardNumber",
                table: "PaymentRequest",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentResponse_CardNumber",
                table: "PaymentResponse",
                column: "CardNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRequest");

            migrationBuilder.DropTable(
                name: "PaymentResponse");

            migrationBuilder.DropTable(
                name: "Card");
        }
    }
}
