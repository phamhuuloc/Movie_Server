using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class UserVoucher
{
    public string Id { get; set; } = null!;

    public string UvUserId { get; set; } = null!;

    public string UvVoucherId { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual User UvUser { get; set; } = null!;

    public virtual Voucher UvVoucher { get; set; } = null!;
}
