using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Models;

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

    public virtual DbSet<CarBooking> CarBookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Itinerary> Itineraries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;database=CarRentalManagementSystem;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Car__68A0342E18355BB1");

            entity.ToTable("Car");

            entity.Property(e => e.CarId).ValueGeneratedNever();
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.CarName).HasMaxLength(255);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Fuel).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<CarBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__CarBooki__73951AEDB553EA97");

            entity.ToTable("CarBooking");

            entity.Property(e => e.BookingId).ValueGeneratedNever();
            entity.Property(e => e.CarPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.RentalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.CarBookings)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarBookin__CarId__3B75D760");

            entity.HasOne(d => d.Customer).WithMany(p => p.CarBookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CarBookin__Custo__3A81B327");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8F5C7B780");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Itinerary>(entity =>
        {
            entity.HasKey(e => e.ItineraryId).HasName("PK__Itinerar__361216C6A48F029F");

            entity.ToTable("Itinerary");

            entity.Property(e => e.ItineraryId).ValueGeneratedNever();
            entity.Property(e => e.ActualReturnTime).HasColumnType("datetime");
            entity.Property(e => e.AmountDue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BookingTime).HasColumnType("datetime");
            entity.Property(e => e.ReturnTime).HasColumnType("datetime");

            entity.HasOne(d => d.Booking).WithMany(p => p.Itineraries)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Itinerary__Booki__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
