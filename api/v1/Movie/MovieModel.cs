using System.ComponentModel.DataAnnotations;

namespace Movie_Server.Models {
    public class MovieCreateModel {
    
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

    }
}