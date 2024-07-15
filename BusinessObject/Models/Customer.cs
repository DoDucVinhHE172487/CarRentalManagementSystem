using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CarRental> CarRentals { get; set; } = new List<CarRental>();
}
