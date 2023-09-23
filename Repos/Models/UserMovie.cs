using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class UserMovie
{
    public int Id { get; set; }

    public int UmUserId { get; set; }

    public int UmMovieId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Movie UmMovie { get; set; } = null!;

    public virtual User UmUser { get; set; } = null!;
}
