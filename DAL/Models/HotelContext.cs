using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\פרויקטטטטטט\\data\\HotelData.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC272F8731B8");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EmployeeJob)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Employees)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_ToTable");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guest__3214EC2775E47E6E");

            entity.ToTable("Guest");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.GuestName)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.GuestPhone)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotel__3214EC07E76594F0");

            entity.ToTable("Hotel");

            entity.Property(e => e.HotelCantury)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HotelDescribe)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HotelLocation)
                .HasMaxLength(25)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HotelName)
                .HasMaxLength(25)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HotelRating).HasDefaultValueSql("((2))");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC27B5853100");

            entity.ToTable("Reservation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CheckIn).HasColumnType("datetime");
            entity.Property(e => e.CheckOut).HasColumnType("datetime");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_ToTable");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_ToTable_1");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC07727564F9");

            entity.ToTable("Room");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
