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
    [Migration("20221122053330_RenameActorAndRoleToPerson")]
    partial class RenameActorAndRoleToPerson
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.Character", b =>
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

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.Person", b =>
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

                    b.Property<string>("Height")
                        .HasColumnType("text")
                        .HasColumnName("height");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PersonImdbId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("person_imdb_id");

                    b.Property<string>("Summary")
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.HasKey("Id");

                    b.ToTable("actors");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.Role", b =>
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

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.RolePerson", b =>
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

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.TopActor", b =>
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

                    b.Property<string>("Budget")
                        .HasColumnType("text")
                        .HasColumnName("budget");

                    b.Property<string>("Duration")
                        .HasColumnType("text")
                        .HasColumnName("duration");

                    b.Property<string>("GrossWorldwide")
                        .HasColumnType("text")
                        .HasColumnName("gross_worldwide");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imdb_id");

                    b.Property<short?>("ImdbRating")
                        .HasColumnType("smallint")
                        .HasColumnName("imdb_rating");

                    b.Property<short?>("KodalibRating")
                        .HasColumnType("smallint")
                        .HasColumnName("kodalib_rating");

                    b.Property<string>("Plot")
                        .HasColumnType("text")
                        .HasColumnName("plot");

                    b.Property<string>("Poster")
                        .HasColumnType("text")
                        .HasColumnName("poster");

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

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.Character", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.ActorsTables.Person", "Actor")
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

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.RolePerson", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.ActorsTables.Person", "Person")
                        .WithMany("Role")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KodalibApi.Data.Models.ActorsTables.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.TopActor", b =>
                {
                    b.HasOne("KodalibApi.Data.Models.ActorsTables.Person", "Actor")
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

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.Person", b =>
                {
                    b.Navigation("Films");

                    b.Navigation("Role");

                    b.Navigation("TopActors");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.ActorsTables.Role", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.Country", b =>
                {
                    b.Navigation("FilmsList");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.FIlmTables.Film", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("CountriesList");

                    b.Navigation("GenresList");

                    b.Navigation("TopActors");
                });

            modelBuilder.Entity("KodalibApi.Data.Models.Genre", b =>
                {
                    b.Navigation("FilmsList");
                });
#pragma warning restore 612, 618
        }
    }
}
