using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseModel.Migrations
{
    /// <inheritdoc />
    public partial class ShipmentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shipments_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    product_unit_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_shipment_pk", x => x.id);
                    table.ForeignKey(
                        name: "1tomany_document_to_shipment_fk",
                        column: x => x.document_id,
                        principalTable: "documents_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "1tomany_product_unit_to_shipment_fk",
                        column: x => x.product_unit_id,
                        principalTable: "product_units_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shipments_table_document_id",
                table: "shipments_table",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipments_table_product_unit_id",
                table: "shipments_table",
                column: "product_unit_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shipments_table");
        }
    }
}
