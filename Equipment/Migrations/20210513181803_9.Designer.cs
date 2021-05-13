﻿// <auto-generated />
using Equipment.M.EquipmentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Equipment.Migrations
{
    [DbContext(typeof(EqContext))]
    [Migration("20210513181803_9")]
    partial class _9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Account_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Acc_user")
                        .HasColumnType("longtext");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Chipset_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Socket_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chipset");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Komplekt_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Acc_id")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<string>("Inventory")
                        .HasColumnType("longtext");

                    b.Property<int>("Otdelenie_Id")
                        .HasColumnType("int");

                    b.Property<int>("Status_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Acc_id");

                    b.HasIndex("Status_id");

                    b.ToTable("Komplekt");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.MB_K_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Inventory")
                        .HasColumnType("longtext");

                    b.Property<int>("Komplekt_Id")
                        .HasColumnType("int");

                    b.Property<int>("MB_id")
                        .HasColumnType("int");

                    b.Property<int>("Ports_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Komplekt_Id");

                    b.ToTable("Motherboards_K");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.MB_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Chipset_id")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("M2_count")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<int>("OnKomplekt")
                        .HasColumnType("int");

                    b.Property<int>("Ports_id")
                        .HasColumnType("int");

                    b.Property<int>("Ram_count")
                        .HasColumnType("int");

                    b.Property<int>("Ram_type_id")
                        .HasColumnType("int");

                    b.Property<int>("Socket_count")
                        .HasColumnType("int");

                    b.Property<int>("Socket_id")
                        .HasColumnType("int");

                    b.Property<int>("Type_eq_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Ports_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("COM")
                        .HasColumnType("int");

                    b.Property<int>("DP")
                        .HasColumnType("int");

                    b.Property<int>("DVI_D")
                        .HasColumnType("int");

                    b.Property<int>("DVI_I")
                        .HasColumnType("int");

                    b.Property<int>("HDMI")
                        .HasColumnType("int");

                    b.Property<int>("LTP")
                        .HasColumnType("int");

                    b.Property<int>("PS2")
                        .HasColumnType("int");

                    b.Property<int>("VGA")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ports");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Ram_type_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ram_type");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Socket_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Socket");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Status_M", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Type_eq_M", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type_name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Type_equipment");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.Komplekt_M", b =>
                {
                    b.HasOne("Equipment.M.EquipmentContext.Models.Account_M", "Account")
                        .WithMany()
                        .HasForeignKey("Acc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Equipment.M.EquipmentContext.Models.Status_M", "Status")
                        .WithMany()
                        .HasForeignKey("Status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Equipment.M.EquipmentContext.Models.MB_K_M", b =>
                {
                    b.HasOne("Equipment.M.EquipmentContext.Models.Komplekt_M", "Komplekt")
                        .WithMany()
                        .HasForeignKey("Komplekt_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Komplekt");
                });
#pragma warning restore 612, 618
        }
    }
}
