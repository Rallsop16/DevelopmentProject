﻿// <auto-generated />
using System;
using DevelopmentProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevelopmentProject.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.CollectionMap", b =>
                {
                    b.Property<int>("CollectionMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionMapId"));

                    b.Property<int>("CollectionVocabId")
                        .HasColumnType("int");

                    b.Property<int>("VocabId")
                        .HasColumnType("int");

                    b.HasKey("CollectionMapId");

                    b.HasIndex("CollectionVocabId");

                    b.HasIndex("VocabId");

                    b.ToTable("CollectionMaps");

                    b.HasData(
                        new
                        {
                            CollectionMapId = 1,
                            CollectionVocabId = 1,
                            VocabId = 1
                        },
                        new
                        {
                            CollectionMapId = 88,
                            CollectionVocabId = 99,
                            VocabId = 98
                        });
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.CollectionVocab", b =>
                {
                    b.Property<int>("CollectionVocabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionVocabId"));

                    b.Property<string>("CollectionVocabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CollectionVocabId");

                    b.HasIndex("UserId");

                    b.ToTable("CollectionVocabs");

                    b.HasData(
                        new
                        {
                            CollectionVocabId = 1,
                            CollectionVocabName = "Animals",
                            UserId = 1
                        },
                        new
                        {
                            CollectionVocabId = 99,
                            CollectionVocabName = "Dog Breeds",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.Statistics", b =>
                {
                    b.Property<int>("StatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatisticsId"));

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StatisticsId");

                    b.HasIndex("UserId");

                    b.ToTable("Statistics");

                    b.HasData(
                        new
                        {
                            StatisticsId = 1,
                            Experience = 0,
                            Language = "French",
                            Time = 0,
                            UserId = 1
                        },
                        new
                        {
                            StatisticsId = 2,
                            Experience = 0,
                            Language = "French",
                            Time = 0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "Email@address.com",
                            FirstName = "Rachel",
                            LastName = "Allsop",
                            Password = "Password",
                            Role = "User"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "Address@email.com",
                            FirstName = "Kate",
                            LastName = "Jelly",
                            Password = "Password1",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.Vocab", b =>
                {
                    b.Property<int>("VocabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VocabId"));

                    b.Property<string>("Original_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Original_word")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Translated_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Translated_word")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VocabId");

                    b.HasIndex("UserId");

                    b.ToTable("Vocabs");

                    b.HasData(
                        new
                        {
                            VocabId = 1,
                            Original_language = "English",
                            Original_word = "Horse",
                            Translated_language = "French",
                            Translated_word = "Cheval",
                            UserId = 1
                        },
                        new
                        {
                            VocabId = 98,
                            Original_language = "English",
                            Original_word = "DOG",
                            Translated_language = "French",
                            Translated_word = "CHIEN",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.CollectionMap", b =>
                {
                    b.HasOne("DevelopmentProject.Shared.Entities.CollectionVocab", "CollectionVocab")
                        .WithMany("CollectionMaps")
                        .HasForeignKey("CollectionVocabId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevelopmentProject.Shared.Entities.Vocab", "Vocab")
                        .WithMany("CollectionMaps")
                        .HasForeignKey("VocabId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CollectionVocab");

                    b.Navigation("Vocab");
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.CollectionVocab", b =>
                {
                    b.HasOne("DevelopmentProject.Shared.Entities.User", "User")
                        .WithMany("CollectionVocabs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.Statistics", b =>
                {
                    b.HasOne("DevelopmentProject.Shared.Entities.User", "User")
                        .WithMany("StatisticsCol")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.Vocab", b =>
                {
                    b.HasOne("DevelopmentProject.Shared.Entities.User", "User")
                        .WithMany("Vocabs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.CollectionVocab", b =>
                {
                    b.Navigation("CollectionMaps");
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.User", b =>
                {
                    b.Navigation("CollectionVocabs");

                    b.Navigation("StatisticsCol");

                    b.Navigation("Vocabs");
                });

            modelBuilder.Entity("DevelopmentProject.Shared.Entities.Vocab", b =>
                {
                    b.Navigation("CollectionMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
