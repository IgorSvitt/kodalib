﻿// <auto-generated />
using System;
using KodalibApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230104170023_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KodalibApi.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FIlmTables.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Duration")
                        .HasColumnType("text")
                        .HasColumnName("duration");

                    b.Property<string>("KinopoiskId")
                        .HasColumnType("text")
                        .HasColumnName("kinopoisk_id");

                    b.Property<string>("KinopoiskRating")
                        .HasColumnType("text")
                        .HasColumnName("kinopoisk_rating");

                    b.Property<string>("KodalibRating")
                        .HasColumnType("text")
                        .HasColumnName("kodalib_rating");

                    b.Property<string>("LinkVideo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("link_video");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("text")
                        .HasColumnName("org_title");

                    b.Property<string>("Plot")
                        .HasColumnType("text")
                        .HasColumnName("plot");

                    b.Property<string>("Poster")
                        .HasColumnType("text")
                        .HasColumnName("poster");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("text")
                        .HasColumnName("ThumbnailUrl");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<short?>("Year")
                        .HasColumnType("smallint")
                        .HasColumnName("year");

                    b.Property<string>("YoutubeTrailer")
                        .HasColumnType("text")
                        .HasColumnName("youtube_trailer");

                    b.HasKey("Id");

                    b.ToTable("films");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FIlmTables.FilmsCountries", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("integer")
                        .HasColumnName("films_id");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.HasKey("FilmsId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("films_countries");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FilmTables.FilmsGenres", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("integer")
                        .HasColumnName("films_id");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genres_id");

                    b.HasKey("FilmsId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("films_genres");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Character", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("film_id");

                    b.Property<int>("ActorId")
                        .HasColumnType("integer")
                        .HasColumnName("actors_id");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("character");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Director", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("film_id");

                    b.Property<int>("DirectorId")
                        .HasColumnType("integer")
                        .HasColumnName("director_id");

                    b.HasKey("FilmId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("directors_films");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDate")
                        .HasColumnType("text")
                        .HasColumnName("birth_date");

                    b.Property<string>("DeathDate")
                        .HasColumnType("text")
                        .HasColumnName("death_date");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PersonKinopoiskId")
                        .HasColumnType("text")
                        .HasColumnName("person_kinopoisk_id");

                    b.Property<string>("Summary")
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.HasKey("Id");

                    b.ToTable("person");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.RolePerson", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("person_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("PersonId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("role_person");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.TopActor", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("film_id");

                    b.Property<int>("ActorId")
                        .HasColumnType("integer")
                        .HasColumnName("actors_id");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("top_actors");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Writers", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("film_id");

                    b.Property<int>("WriterId")
                        .HasColumnType("integer")
                        .HasColumnName("writer_id");

                    b.HasKey("FilmId", "WriterId");

                    b.HasIndex("WriterId");

                    b.ToTable("writers_films");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FIlmTables.FilmsCountries", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.Country", "Country")
                        .WithMany("FilmsList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.FIlmTables.Film", "Film")
                        .WithMany("CountriesList")
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FilmTables.FilmsGenres", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.FIlmTables.Film", "Film")
                        .WithMany("GenresList")
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.Genre", "Genre")
                        .WithMany("FilmsList")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Character", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.PeopleTables.Person", "Actor")
                        .WithMany("Films")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.FIlmTables.Film", "Film")
                        .WithMany("Characters")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Director", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.PeopleTables.Person", "DirectorPerson")
                        .WithMany("Directors")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.FIlmTables.Film", "Film")
                        .WithMany("DirectorsList")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectorPerson");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.RolePerson", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.PeopleTables.Person", "Person")
                        .WithMany("Role")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.PeopleTables.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.TopActor", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.PeopleTables.Person", "Actor")
                        .WithMany("TopActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.FIlmTables.Film", "Film")
                        .WithMany("TopActors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Writers", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.FIlmTables.Film", "Film")
                        .WithMany("WritersList")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.PeopleTables.Person", "WriterPerson")
                        .WithMany("Writers")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("WriterPerson");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.Country", b =>
                {
                    b.Navigation("FilmsList");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FIlmTables.Film", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("CountriesList");

                    b.Navigation("DirectorsList");

                    b.Navigation("GenresList");

                    b.Navigation("TopActors");

                    b.Navigation("WritersList");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.Genre", b =>
                {
                    b.Navigation("FilmsList");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Person", b =>
                {
                    b.Navigation("Directors");

                    b.Navigation("Films");

                    b.Navigation("Role");

                    b.Navigation("TopActors");

                    b.Navigation("Writers");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.PeopleTables.Role", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}