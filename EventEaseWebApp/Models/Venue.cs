using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventEaseWebApp.Models;

[Table("Venue")]
public partial class Venue
{
    [Key]
    [Column("venueID")]
    public int VenueId { get; set; }

    [Column("venueName")]
    [StringLength(100)]
    [Unicode(false)]
    public string VenueName { get; set; } = null!;

    [Column("location")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column("capacity")]
    public int? Capacity { get; set; }

    [Column("imageURL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [InverseProperty("Venue")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Venue")]
    public virtual ICollection<Events> Events { get; set; } = new List<Events>();
}
