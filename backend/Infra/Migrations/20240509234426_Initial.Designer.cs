﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Stairways.Infra.Context;

#nullable disable

namespace Stairways.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240509234426_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Stairways.Core.Models.RoadmapEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("JsonContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Meta", "Stairways.Core.Models.RoadmapEntity.Meta#RoadmapMeta", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ImageURL")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("Level")
                                .HasColumnType("integer");

                            b1.Property<int>("Privacity")
                                .HasColumnType("integer");

                            b1.Property<string[]>("Tags")
                                .IsRequired()
                                .HasColumnType("text[]");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Roadmaps", (string)null);
                });

            modelBuilder.Entity("Stairways.Core.Models.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Stairways.Core.Models.RoadmapEntity", b =>
                {
                    b.HasOne("Stairways.Core.Models.UserEntity", "Author")
                        .WithMany("Roadmaps")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Stairways.Core.Models.UserEntity", b =>
                {
                    b.Navigation("Roadmaps");
                });
#pragma warning restore 612, 618
        }
    }
}
