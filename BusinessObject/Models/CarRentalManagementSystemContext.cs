using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models;

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
            entity.HasKey(e => e.LicensePlates).HasName("PK__Car__AE763D174D0D0835");

            entity.ToTable("Car");

            entity.Property(e => e.LicensePlates).HasMaxLength(50);
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.CarName).HasMaxLength(80);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.Fuel).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RentalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CarStatus).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarStatusId)
                .HasConstraintName("FK__Car__CarStatusId__2B3F6F97");
        });

        modelBuilder.Entity<CarRental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__CarRenta__97005943F8BB6DC7");

            entity.ToTable("CarRental");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("createdBy");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.LicensePlates).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.Customer).WithMany(p => p.CarRentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CarRental__Custo__2E1BDC42");

            entity.HasOne(d => d.LicensePlatesNavigation).WithMany(p => p.CarRentals)
                .HasForeignKey(d => d.LicensePlates)
                .HasConstraintName("FK__CarRental__Licen__2F10007B");
        });

        modelBuilder.Entity<CarStatus>(entity =>
        {
            entity.HasKey(e => e.CarStatusId).HasName("PK__CarStatu__4A328CC6BA0FE2AC");

            entity.ToTable("CarStatus");

            entity.Property(e => e.CarStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8B766A753");

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
            entity.HasKey(e => e.HistoryCarRentalId).HasName("PK__HistoryC__897732B21A4C2CE6");

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
                .HasConstraintName("FK__HistoryCa__Renta__31EC6D26");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB17D2D3F464");

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D1053421DD2E76").IsUnique();

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
