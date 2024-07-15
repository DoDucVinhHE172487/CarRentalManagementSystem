using System;
using System.Collections.Generic;

namespace CarRentalManagementSystem.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string CarName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int NumberOfSeats { get; set; }

    public string Status { get; set; } = null!;

    public string Fuel { get; set; } = null!;

    public virtual ICollection<CarBooking> CarBookings { get; set; } = new List<CarBooking>();
}
