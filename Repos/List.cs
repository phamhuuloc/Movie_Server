using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class List
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ICollection<ListMovie> ListMovies { get; set; } = new List<ListMovie>();
}
