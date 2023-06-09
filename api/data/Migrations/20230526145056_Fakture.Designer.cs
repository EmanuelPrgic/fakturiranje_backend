﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.data;

#nullable disable

namespace api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230526145056_Fakture")]
    partial class Fakture
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("api.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Entities.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresa")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankaDva")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankaJedan")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankaTri")
                        .HasColumnType("TEXT");

                    b.Property<int>("BrojPoste")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Drzava")
                        .HasColumnType("TEXT");

                    b.Property<int>("Mb")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mjesto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naziv")
                        .HasColumnType("TEXT");

                    b.Property<int>("Pdv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Swift")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tip")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Partneri");
                });

            modelBuilder.Entity("api.Entities.StavkeRacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CijenaDeviza")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CijenaKM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FakturnaVrijednost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IznosPdv")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IznosRabata")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kolicina")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Opis")
                        .HasColumnType("TEXT");

                    b.Property<int>("Osnovica")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pdv")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rabat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UkupanIznos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ZaglavljeRacunaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ZaglavljeRacunaId");

                    b.ToTable("StavkeRacuna");
                });

            modelBuilder.Entity("api.Entities.Usluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CijenaDeviza")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CijenaKM")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naziv")
                        .HasColumnType("TEXT");

                    b.Property<int>("StavkeRacunaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StavkeRacunaId");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("api.Entities.ZaglavljeRacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrojRacuna")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatumDokumenta")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatumDospijeca")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatumIsporuke")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("TEXT");

                    b.Property<int>("FiskalniBroj")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MjestoIzdavanja")
                        .HasColumnType("TEXT");

                    b.Property<string>("Napomena")
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .HasColumnType("TEXT");

                    b.Property<int>("PartnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tecaj")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UkupanIznos")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId")
                        .IsUnique();

                    b.ToTable("ZaglavljeRacuna");
                });

            modelBuilder.Entity("api.Entities.StavkeRacuna", b =>
                {
                    b.HasOne("api.Entities.ZaglavljeRacuna", "ZaglavljeRacuna")
                        .WithMany()
                        .HasForeignKey("ZaglavljeRacunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZaglavljeRacuna");
                });

            modelBuilder.Entity("api.Entities.Usluga", b =>
                {
                    b.HasOne("api.Entities.StavkeRacuna", "StavkeRacuna")
                        .WithMany()
                        .HasForeignKey("StavkeRacunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StavkeRacuna");
                });

            modelBuilder.Entity("api.Entities.ZaglavljeRacuna", b =>
                {
                    b.HasOne("api.Entities.Partner", "Partner")
                        .WithOne("ZaglavljeRacuna")
                        .HasForeignKey("api.Entities.ZaglavljeRacuna", "PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("api.Entities.Partner", b =>
                {
                    b.Navigation("ZaglavljeRacuna");
                });
#pragma warning restore 612, 618
        }
    }
}
