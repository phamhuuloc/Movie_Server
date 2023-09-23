using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class UserVoucher
{
    public int Id { get; set; }

    public int UvUserId { get; set; }

    public int UvVoucherId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual User UvUser { get; set; } = null!;

    public virtual Voucher UvVoucher { get; set; } = null!;
}
