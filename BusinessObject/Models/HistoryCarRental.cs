using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class HistoryCarRental
{
    public int HistoryCarRentalId { get; set; }

    public int? RentalId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? ActualReturnTime { get; set; }

    public decimal TotalPrice { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual CarRental? Rental { get; set; }
}
