﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231230142619_initialv1")]
    partial class initialv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.LotteryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LotteryResultId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Picks")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinFlg")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("LotteryResultId");

                    b.ToTable("LotteryDetails");
                });

            modelBuilder.Entity("api.Models.LotteryResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("LotteryCalendar")
                        .HasColumnType("TEXT");

                    b.Property<string>("LotteryCalendarFormat")
                        .HasColumnType("TEXT");

                    b.Property<int>("Results")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slot")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LotteryResults");
                });

            modelBuilder.Entity("api.Models.Msg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageContent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("api.Models.LotteryDetail", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.LotteryResult", "LotteryResult")
                        .WithMany()
                        .HasForeignKey("LotteryResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("LotteryResult");
                });
#pragma warning restore 612, 618
        }
    }
}
