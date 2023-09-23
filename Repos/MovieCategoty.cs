using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class MovieCategoty
{
    public int Id { get; set; }

    public int MvMovieId { get; set; }

    public int MvCateId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Category MvCate { get; set; } = null!;

    public virtual Movie MvMovie { get; set; } = null!;
}
