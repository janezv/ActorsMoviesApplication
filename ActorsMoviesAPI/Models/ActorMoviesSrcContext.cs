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

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1TPLI7F\\SQLEXPRESS;Initial Catalog=ActorMoviesSRC;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actors__57B3EA4B87A0AB2E");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2941AA6999EDB");

            entity.HasOne(d => d.Actor).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movies__ActorId__6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
