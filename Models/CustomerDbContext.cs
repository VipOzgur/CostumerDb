using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace yeni.Models;

public partial class CustomerDbContext : DbContext
{
    public CustomerDbContext()
    {
    }

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CImage> CImages { get; set; }

    public virtual DbSet<Musteri> Musteris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlite($"Data Source={Application.StartupPath}data\\CustomerDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CImage>(entity =>
        {
            entity.ToTable("images");

            entity.HasIndex(e => e.Id, "IX_images_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagePath).HasColumnName("imagePath");
            entity.Property(e => e.MusteriId).HasColumnName("musteriId");
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.ToTable("musteri");

            entity.HasIndex(e => e.Id, "IX_musteri_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdSoyad).HasColumnName("adSoyad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
