﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models.Enumerations;
using System;

namespace Schedule.IntIta.DataAccess.Migrations
{
    [DbContext(typeof(IntitaDbContext))]
    [Migration("20180318173606_GroupIntegration")]
    partial class GroupIntegration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<int?>("DateId");

                    b.Property<int?>("GroupId");

                    b.Property<int?>("InitiatorId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("RoomId");

                    b.Property<int?>("SubjectId");

                    b.Property<int?>("TypeOfEventId");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.HasIndex("TypeOfEventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Grant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Grants");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfStudents");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Office");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("OfficeId");

                    b.Property<int>("RoomStatus");

                    b.Property<int>("SeatNumber");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.SubGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfStudents");

                    b.Property<int?>("SubGroupTimeSlotId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubGroupTimeSlotId");

                    b.ToTable("SubGroups");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.TimeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("IdType");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.TimeSlotTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("TimeSlotTypes");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.Event", b =>
                {
                    b.HasOne("Schedule.IntIta.Domain.Models.TimeSlot", "Date")
                        .WithMany()
                        .HasForeignKey("DateId");

                    b.HasOne("Schedule.IntIta.Domain.Models.EventType", "TypeOfEvent")
                        .WithMany()
                        .HasForeignKey("TypeOfEventId");
                });

            modelBuilder.Entity("Schedule.IntIta.Domain.Models.SubGroup", b =>
                {
                    b.HasOne("Schedule.IntIta.Domain.Models.Group")
                        .WithMany("Subgroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Schedule.IntIta.Domain.Models.TimeSlot", "SubGroupTimeSlot")
                        .WithMany()
                        .HasForeignKey("SubGroupTimeSlotId");
                });
#pragma warning restore 612, 618
        }
    }
}
