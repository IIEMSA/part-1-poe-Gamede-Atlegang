using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventEaseWebApp.Models;

public partial class Booking
{
    [Key]
    [Column("bookingID")]
    public int BookingId { get; set; }

    [Column("venueID")]
    public int? VenueId { get; set; }

    [Column("eventID")]
    public int? EventId { get; set; }

    [Column("bookingDate")]
    public DateTime BookingDate { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("Bookings")]
    public virtual Events? Event { get; set; }

    [ForeignKey("VenueId")]
    [InverseProperty("Bookings")]
    public virtual Venue? Venue { get; set; }
}
