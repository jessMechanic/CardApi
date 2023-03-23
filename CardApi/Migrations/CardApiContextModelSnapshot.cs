﻿// <auto-generated />
using System;
using CardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CardApi.Migrations
{
    [DbContext(typeof(CardApiContext))]
    partial class CardApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("CardApi.Models.Account.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TimeStap")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CardApi.Models.Matches.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Player1")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Player2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("matches");
                });
#pragma warning restore 612, 618
        }
    }
}
