using System;
using System.IO;
using AboutThatSize.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AboutThatSize.Data
{
    public partial class AboutThatSizeContext : DbContext
    {
        public AboutThatSizeContext()
        {
        }

        public AboutThatSizeContext(DbContextOptions<AboutThatSizeContext> options) : base(options)
        {
        }

        public virtual DbSet<ConversionHistory> ConversionHistories { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseMySQL(configuration.GetConnectionString("AboutThatSize"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversionHistory>(entity =>
            {
                entity.ToTable("conversion_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FromName)
                    .HasColumnName("from_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FromValue)
                    .HasColumnName("from_value")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.ToName)
                    .HasColumnName("to_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToValue)
                    .HasColumnName("to_value")
                    .HasColumnType("float(10,2)");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.Mass)
                    .HasColumnName("mass")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
