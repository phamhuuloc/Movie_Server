using System;
using System.Collections.Generic;

namespace Movie_Server.Database;

public partial class Rating
{
    public string Id { get; set; } = null!;

    public int? RNumberStar { get; set; }

    public string RUserId { get; set; } = null!;

    public string RMovieId { get; set; } = null!;

    public double Price { get; set; }

    public string? RContent { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Movie RMovie { get; set; } = null!;

    public virtual User RUser { get; set; } = null!;
}
