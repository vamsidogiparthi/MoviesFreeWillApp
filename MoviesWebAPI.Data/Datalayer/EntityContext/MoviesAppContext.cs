using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MoviesWebAPI.Data.Datalayer.Models;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.EntityContext
{
    public partial class MoviesAppContext : DbContext
    {
        public MoviesAppContext()
        {
        }

        public MoviesAppContext(DbContextOptions<MoviesAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MovieUserRating> MovieUserRatings { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MoviesApp;Trusted_Connection=True;MultipleActiveResultSets=true;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasIndex(e => new { e.MovieId, e.GenreId }, "UK_MovieGenres_MovieId_GenreID")
                    .IsUnique();

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genres_MovieGenres");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movies_MovieUserRatings");
            });

            modelBuilder.Entity<MovieUserRating>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.RatingId, e.MovieId }, "UK_MovieUserRatings_MovieId_UserId_RatingId")
                    .IsUnique();

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieUserRatings)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movies_MovieGenres");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.MovieUserRatings)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_MovieUserRatings");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieUserRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_MovieUserRatings");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
