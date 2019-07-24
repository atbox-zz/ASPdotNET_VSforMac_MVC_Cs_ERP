using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Migrations
{
    public partial class ErpFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Delivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Contact_person = table.Column<string>(maxLength: 100, nullable: false),
                    Telphone = table.Column<string>(maxLength: 100, nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcition = table.Column<string>(maxLength: 500, nullable: true),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Contact_person = table.Column<string>(maxLength: 100, nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Postcode = table.Column<string>(maxLength: 100, nullable: false),
                    Telphone = table.Column<string>(maxLength: 100, nullable: false),
                    Fax = table.Column<string>(maxLength: 100, nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customs_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Ename = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Telphone = table.Column<string>(maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Contact_person = table.Column<string>(maxLength: 100, nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Postcode = table.Column<string>(maxLength: 100, nullable: false),
                    Telphone = table.Column<string>(maxLength: 100, nullable: false),
                    Fax = table.Column<string>(maxLength: 100, nullable: false),
                    Creadedate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomId = table.Column<int>(nullable: false),
                    Orderdate = table.Column<DateTime>(nullable: false),
                    Deliverydate = table.Column<DateTime>(nullable: false),
                    DeliverId = table.Column<int>(nullable: false),
                    Charges = table.Column<decimal>(nullable: false),
                    Receiver = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Postcode = table.Column<string>(maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_masters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_masters_Customs_CustomId",
                        column: x => x.CustomId,
                        principalTable: "Customs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_masters_Delivers_DeliverId",
                        column: x => x.DeliverId,
                        principalTable: "Delivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_masters_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_datas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SupplyId = table.Column<int>(nullable: false),
                    Product_itemId = table.Column<int>(nullable: false),
                    Unit_quality = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Stock_quality = table.Column<decimal>(nullable: false),
                    Order_quality = table.Column<decimal>(nullable: false),
                    Safe_quality = table.Column<decimal>(nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_datas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_datas_Product_items_Product_itemId",
                        column: x => x.Product_itemId,
                        principalTable: "Product_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_datas_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order_masterId = table.Column<int>(nullable: false),
                    Product_dataId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quality = table.Column<decimal>(nullable: false),
                    Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_details_Order_masters_Order_masterId",
                        column: x => x.Order_masterId,
                        principalTable: "Order_masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_details_Product_datas_Product_dataId",
                        column: x => x.Product_dataId,
                        principalTable: "Product_datas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customs_TitleId",
                table: "Customs",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitleId",
                table: "Employees",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_Order_masterId",
                table: "Order_details",
                column: "Order_masterId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_Product_dataId",
                table: "Order_details",
                column: "Product_dataId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_masters_CustomId",
                table: "Order_masters",
                column: "CustomId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_masters_DeliverId",
                table: "Order_masters",
                column: "DeliverId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_masters_EmployeeId",
                table: "Order_masters",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_datas_Product_itemId",
                table: "Product_datas",
                column: "Product_itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_datas_SupplyId",
                table: "Product_datas",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_TitleId",
                table: "Supplies",
                column: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_details");

            migrationBuilder.DropTable(
                name: "Order_masters");

            migrationBuilder.DropTable(
                name: "Product_datas");

            migrationBuilder.DropTable(
                name: "Customs");

            migrationBuilder.DropTable(
                name: "Delivers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Product_items");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
