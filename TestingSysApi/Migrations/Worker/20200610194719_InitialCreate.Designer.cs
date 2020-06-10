﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestingSysApi.Contexts;

namespace TestingSysApi.Migrations.Worker
{
    [DbContext(typeof(WorkerContext))]
    [Migration("20200610194719_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("TestingSysApi.Models.Worker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("did_test");

                    b.Property<string>("email");

                    b.Property<string>("fname");

                    b.Property<string>("lname");

                    b.Property<bool>("pass_test");

                    b.HasKey("Id");

                    b.ToTable("Worker");

                    b.HasData(
                        new { Id = 6L, did_test = false, email = "bob@green.com", fname = "Bob", lname = "Green", pass_test = false }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
