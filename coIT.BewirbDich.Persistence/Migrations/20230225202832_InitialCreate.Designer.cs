﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coIT.BewirbDich.Persistence;

#nullable disable

namespace coIT.BewirbDich.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230225202832_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("VersicherungsscheinSequence");

            modelBuilder.Entity("coIT.BewirbDich.Persistence.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", (string)null);
                });

            modelBuilder.Entity("coIT.BewirbDich.Persistence.Outbox.OutboxMessageConsumer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id", "Name");

                    b.ToTable("OutboxMessageConsumers", (string)null);
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.Angebotsanfrage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Berechnungsart")
                        .HasColumnType("int");

                    b.Property<bool>("HatWebshop")
                        .HasColumnType("bit");

                    b.Property<bool>("InkludiereZusatzschutz")
                        .HasColumnType("bit");

                    b.Property<int>("Risiko")
                        .HasColumnType("int");

                    b.Property<decimal>("Versicherungssumme")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ZusatzschutzAufschlag")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Angebotsanfrage", (string)null);
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsKonditionen", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Berechnungsbasis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GesamtBeitrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GrundBeitrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RisikoAufschlag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WebShopAufschlag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ZusatzschutzAufschlag")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("VersicherungsKondidtionen", (string)null);
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsVorgang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("VorgangsStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VersicherungsVorgang", (string)null);
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.Versicherungsschein", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Versicherungsnummer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [VersicherungsscheinSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Versicherungsnummer"));

                    b.Property<DateTime>("ErstellungsDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "Versicherungsnummer");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Versicherungsschein", (string)null);
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.Angebotsanfrage", b =>
                {
                    b.HasOne("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsVorgang", null)
                        .WithOne("Angebotsanfrage")
                        .HasForeignKey("coIT.BewirbDich.Winforms.Domain.Entities.Angebotsanfrage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsKonditionen", b =>
                {
                    b.HasOne("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsVorgang", null)
                        .WithOne("VersicherungsKonditionen")
                        .HasForeignKey("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsKonditionen", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.Versicherungsschein", b =>
                {
                    b.HasOne("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsVorgang", null)
                        .WithOne("Versicherungsschein")
                        .HasForeignKey("coIT.BewirbDich.Winforms.Domain.Entities.Versicherungsschein", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("coIT.BewirbDich.Winforms.Domain.Entities.VersicherungsVorgang", b =>
                {
                    b.Navigation("Angebotsanfrage")
                        .IsRequired();

                    b.Navigation("VersicherungsKonditionen")
                        .IsRequired();

                    b.Navigation("Versicherungsschein");
                });
#pragma warning restore 612, 618
        }
    }
}
