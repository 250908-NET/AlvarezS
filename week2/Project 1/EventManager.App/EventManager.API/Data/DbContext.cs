using Microsoft.EntityFrameworkCore;
using EventManager.Models;

namespace EventManager.Data;

public class EventManagerDbContext : DbContext
{
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventAttendee> EventAttendees { get; set; }
    
    public EventManagerDbContext( DbContextOptions<EventManagerDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<EventAttendee>()
            .HasKey(ea => new { ea.EventId, ea.AttendeeId });

        modelBuilder.Entity<EventAttendee>()
            .HasOne(ea => ea.Event)
            .WithMany(e => e.EventAttendees)
            .HasForeignKey(ea => ea.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventAttendee>()
            .HasOne(ea => ea.Attendee)
            .WithMany(a => a.EventAttendees)
            .HasForeignKey(ea => ea.AttendeeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Attendee>()
            .HasIndex(a => a.Email)
            .IsUnique();
    }
}