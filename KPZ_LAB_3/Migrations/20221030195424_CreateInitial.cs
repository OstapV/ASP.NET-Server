using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KPZ_LAB_3.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_collection",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_collection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_material",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_material", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "saler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    isManager = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_data", x => x.id);
                    table.ForeignKey(
                        name: "FK__person_da__custo__440B1D61",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_type_id = table.Column<int>(type: "int", nullable: false),
                    manufacturer_id = table.Column<int>(type: "int", nullable: false),
                    product_collection_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK__product__manufac__37A5467C",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__product__product__36B12243",
                        column: x => x.product_type_id,
                        principalTable: "product_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__product__product__38996AB5",
                        column: x => x.product_collection_id,
                        principalTable: "product_collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operation_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    payment_type_id = table.Column<int>(type: "int", nullable: false),
                    customer_order_status_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    saler_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order", x => x.id);
                    table.ForeignKey(
                        name: "FK__customer___custo__2A4B4B5E",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___custo__2C3393D0",
                        column: x => x.customer_order_status_id,
                        principalTable: "customer_order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___payme__2B3F6F97",
                        column: x => x.payment_type_id,
                        principalTable: "payment_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_order_saler_saler_id",
                        column: x => x.saler_id,
                        principalTable: "saler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_composition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_material_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_composition", x => x.id);
                    table.ForeignKey(
                        name: "FK__product_c__produ__3B75D760",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__product_c__produ__3C69FB99",
                        column: x => x.product_material_id,
                        principalTable: "product_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_order_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    delivery_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK__delivery__custom__47DBAE45",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    customer_order_id = table.Column<int>(type: "int", nullable: false),
                    product_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.id);
                    table.ForeignKey(
                        name: "FK__order_det__custo__3F466844",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order_det__produ__403A8C7D",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_id",
                table: "customer_order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_order_status_id",
                table: "customer_order",
                column: "customer_order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_payment_type_id",
                table: "customer_order",
                column: "payment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_saler_id",
                table: "customer_order",
                column: "saler_id");

            migrationBuilder.CreateIndex(
                name: "UQ__delivery__1A3F6EA1E7F6605B",
                table: "delivery",
                column: "customer_order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_details_customer_order_id",
                table: "order_details",
                column: "customer_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_product_id",
                table: "order_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__person_d__CD65CB848CC34CE3",
                table: "person_data",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_manufacturer_id",
                table: "product",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_collection_id",
                table: "product",
                column: "product_collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_type_id",
                table: "product",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_composition_product_id",
                table: "product_composition",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_composition_product_material_id",
                table: "product_composition",
                column: "product_material_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "person_data");

            migrationBuilder.DropTable(
                name: "product_composition");

            migrationBuilder.DropTable(
                name: "customer_order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "product_material");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "customer_order_status");

            migrationBuilder.DropTable(
                name: "payment_type");

            migrationBuilder.DropTable(
                name: "saler");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "product_type");

            migrationBuilder.DropTable(
                name: "product_collection");
        }
    }
}
