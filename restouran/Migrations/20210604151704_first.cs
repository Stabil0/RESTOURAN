using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace restouran.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Position_id = table.Column<int>(type: "INT", nullable: false),
                    job_name = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibilities = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Requirements = table.Column<string>(type: "VARCHAR (100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Position_id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Ingredient_code = table.Column<int>(type: "INT", nullable: false),
                    Ingredient_Name = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Volume = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Shelf_life = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Provider = table.Column<string>(type: "VARCHAR (50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Ingredient_code);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_code = table.Column<int>(type: "INT", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Old = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR (20)", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Phone = table.Column<int>(type: "INT", nullable: false),
                    Passport_data = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Position_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_code);
                    table.ForeignKey(
                        name: "FK_Employee_Position_Position_id",
                        column: x => x.Position_id,
                        principalTable: "Position",
                        principalColumn: "Position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Dish_code = table.Column<int>(type: "INT", nullable: false),
                    Dish_name = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Volume_1 = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Volume_2 = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Volume_3 = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Time_for_preparing = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ingredient_code_1 = table.Column<int>(type: "INT", nullable: false),
                    Ingredient_code_2 = table.Column<int>(type: "INT", nullable: false),
                    Ingredient_code_3 = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Dish_code);
                    table.ForeignKey(
                        name: "FK_Menu_Warehouse_Ingredient_code_1",
                        column: x => x.Ingredient_code_1,
                        principalTable: "Warehouse",
                        principalColumn: "Ingredient_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Warehouse_Ingredient_code_2",
                        column: x => x.Ingredient_code_2,
                        principalTable: "Warehouse",
                        principalColumn: "Ingredient_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Warehouse_Ingredient_code_3",
                        column: x => x.Ingredient_code_3,
                        principalTable: "Warehouse",
                        principalColumn: "Ingredient_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Time = table.Column<DateTime>(type: "DateTime", nullable: false),
                    customers_name = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Phone = table.Column<int>(type: "INT", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Check = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Customer_id = table.Column<int>(type: "INT", nullable: false),
                    Dish_code_1 = table.Column<int>(type: "INT", nullable: false),
                    Dish_code_2 = table.Column<int>(type: "INT", nullable: false),
                    Dish_code_3 = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Order_Employee_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "Employee",
                        principalColumn: "Employee_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Dish_code_1",
                        column: x => x.Dish_code_1,
                        principalTable: "Menu",
                        principalColumn: "Dish_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Dish_code_2",
                        column: x => x.Dish_code_2,
                        principalTable: "Menu",
                        principalColumn: "Dish_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Dish_code_3",
                        column: x => x.Dish_code_3,
                        principalTable: "Menu",
                        principalColumn: "Dish_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Position_id",
                table: "Employee",
                column: "Position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Ingredient_code_1",
                table: "Menu",
                column: "Ingredient_code_1");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Ingredient_code_2",
                table: "Menu",
                column: "Ingredient_code_2");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Ingredient_code_3",
                table: "Menu",
                column: "Ingredient_code_3");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_id",
                table: "Order",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Dish_code_1",
                table: "Order",
                column: "Dish_code_1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Dish_code_2",
                table: "Order",
                column: "Dish_code_2");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Dish_code_3",
                table: "Order",
                column: "Dish_code_3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Warehouse");
        }
    }
}
