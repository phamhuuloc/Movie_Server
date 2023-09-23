using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class UserFavourite
{
    public int Id { get; set; }

    public int UfUserId { get; set; }

    public int UfMovieId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Movie UfMovie { get; set; } = null!;

    public virtual User UfUser { get; set; } = null!;
}
