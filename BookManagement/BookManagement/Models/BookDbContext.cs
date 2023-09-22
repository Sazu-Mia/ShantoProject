using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Models;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BorrowedBook> BorrowedBooks { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=BookDb;Initial Catalog=BookDb;Encrypt=False;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C2276D09CA32");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BorrowedBook>(entity =>
        {
            entity.HasKey(e => e.BorrowedId).HasName("PK__Borrowed__565E30CC835EC2A9");

            entity.Property(e => e.BorrowedId).HasColumnName("BorrowedID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.BorrowDate).HasColumnType("date");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ReturnDate).HasColumnType("date");

            entity.HasOne(d => d.Book).WithMany(p => p.BorrowedBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BorrowedB__BookI__286302EC");

            entity.HasOne(d => d.Member).WithMany(p => p.BorrowedBooks)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BorrowedB__Membe__276EDEB3");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B38B4F79D63");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
