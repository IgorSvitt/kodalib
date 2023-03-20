using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Kodalib.Data.Entities;

namespace Kodalib.Data.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<FilmsActor> FilmsActors { get; set; } = null!;
        public virtual DbSet<FilmsCountry> FilmsCountries { get; set; } = null!;
        public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=89.22.237.35;Database=koda;Port=5432;Username=koda-admin;Password=9f!R1rW9o");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actors");

                entity.HasIndex(e => e.ActorId, "uc_actors_actor")
                    .IsUnique();

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.CountryId, "uc_countries_country")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("films");

                entity.HasIndex(e => e.FilmId, "uc_films_film")
                    .IsUnique();

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.CashSuccess).HasColumnName("cash_success");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_creation");

                entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");

                entity.Property(e => e.Plot).HasColumnName("plot");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .HasColumnName("title");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<FilmsActor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("films_actors");

                entity.HasIndex(e => e.FilmId, "uc_films_actors_film")
                    .IsUnique();

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_filact_on_actor");

                entity.HasOne(d => d.Film)
                    .WithOne()
                    .HasForeignKey<FilmsActor>(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_filact_on_film");
            });

            modelBuilder.Entity<FilmsCountry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("films_countries");

                entity.HasIndex(e => e.FilmId, "uc_films_countries_film")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.HasOne(d => d.Country)
                    .WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_filcou_on_country");

                entity.HasOne(d => d.Film)
                    .WithOne()
                    .HasForeignKey<FilmsCountry>(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_filcou_on_film");
            });

            modelBuilder.Entity<FlywaySchemaHistory>(entity =>
            {
                entity.HasKey(e => e.InstalledRank)
                    .HasName("flyway_schema_history_pk");

                entity.ToTable("flyway_schema_history");

                entity.HasIndex(e => e.Success, "flyway_schema_history_s_idx");

                entity.Property(e => e.InstalledRank)
                    .ValueGeneratedNever()
                    .HasColumnName("installed_rank");

                entity.Property(e => e.Checksum).HasColumnName("checksum");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(100)
                    .HasColumnName("installed_by");

                entity.Property(e => e.InstalledOn)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("installed_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Script)
                    .HasMaxLength(1000)
                    .HasColumnName("script");

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
