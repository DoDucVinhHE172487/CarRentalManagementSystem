using System;
using System.Collections.Generic;

namespace CarRentalManagementSystem.Models;

public partial class Itinerary
{
    public int ItineraryId { get; set; }

    public int? BookingId { get; set; }

    public DateTime BookingTime { get; set; }

    public DateTime ReturnTime { get; set; }

    public DateTime? ActualReturnTime { get; set; }

    public decimal AmountDue { get; set; }

    public virtual CarBooking? Booking { get; set; }
}
