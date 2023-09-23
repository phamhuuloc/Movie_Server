﻿using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class Vnpay
{
    public int VnpayId { get; set; }

    public string? VnpAmount { get; set; }

    public string? VnpBankCode { get; set; }

    public string? VnpBankTranNo { get; set; }

    public string? VnpCardType { get; set; }

    public string? VnpOrderInfo { get; set; }

    public string? VnpTransactionNo { get; set; }

    public string? VnpTmnCode { get; set; }

    public string? VnpPayDate { get; set; }

    public DateTime CreateAt { get; set; }
}
