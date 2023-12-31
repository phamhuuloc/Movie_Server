using System.ComponentModel.DataAnnotations;

namespace Movie_Server.Models {
    public class MovieInfoModel {
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

        public bool? IsActive { get; set; }

    }
    public class MovieModel {
    
    [Required(ErrorMessage ="Supplier Id is required")]
    public string SupplierId { get; set; } = null!;

    [Required(ErrorMessage ="Title Id is required")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage ="Desc is required")]
    public string Desc { get; set; } = null!;

    [Required(ErrorMessage ="Img is required")]
    public string Img { get; set; } = null!;

    [Required(ErrorMessage ="ImgSm is required")]
    public string ImgSm { get; set; } = null!;

    [Required(ErrorMessage ="Trailer is required")]
    public string Trailer { get; set; } = null!;

    [Required(ErrorMessage ="Video is required")]
    public string Video { get; set; } = null!;

    [Required(ErrorMessage ="Year is required")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Limit is required")]
    public int Limit { get; set; }

    [Required(ErrorMessage ="Price is required")]
    public int Price { get; set; }
    public int Clicked { get; set; }
    public bool? IsSeries { get; set; }

    }
}