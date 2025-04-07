using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventEaseWebApp.Models;

public partial class EventEaseContext : DbContext
{
    public EventEaseContext()
    {
    }

    public EventEaseContext(DbContextOptions<EventEaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Events> Events { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
        if (!optionsBuilder.IsConfigured)
        {
         
            optionsBuilder.UseSqlServer("YourLocalFallbackConnectionStringIfNeeded");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__C6D03BEDEEC29986");

            entity.Property(e => e.BookingId).ValueGeneratedNever();

            entity.HasOne(d => d.Event).WithMany(p => p.Bookings).HasConstraintName("FK__Bookings__eventI__4F7CD00D");

            entity.HasOne(d => d.Venue).WithMany(p => p.Bookings).HasConstraintName("FK__Bookings__venueI__4E88ABD4");
        });

        modelBuilder.Entity<Events>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__2DC7BD6977111206");

            entity.Property(e => e.EventId).ValueGeneratedNever();

            entity.HasOne(d => d.Venue).WithMany(p => p.Events).HasConstraintName("FK__Event__venueID__4BAC3F29");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venue__4DDFB71F493AA4C1");

            entity.Property(e => e.VenueId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
