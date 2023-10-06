using System.ComponentModel.DataAnnotations;

namespace Movie_Server.Models {
    public class ListModel {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
    public  class ListMovieCreateModel {
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage ="Type is required")]
        public string Type { get; set; } = null!;

        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; } = null!;
        
    }
}