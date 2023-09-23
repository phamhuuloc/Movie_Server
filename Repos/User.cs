﻿using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfilePic { get; set; }

    public double? WalletBalance { get; set; }

    public double? Point { get; set; }

    public double? MoneySpended { get; set; }

    public string? Phone { get; set; }

    public bool? IsAdmin { get; set; }

    public string? FaceId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<UserFavourite> UserFavourites { get; set; } = new List<UserFavourite>();

    public virtual ICollection<UserMovie> UserMovies { get; set; } = new List<UserMovie>();

    public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
}
