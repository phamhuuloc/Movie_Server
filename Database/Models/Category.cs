using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class Category
{
    public string Id { get; set; } = null!;

    public string CateName { get; set; } = null!;

    public int CateType { get; set; }

    public DateTime CreateAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
}
