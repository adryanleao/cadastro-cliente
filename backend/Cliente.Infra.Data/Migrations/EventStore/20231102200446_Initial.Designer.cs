﻿// <auto-generated />
using System;
using Cliente.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cliente.Infra.Data.Migrations.EventStore
{
    [DbContext(typeof(EventStoreSqlContext))]
    [Migration("20231102200446_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cliente.Domain.Core.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AggregateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Action");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.HasKey("Id");

                    b.ToTable("StoredEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
