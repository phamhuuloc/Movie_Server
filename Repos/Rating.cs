using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class Rating
{
    public int Id { get; set; }

    public int? RNumberStar { get; set; }

    public int RUserId { get; set; }

    public int RMovieId { get; set; }

    public double Price { get; set; }

    public string? RContent { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Movie RMovie { get; set; } = null!;

    public virtual User RUser { get; set; } = null!;
}
