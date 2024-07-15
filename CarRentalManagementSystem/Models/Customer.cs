using System;
using System.Collections.Generic;

namespace CarRentalManagementSystem.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<CarBooking> CarBookings { get; set; } = new List<CarBooking>();
}
