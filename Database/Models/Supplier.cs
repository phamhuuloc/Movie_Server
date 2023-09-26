using System;
using System.Collections.Generic;

namespace Movie_Server.Database;

public partial class Supplier
{
    public string Id { get; set; } = null!;

    public string SlName { get; set; } = null!;

    public string SlEmail { get; set; } = null!;

    public string SlPhone { get; set; } = null!;

    public string SlAddress { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
