using System;
using System.Collections.Generic;

namespace CarRentalManagementSystem.Models;

public partial class CarBooking
{
    public int BookingId { get; set; }

    public int? CustomerId { get; set; }

    public int? CarId { get; set; }

    public decimal CarPrice { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal RentalPrice { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Itinerary> Itineraries { get; set; } = new List<Itinerary>();
}
