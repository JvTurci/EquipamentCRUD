﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Model;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230710143531_InitialMigrarion")]
    partial class InitialMigrarion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Entities.Equipament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EquipamentIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReadDirectionId")
                        .HasColumnType("int");

                    b.Property<int>("SituationId")
                        .HasColumnType("int");

                    b.Property<int>("UfDestinationId")
                        .HasColumnType("int");

                    b.Property<int>("UfSourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReadDirectionId");

                    b.HasIndex("SituationId");

                    b.HasIndex("UfDestinationId");

                    b.HasIndex("UfSourceId");

                    b.ToTable("Equipament");
                });

            modelBuilder.Entity("backend.Entities.ReadDirection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReadDirection");
                });

            modelBuilder.Entity("backend.Entities.Situation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Situation");
                });

            modelBuilder.Entity("backend.Entities.UF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UF");
                });

            modelBuilder.Entity("backend.Entities.Equipament", b =>
                {
                    b.HasOne("backend.Entities.ReadDirection", "ReadDirection")
                        .WithMany()
                        .HasForeignKey("ReadDirectionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Entities.Situation", "Situation")
                        .WithMany()
                        .HasForeignKey("SituationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Entities.UF", "UfDestination")
                        .WithMany()
                        .HasForeignKey("UfDestinationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Entities.UF", "UfSource")
                        .WithMany()
                        .HasForeignKey("UfSourceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ReadDirection");

                    b.Navigation("Situation");

                    b.Navigation("UfDestination");

                    b.Navigation("UfSource");
                });
#pragma warning restore 612, 618
        }
    }
}
