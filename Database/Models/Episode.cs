using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class Episode
{
    public string Id { get; set; } = null!;

    public int EpMovieId { get; set; }

    public string? EpLinkMovie { get; set; }

    public int EpNumber { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
