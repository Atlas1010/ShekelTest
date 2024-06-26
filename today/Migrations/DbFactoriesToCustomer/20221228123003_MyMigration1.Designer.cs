﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using today.Data;

#nullable disable

namespace today.Migrations.DbFactoriesToCustomer
{
    [DbContext(typeof(DbFactoriesToCustomerContext))]
    [Migration("20221228123003_MyMigration1")]
    partial class MyMigration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("today.Entities.FactoriesToCustomer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<int>("factoryCode")
                        .HasColumnType("int");

                    b.Property<int>("groupCode")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("FactoriesToCustomer");
                });
#pragma warning restore 612, 618
        }
    }
}
