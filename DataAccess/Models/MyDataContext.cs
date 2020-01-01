using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyDataAccess.Models
{
    public partial class MyDataContext : DbContext
    {
        public MyDataContext()
        {
        }

        public MyDataContext(DbContextOptions<MyDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<TableField> TableField { get; set; }
        public virtual DbSet<TableFieldValue> TableFieldValue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Home;Database=MyData;user id=sa;pwd=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.FieldId)
                    .HasColumnName("FieldID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FieldName).HasMaxLength(50);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.TableName).HasMaxLength(50);
            });

            modelBuilder.Entity<TableField>(entity =>
            {
                entity.Property(e => e.TableFieldId)
                    .HasColumnName("TableFieldID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FieldDisplayName).HasMaxLength(200);

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.TableId).HasColumnName("TableID");
            });

            modelBuilder.Entity<TableFieldValue>(entity =>
            {
                entity.Property(e => e.TableFieldValueId)
                    .HasColumnName("TableFieldValueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TableFieldId).HasColumnName("TableFieldID");

                entity.Property(e => e.Value).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
