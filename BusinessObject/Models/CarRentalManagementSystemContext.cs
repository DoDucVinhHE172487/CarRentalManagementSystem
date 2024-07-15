using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.Models;

public partial class CarRentalManagementSystemContext : DbContext
{
    public CarRentalManagementSystemContext()
    {
    }

    public CarRentalManagementSystemContext(DbContextOptions<CarRentalManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarRental> CarRentals { get; set; }

    public virtual DbSet<CarStatus> CarStatuses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<HistoryCarRental> HistoryCarRentals { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;database=CarRentalManagementSystem;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Car__68A0342E86A67030");

            entity.ToTable("Car");

            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.CarName).HasMaxLength(80);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.Fuel).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RentalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CarStatus).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarStatusId)
                .HasConstraintName("FK__Car__CarStatusId__3E52440B");
        });

        modelBuilder.Entity<CarRental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__CarRenta__970059439AD82F2F");

            entity.ToTable("CarRental");

            entity.Property(e => e.CarPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.Car).WithMany(p => p.CarRentals)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarRental__CarId__4222D4EF");

            entity.HasOne(d => d.Customer).WithMany(p => p.CarRentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CarRental__Custo__412EB0B6");
        });

        modelBuilder.Entity<CarStatus>(entity =>
        {
            entity.HasKey(e => e.CarStatusId).HasName("PK__CarStatu__4A328CC6E7D60F74");

            entity.ToTable("CarStatus");

            entity.Property(e => e.CarStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D85C50F824");

            entity.ToTable("Customer");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<HistoryCarRental>(entity =>
        {
            entity.HasKey(e => e.HistoryCarRentalId).HasName("PK__HistoryC__897732B241A70527");

            entity.ToTable("HistoryCarRental");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.Rental).WithMany(p => p.HistoryCarRentals)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("FK__HistoryCa__Renta__44FF419A");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB17A36560EA");

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D105346F361B8A").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StaffName).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
