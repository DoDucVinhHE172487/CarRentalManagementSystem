using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class CarRental
{
    public int RentalId { get; set; }

    public int? CustomerId { get; set; }

    public string? LicensePlates { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<HistoryCarRental> HistoryCarRentals { get; set; } = new List<HistoryCarRental>();

    public virtual Car? LicensePlatesNavigation { get; set; }
}
