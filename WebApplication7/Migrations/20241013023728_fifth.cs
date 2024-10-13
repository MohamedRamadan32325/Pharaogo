using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Place_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place_Price = table.Column<int>(type: "int", nullable: false),
                    Place_Rating = table.Column<int>(type: "int", nullable: false),
                    Place_Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Place_Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Place_ID = table.Column<int>(type: "int", nullable: false),
                    promotion_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_state = table.Column<bool>(type: "bit", nullable: true),
                    total_amount = table.Column<int>(type: "int", nullable: false),
                    total_Dayes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.booking_Id);
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Booking_Places_Place_ID",
                        column: x => x.Place_ID,
                        principalTable: "Places",
                        principalColumn: "Place_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Place_Id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Places_Place_Id",
                        column: x => x.Place_Id,
                        principalTable: "Places",
                        principalColumn: "Place_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Id = table.Column<int>(type: "int", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment_Status = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_Payment_Booking_Booking_Id",
                        column: x => x.Booking_Id,
                        principalTable: "Booking",
                        principalColumn: "booking_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    promotion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    promotion_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount_Amount = table.Column<int>(type: "int", nullable: false),
                    booking_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.promotion_Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Booking_booking_ID",
                        column: x => x.booking_ID,
                        principalTable: "Booking",
                        principalColumn: "booking_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Membership_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    promotion_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Membership_Id);
                    table.ForeignKey(
                        name: "FK_Memberships_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Promotions_promotion_ID",
                        column: x => x.promotion_ID,
                        principalTable: "Promotions",
                        principalColumn: "promotion_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Place_ID",
                table: "Booking",
                column: "Place_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_User_ID",
                table: "Booking",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_promotion_ID",
                table: "Memberships",
                column: "promotion_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_User_ID",
                table: "Memberships",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Booking_Id",
                table: "Payment",
                column: "Booking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_booking_ID",
                table: "Promotions",
                column: "booking_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Place_Id",
                table: "Review",
                column: "Place_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_User_ID",
                table: "Review",
                column: "User_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
