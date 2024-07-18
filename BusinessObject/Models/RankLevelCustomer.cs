using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class RankLevelCustomer
{
    public int RankLevel { get; set; }

    public string? RankLevelName { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
