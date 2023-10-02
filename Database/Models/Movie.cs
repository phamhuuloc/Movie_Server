using System;
using System.Collections.Generic;

namespace Movie_Server.Database.Models;

public partial class Movie
{
    public string Id { get; set; } = null!;

    public string SupplierId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public string Img { get; set; } = null!;

    public string ImgSm { get; set; } = null!;

    public string Trailer { get; set; } = null!;

    public string Video { get; set; } = null!;

    public int Year { get; set; }

    public int Limit { get; set; }

    public int Price { get; set; }

    public int Clicked { get; set; }

    public bool? IsSeries { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<ListMovie> ListMovies { get; set; } = new List<ListMovie>();

    public virtual ICollection<MovieCategoty> MovieCategoties { get; set; } = new List<MovieCategoty>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<UserFavourite> UserFavourites { get; set; } = new List<UserFavourite>();

    public virtual ICollection<UserMovie> UserMovies { get; set; } = new List<UserMovie>();
}
