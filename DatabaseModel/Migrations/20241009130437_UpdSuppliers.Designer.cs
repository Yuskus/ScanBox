﻿// <auto-generated />
using System;
using DatabaseModel.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseModel.Migrations
{
    [DbContext(typeof(ScanBoxDbContext))]
    [Migration("20241009130437_UpdSuppliers")]
    partial class UpdSuppliers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DatabaseModel.BuyerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_id");

                    b.HasKey("Id")
                        .HasName("id_buyer_pk");

                    b.HasIndex("CounterpartyId")
                        .IsUnique();

                    b.ToTable("buyers_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.CounterpartyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("address");

                    b.Property<int>("CounterpartyTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_type_id");

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("email");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("id_counterparty_pk");

                    b.HasIndex("CounterpartyTypeId");

                    b.ToTable("counterpartys_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.CounterpartyTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("type_name");

                    b.HasKey("Id")
                        .HasName("id_counterparty_type_pk");

                    b.ToTable("counterparties_types_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.DocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp")
                        .HasColumnName("creation_time");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("document_type_id");

                    b.Property<int>("WarehouseEmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("warehouse_employee_id");

                    b.HasKey("Id")
                        .HasName("id_document_pk");

                    b.HasIndex("CounterpartyId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("WarehouseEmployeeId");

                    b.ToTable("documents_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.DocumentTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("DoctypeName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("doctype_name");

                    b.HasKey("Id")
                        .HasName("id_document_type_pk");

                    b.ToTable("document_types_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.IndividualEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("patronymic");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("id_individual_pk");

                    b.HasIndex("CounterpartyId")
                        .IsUnique();

                    b.ToTable("individuals_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.JobTitleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("BaseSalary")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("base_salary");

                    b.Property<string>("DutiesDescription")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("duties_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_job_title_pk");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("job_titles_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.LegalEntityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("contact_person");

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_id");

                    b.Property<string>("DirectorsName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("directors_name");

                    b.Property<string>("DirectorsPatronymic")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("directors_patronymic");

                    b.Property<string>("DirectorsSurname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("directors_surname");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("INN");

                    b.Property<string>("KPP")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("KPP");

                    b.Property<string>("LegalAddress")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("legal_adress");

                    b.Property<int>("LegalFormId")
                        .HasColumnType("integer")
                        .HasColumnName("legal_form_id");

                    b.Property<string>("NameOfLegalEntity")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name_of_legal_entity");

                    b.Property<string>("OGRN")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("OGRN");

                    b.HasKey("Id")
                        .HasName("id_legal_entity_pk");

                    b.HasIndex("CounterpartyId")
                        .IsUnique();

                    b.HasIndex("LegalFormId");

                    b.ToTable("legal_entities_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.LegalFormEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("product_name");

                    b.Property<string>("LegalFormName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("legal_form_name");

                    b.HasKey("Id")
                        .HasName("id_legal_form_pk");

                    b.ToTable("legal_forms_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.ManufacturerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_id");

                    b.HasKey("Id")
                        .HasName("id_manufacturer_pk");

                    b.HasIndex("CounterpartyId")
                        .IsUnique();

                    b.ToTable("manufacturers_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.MovementHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnName("document_id");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("product_unit_id");

                    b.HasKey("Id")
                        .HasName("id_movement_history_pk");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("movements_history_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.PricesEntity", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductTypeId"));

                    b.Property<double>("MinPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("min_price");

                    b.Property<double>("RetailPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("retail_price");

                    b.Property<double>("WholesalePrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("wholesale_price");

                    b.HasKey("ProductTypeId")
                        .HasName("id_prices_pk");

                    b.ToTable("prices_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.ProductCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("category_description");

                    b.HasKey("Id")
                        .HasName("id_product_category_pk");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("product_category_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.ProductTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("barcode");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<double>("Heigth")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("heigth");

                    b.Property<double>("Length")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("length");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("integer")
                        .HasColumnName("manufacturer_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("product_name");

                    b.Property<int>("ProductPriceId")
                        .HasColumnType("integer")
                        .HasColumnName("product_price_id");

                    b.Property<double>("Weigth")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("weigth");

                    b.Property<double>("Width")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("width");

                    b.HasKey("Id")
                        .HasName("id_product_type_pk");

                    b.HasIndex("Barcode")
                        .IsUnique();

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ProductPriceId")
                        .IsUnique();

                    b.ToTable("product_types_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.ProductUnitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("product_type_id");

                    b.Property<DateOnly>("ProductionDate")
                        .HasColumnType("date")
                        .HasColumnName("production_date");

                    b.Property<double>("RealizationPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("realization_price");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer")
                        .HasColumnName("supplier_id");

                    b.Property<string>("UniqueBarcode")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("unique_barcode");

                    b.HasKey("Id")
                        .HasName("id_product_unit_pk");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UniqueBarcode")
                        .IsUnique();

                    b.ToTable("product_units_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.ShipmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnName("document_id");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("product_unit_id");

                    b.HasKey("Id")
                        .HasName("id_shipment_pk");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("shipments_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.SupplierEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("integer")
                        .HasColumnName("counterparty_id");

                    b.HasKey("Id")
                        .HasName("id_supplier_pk");

                    b.HasIndex("CounterpartyId")
                        .IsUnique();

                    b.ToTable("suppliers_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("id_user_entity_pk");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("user_entities_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.WarehouseEmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("address");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hire_date");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("integer")
                        .HasColumnName("JobTitleId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("patronymic");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("phone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("id_warehouse_employee_pk");

                    b.HasIndex("JobTitleId");

                    b.ToTable("warehouse_employees_table", (string)null);
                });

            modelBuilder.Entity("DatabaseModel.BuyerEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyEntity", "Counterparty")
                        .WithOne("Buyer")
                        .HasForeignKey("DatabaseModel.BuyerEntity", "CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1to1_buyer_to_counterparty_fk");

                    b.Navigation("Counterparty");
                });

            modelBuilder.Entity("DatabaseModel.CounterpartyEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyTypeEntity", "CounterpartyType")
                        .WithMany("Counterparties")
                        .HasForeignKey("CounterpartyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("manyto1_counterparty_to_counterparty_type_fk");

                    b.Navigation("CounterpartyType");
                });

            modelBuilder.Entity("DatabaseModel.DocumentEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyEntity", "Counterparty")
                        .WithMany("Documents")
                        .HasForeignKey("CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_counterparty_to_documents_fk");

                    b.HasOne("DatabaseModel.DocumentTypeEntity", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("manyto1_document_to_doctype_fk");

                    b.HasOne("DatabaseModel.WarehouseEmployeeEntity", "WarehouseEmployee")
                        .WithMany("Documents")
                        .HasForeignKey("WarehouseEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("manyto1_documents_to_warehouse_employee_fk");

                    b.Navigation("Counterparty");

                    b.Navigation("DocumentType");

                    b.Navigation("WarehouseEmployee");
                });

            modelBuilder.Entity("DatabaseModel.IndividualEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyEntity", "Counterparty")
                        .WithOne("Individual")
                        .HasForeignKey("DatabaseModel.IndividualEntity", "CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1to1_counterparty_to_individual_fk");

                    b.Navigation("Counterparty");
                });

            modelBuilder.Entity("DatabaseModel.LegalEntityEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyEntity", "Counterparty")
                        .WithOne("LegalEntity")
                        .HasForeignKey("DatabaseModel.LegalEntityEntity", "CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1to1_counterparty_to_legal_entity_fk");

                    b.HasOne("DatabaseModel.LegalFormEntity", "LegalForm")
                        .WithMany("LegalEntities")
                        .HasForeignKey("LegalFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("manyto1_legal_entities_to_legal_forms_fk");

                    b.Navigation("Counterparty");

                    b.Navigation("LegalForm");
                });

            modelBuilder.Entity("DatabaseModel.ManufacturerEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyEntity", "Counterparty")
                        .WithOne("Manufacturer")
                        .HasForeignKey("DatabaseModel.ManufacturerEntity", "CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1to1_counterparty_to_manufacturer_fk");

                    b.Navigation("Counterparty");
                });

            modelBuilder.Entity("DatabaseModel.MovementHistoryEntity", b =>
                {
                    b.HasOne("DatabaseModel.DocumentEntity", "Document")
                        .WithMany("MovementsHistory")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_document_to_movement_history_fk");

                    b.HasOne("DatabaseModel.ProductUnitEntity", "ProductUnit")
                        .WithMany("MovementsHistory")
                        .HasForeignKey("ProductUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("manyto1_movements_history_to_product_unit_fk");

                    b.Navigation("Document");

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("DatabaseModel.ProductTypeEntity", b =>
                {
                    b.HasOne("DatabaseModel.ProductCategoryEntity", "Category")
                        .WithMany("ProductTypes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_category_id_to_product_types_fk");

                    b.HasOne("DatabaseModel.ManufacturerEntity", "Manufacturer")
                        .WithMany("ProductTypes")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_manufacturer_id_to_product_types_fk");

                    b.HasOne("DatabaseModel.PricesEntity", "ProductPrice")
                        .WithOne("ProductType")
                        .HasForeignKey("DatabaseModel.ProductTypeEntity", "ProductPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1to1_product_price_id_to_product_types_fk");

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");

                    b.Navigation("ProductPrice");
                });

            modelBuilder.Entity("DatabaseModel.ProductUnitEntity", b =>
                {
                    b.HasOne("DatabaseModel.ProductTypeEntity", "ProductType")
                        .WithMany("ProductUnits")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_product_type_id_to_product_units_fk");

                    b.HasOne("DatabaseModel.SupplierEntity", "Supplier")
                        .WithMany("ProductUnits")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("manyto1_product_units_to_supplier_fk");

                    b.Navigation("ProductType");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DatabaseModel.ShipmentEntity", b =>
                {
                    b.HasOne("DatabaseModel.DocumentEntity", "Document")
                        .WithMany("Shipments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_document_to_shipment_fk");

                    b.HasOne("DatabaseModel.ProductUnitEntity", "ProductUnit")
                        .WithMany("Shipments")
                        .HasForeignKey("ProductUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_product_unit_to_shipment_fk");

                    b.Navigation("Document");

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("DatabaseModel.SupplierEntity", b =>
                {
                    b.HasOne("DatabaseModel.CounterpartyEntity", "Counterparty")
                        .WithOne("Supplier")
                        .HasForeignKey("DatabaseModel.SupplierEntity", "CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1to1_counterparty_to_supplier_fk");

                    b.Navigation("Counterparty");
                });

            modelBuilder.Entity("DatabaseModel.WarehouseEmployeeEntity", b =>
                {
                    b.HasOne("DatabaseModel.JobTitleEntity", "JobTitle")
                        .WithMany("WarehouseEmployees")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("1tomany_job_title_to_warehouse_employee_fk");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("DatabaseModel.CounterpartyEntity", b =>
                {
                    b.Navigation("Buyer");

                    b.Navigation("Documents");

                    b.Navigation("Individual");

                    b.Navigation("LegalEntity");

                    b.Navigation("Manufacturer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DatabaseModel.CounterpartyTypeEntity", b =>
                {
                    b.Navigation("Counterparties");
                });

            modelBuilder.Entity("DatabaseModel.DocumentEntity", b =>
                {
                    b.Navigation("MovementsHistory");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("DatabaseModel.DocumentTypeEntity", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("DatabaseModel.JobTitleEntity", b =>
                {
                    b.Navigation("WarehouseEmployees");
                });

            modelBuilder.Entity("DatabaseModel.LegalFormEntity", b =>
                {
                    b.Navigation("LegalEntities");
                });

            modelBuilder.Entity("DatabaseModel.ManufacturerEntity", b =>
                {
                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("DatabaseModel.PricesEntity", b =>
                {
                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("DatabaseModel.ProductCategoryEntity", b =>
                {
                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("DatabaseModel.ProductTypeEntity", b =>
                {
                    b.Navigation("ProductUnits");
                });

            modelBuilder.Entity("DatabaseModel.ProductUnitEntity", b =>
                {
                    b.Navigation("MovementsHistory");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("DatabaseModel.SupplierEntity", b =>
                {
                    b.Navigation("ProductUnits");
                });

            modelBuilder.Entity("DatabaseModel.WarehouseEmployeeEntity", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}