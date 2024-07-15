using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string CarName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime? DateCar { get; set; }

    public string Color { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int NumberOfSeats { get; set; }

    public int? CarStatusId { get; set; }

    public string Fuel { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public decimal RentalPrice { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CarRental> CarRentals { get; set; } = new List<CarRental>();

    public virtual CarStatus? CarStatus { get; set; }
}
