using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class ListMovie
{
    public int Id { get; set; }

    public int LmListId { get; set; }

    public int LmMovieId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual List LmList { get; set; } = null!;

    public virtual Movie LmMovie { get; set; } = null!;
}
