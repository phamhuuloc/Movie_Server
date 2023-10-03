using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class UserMovie
{
    public string Id { get; set; } = null!;

    public string UmUserId { get; set; } = null!;

    public string UmMovieId { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual Movie UmMovie { get; set; } = null!;

    public virtual User UmUser { get; set; } = null!;
}
