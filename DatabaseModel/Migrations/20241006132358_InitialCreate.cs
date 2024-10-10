using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseModel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "counterparties_types_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_counterparty_type_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_types_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctype_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_document_type_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_titles_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    duties_description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    base_salary = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_job_title_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "legal_forms_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    legal_form_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    product_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_legal_form_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prices_table",
                columns: table => new
                {
                    product_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    min_price = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    retail_price = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    wholesale_price = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_prices_pk", x => x.product_type_id);
                });

            migrationBuilder.CreateTable(
                name: "product_category_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    category_description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_product_category_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "counterpartys_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_type_id = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_counterparty_pk", x => x.id);
                    table.ForeignKey(
                        name: "manyto1_counterparty_to_counterparty_type_fk",
                        column: x => x.counterparty_type_id,
                        principalTable: "counterparties_types_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_employees_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobTitleId = table.Column<int>(type: "integer", nullable: false),
                    surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    hire_date = table.Column<DateOnly>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_warehouse_employee_pk", x => x.id);
                    table.ForeignKey(
                        name: "1tomany_job_title_to_warehouse_employee_fk",
                        column: x => x.JobTitleId,
                        principalTable: "job_titles_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buyers_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buyer_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_buyer_to_counterparty_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "individuals_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false),
                    surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_individual_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_counterparty_to_individual_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legal_entities_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false),
                    legal_form_id = table.Column<int>(type: "integer", nullable: false),
                    name_of_legal_entity = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    directors_surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    directors_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    directors_patronymic = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    INN = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    KPP = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OGRN = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    legal_adress = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    contact_person = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_legal_entity_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_counterparty_to_legal_entity_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "manyto1_legal_entities_to_legal_forms_fk",
                        column: x => x.legal_form_id,
                        principalTable: "legal_forms_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_manufacturer_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_counterparty_to_manufacturer_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "documents_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    creation_time = table.Column<DateTime>(type: "timestamp", nullable: false),
                    warehouse_employee_id = table.Column<int>(type: "integer", nullable: false),
                    document_type_id = table.Column<int>(type: "integer", nullable: false),
                    counterparty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_document_pk", x => x.id);
                    table.ForeignKey(
                        name: "1tomany_counterparty_to_documents_fk",
                        column: x => x.counterparty_id,
                        principalTable: "counterpartys_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "manyto1_document_to_doctype_fk",
                        column: x => x.document_type_id,
                        principalTable: "document_types_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "manyto1_documents_to_warehouse_employee_fk",
                        column: x => x.warehouse_employee_id,
                        principalTable: "warehouse_employees_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_types_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    barcode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    product_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    length = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    heigth = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    width = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    weigth = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    manufacturer_id = table.Column<int>(type: "integer", nullable: false),
                    product_price_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_product_type_pk", x => x.id);
                    table.ForeignKey(
                        name: "1to1_product_price_id_to_product_types_fk",
                        column: x => x.product_price_id,
                        principalTable: "prices_table",
                        principalColumn: "product_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "1tomany_category_id_to_product_types_fk",
                        column: x => x.category_id,
                        principalTable: "product_category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "1tomany_manufacturer_id_to_product_types_fk",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturers_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_units_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unique_barcode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    production_date = table.Column<DateOnly>(type: "date", nullable: false),
                    realization_price = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    product_type_id = table.Column<int>(type: "integer", nullable: false),
                    supplier_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_product_unit_pk", x => x.id);
                    table.ForeignKey(
                        name: "1tomany_product_type_id_to_product_units_fk",
                        column: x => x.product_type_id,
                        principalTable: "product_types_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "manyto1_product_units_to_suppiler_fk",
                        column: x => x.supplier_id,
                        principalTable: "suppilers_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movements_history_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    product_unit_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_movement_history_pk", x => x.id);
                    table.ForeignKey(
                        name: "1tomany_document_to_movement_history_fk",
                        column: x => x.document_id,
                        principalTable: "documents_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "manyto1_movements_history_to_product_unit_fk",
                        column: x => x.product_unit_id,
                        principalTable: "product_units_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buyers_table_counterparty_id",
                table: "buyers_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_counterpartys_table_counterparty_type_id",
                table: "counterpartys_table",
                column: "counterparty_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_table_counterparty_id",
                table: "documents_table",
                column: "counterparty_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_table_document_type_id",
                table: "documents_table",
                column: "document_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_table_warehouse_employee_id",
                table: "documents_table",
                column: "warehouse_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_individuals_table_counterparty_id",
                table: "individuals_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_titles_table_name",
                table: "job_titles_table",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_legal_entities_table_counterparty_id",
                table: "legal_entities_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_legal_entities_table_legal_form_id",
                table: "legal_entities_table",
                column: "legal_form_id");

            migrationBuilder.CreateIndex(
                name: "IX_manufacturers_table_counterparty_id",
                table: "manufacturers_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movements_history_table_document_id",
                table: "movements_history_table",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_movements_history_table_product_unit_id",
                table: "movements_history_table",
                column: "product_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_table_category_name",
                table: "product_category_table",
                column: "category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_types_table_barcode",
                table: "product_types_table",
                column: "barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_types_table_category_id",
                table: "product_types_table",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_table_manufacturer_id",
                table: "product_types_table",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_table_product_price_id",
                table: "product_types_table",
                column: "product_price_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_units_table_product_type_id",
                table: "product_units_table",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_units_table_supplier_id",
                table: "product_units_table",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_units_table_unique_barcode",
                table: "product_units_table",
                column: "unique_barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppilers_table_counterparty_id",
                table: "suppilers_table",
                column: "counterparty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_employees_table_JobTitleId",
                table: "warehouse_employees_table",
                column: "JobTitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyers_table");

            migrationBuilder.DropTable(
                name: "individuals_table");

            migrationBuilder.DropTable(
                name: "legal_entities_table");

            migrationBuilder.DropTable(
                name: "movements_history_table");

            migrationBuilder.DropTable(
                name: "legal_forms_table");

            migrationBuilder.DropTable(
                name: "documents_table");

            migrationBuilder.DropTable(
                name: "product_units_table");

            migrationBuilder.DropTable(
                name: "document_types_table");

            migrationBuilder.DropTable(
                name: "warehouse_employees_table");

            migrationBuilder.DropTable(
                name: "product_types_table");

            migrationBuilder.DropTable(
                name: "suppilers_table");

            migrationBuilder.DropTable(
                name: "job_titles_table");

            migrationBuilder.DropTable(
                name: "prices_table");

            migrationBuilder.DropTable(
                name: "product_category_table");

            migrationBuilder.DropTable(
                name: "manufacturers_table");

            migrationBuilder.DropTable(
                name: "counterpartys_table");

            migrationBuilder.DropTable(
                name: "counterparties_types_table");
        }
    }
}
