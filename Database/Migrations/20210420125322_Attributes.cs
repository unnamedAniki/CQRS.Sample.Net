using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Database.Migrations
{
    public partial class Attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attributes", x => x.id);
                    table.ForeignKey(
                        name: "fk_attributes_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    attribute_id = table.Column<Guid>(type: "uuid", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_attribute_values", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_attribute_values_attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalTable: "attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_product_attribute_values_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "attributes",
                columns: new[] { "id", "category_id", "name", "type" },
                values: new object[] { new Guid("c732a300-3dd9-46b6-8d38-0b6512212fa1"), new Guid("a427f99e-d620-49fb-afa3-69b81b41556c"), "Height", 1 });

            migrationBuilder.CreateIndex(
                name: "ix_attributes_category_id",
                table: "attributes",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_attribute_values_attribute_id",
                table: "product_attribute_values",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_attribute_values_product_id",
                table: "product_attribute_values",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_attribute_values");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
