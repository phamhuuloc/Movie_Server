using System;
using System.Collections.Generic;

namespace Movie_Server.Repos;

public partial class Category
{
    public int Id { get; set; }

    public string CateName { get; set; } = null!;

    public int CateType { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<MovieCategoty> MovieCategoties { get; set; } = new List<MovieCategoty>();
}
