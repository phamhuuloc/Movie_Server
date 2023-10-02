using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class Refreshtoken
{
    public string UserId { get; set; } = null!;

    public string? TokenId { get; set; }

    public string? RefreshToke { get; set; }
}
