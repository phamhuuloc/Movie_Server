using System;
using System.Collections.Generic;

namespace Movie_Server.Database;

public partial class Voucher
{
    public string Id { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string? SupplierName { get; set; }

    public double PercentDiscount { get; set; }

    public string? Description { get; set; }

    public double? PointCost { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
}
