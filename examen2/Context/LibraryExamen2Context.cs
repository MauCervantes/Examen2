using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using examen2.Models;

namespace examen2.Context;

public partial class LibraryExamen2Context : DbContext
{
    public LibraryExamen2Context()
    {
    }

    public LibraryExamen2Context(DbContextOptions<LibraryExamen2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MAU;Database=libraryExamen2;Trust Server Certificate=true;User Id=sa;Password=12345;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__author__3213E83F8C7FFD73");

            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book__3213E83F306685ED");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chapters).HasColumnName("chapters");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__book__price__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
