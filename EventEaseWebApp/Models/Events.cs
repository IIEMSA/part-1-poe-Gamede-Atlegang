using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventEaseWebApp.Models;

[Table("Event")]
public partial class Events
{
    [Key]
    [Column("eventID")]
    public int EventId { get; set; }

    [Column("venueID")]
    public int? VenueId { get; set; }

    [Column("eventName")]
    [StringLength(100)]
    [Unicode(false)]
    public string EventName { get; set; } = null!;

    [Column("eventDate")]
    public DateTime EventDate { get; set; }

    [Column("description")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }
    [InverseProperty("Event")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("VenueId")]
    [InverseProperty("Events")]
    public virtual Venue? Venue { get; set; }
}
