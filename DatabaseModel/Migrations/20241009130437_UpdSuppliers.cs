п»їusing System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdSuppliers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "manyto1_product_units_to_suppiler_fk",
                table: "product_units_table");

            migrationBuilder.DropTable(
                name: "suppilers_table");

            migrationBuilder.CreateTable(
                name: "suppliers_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_supplier_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_counterparty_to_supplier_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_entities_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_user_entity_pk", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_table_counterparty_id",
                table: "suppliers_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_entities_table_username",
                table: "user_entities_table",
                column: "username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "manyto1_product_units_to_supplier_fk",
                table: "product_units_table",
                column: "supplier_id",
                principalTable: "suppliers_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "manyto1_product_units_to_supplier_fk",
                table: "product_units_table");

            migrationBuilder.DropTable(
                name: "suppliers_table");

            migrationBuilder.DropTable(
                name: "user_entities_table");

            migrationBuilder.CreateTable(
                name: "suppilers_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_suppiler_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_counterparty_to_suppiler_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suppilers_table_counterparty_id",
                table: "suppilers_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "manyto1_product_units_to_suppiler_fk",
                table: "product_units_table",
                column: "supplier_id",
                principalTable: "suppilers_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
