using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class MovieCategoty
{
    public string Id { get; set; } = null!;

    public string MvMovieId { get; set; } = null!;

    public string MvCateId { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual Category MvCate { get; set; } = null!;

    public virtual Movie MvMovie { get; set; } = null!;
}
