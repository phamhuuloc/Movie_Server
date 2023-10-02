using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class UserFavourite
{
    public string Id { get; set; } = null!;

    public string UfUserId { get; set; } = null!;

    public string UfMovieId { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual Movie UfMovie { get; set; } = null!;

    public virtual User UfUser { get; set; } = null!;
}
