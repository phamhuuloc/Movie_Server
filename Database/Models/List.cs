﻿using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class List
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ICollection<ListMovie> ListMovies { get; set; } = new List<ListMovie>();
}
