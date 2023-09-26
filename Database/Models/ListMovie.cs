using System;
using System.Collections.Generic;

namespace Movie_Server.Database;

public partial class ListMovie
{
    public string Id { get; set; } = null!;

    public string LmListId { get; set; } = null!;

    public string LmMovieId { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual List LmList { get; set; } = null!;

    public virtual Movie LmMovie { get; set; } = null!;
}
