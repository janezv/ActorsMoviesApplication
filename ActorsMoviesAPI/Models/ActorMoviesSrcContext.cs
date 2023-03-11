using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ActorsMoviesAPI.Models;

public partial class ActorMoviesSrcContext : DbContext
{
    public ActorMoviesSrcContext()
    {
    }

    public ActorMoviesSrcContext(DbContextOptions<ActorMoviesSrcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<ImgPath> ImgPaths { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1TPLI7F\\SQLEXPRESS;Initial Catalog=ActorMoviesSRC;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actors__57B3EA4B4A189815");

            entity.Property(e => e.BornDate)
                .HasColumnType("date")
                .HasColumnName("bornDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Movie).WithMany(p => p.Actors)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actors__MovieId__1BC821DD");
        });

        modelBuilder.Entity<ImgPath>(entity =>
        {
            entity.HasKey(e => e.ImgPathId).HasName("PK__ImgPaths__132AA4C76E17D06D");

            entity.Property(e => e.ImgPath1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ImgPath");

            entity.HasOne(d => d.Movie).WithMany(p => p.ImgPaths)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImgPaths__MovieI__1EA48E88");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2941A110EF1CF");

            entity.Property(e => e.MovieId).ValueGeneratedNever();
            entity.Property(e => e.MovieDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
