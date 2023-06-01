﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wordle.Api.Data;

#nullable disable

namespace Wordle.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230530084850_AGR6")]
    partial class AGR6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.Property<int>("DateWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateWordId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("DateWordId");

                    b.HasIndex("WordId");

                    b.ToTable("DateWords");
                });

            modelBuilder.Entity("Wordle.Api.Data.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<double>("AverageAttempts")
                        .HasColumnType("float");

                    b.Property<int>("AverageSecondsPerGame")
                        .HasColumnType("int");

                    b.Property<int>("GameCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalAttempts")
                        .HasColumnType("int");

                    b.Property<int>("TotalSecondsPlayed")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Wordle.Api.Data.Plays", b =>
                {
                    b.Property<int>("PlaysId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaysId"));

                    b.Property<int>("Attempts")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DateWordId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TimeInSeconds")
                        .HasColumnType("int");

                    b.Property<bool>("WasGameWon")
                        .HasColumnType("bit");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("PlaysId");

                    b.HasIndex("DateWordId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WordId");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("Wordle.Api.Data.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"));

                    b.Property<bool>("IsCommon")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.HasOne("Wordle.Api.Data.Word", "Word")
                        .WithMany("DateWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.Api.Data.Plays", b =>
                {
                    b.HasOne("Wordle.Api.Data.DateWord", "DateWord")
                        .WithMany("Plays")
                        .HasForeignKey("DateWordId");

                    b.HasOne("Wordle.Api.Data.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wordle.Api.Data.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DateWord");

                    b.Navigation("Player");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.Navigation("Plays");
                });

            modelBuilder.Entity("Wordle.Api.Data.Word", b =>
                {
                    b.Navigation("DateWords");
                });
#pragma warning restore 612, 618
        }
    }
}
