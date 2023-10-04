using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Movie_Server.Models {
    public class SupplierModel  {
        public string Id { get; set; } = null!;

        public string SlName { get; set; } = null!;

        public string SlEmail { get; set; } = null!;

        public string SlPhone { get; set; } = null!;

        public string SlAddress { get; set; } = null!;

        public DateTime CreateAt { get; set; }
 
    }
    public class SupplierCreateModel {
        public string SlName { get; set; } = null!;

        public string SlEmail { get; set; } = null!;

        public string SlPhone { get; set; } = null!;

        public string SlAddress { get; set; } = null!;

 
    }
    public class SupplierUpdateModel {

        [Required(ErrorMessage ="Supplier Name is required")]
        public string SlName { get; set; } = null!;

        [Required(ErrorMessage ="Supplier Email is required")]
        [EmailAddress(ErrorMessage ="Supplier Email is not valid")]
        public string SlEmail { get; set; } = null!;

        [Required(ErrorMessage ="Supplier Phone is required")]
        [Phone(ErrorMessage ="Supplier Phone is not valid")]
        public string SlPhone { get; set; } = null!;

        [Required(ErrorMessage ="Supplier Address is required")]
        public string SlAddress { get; set; } = null!;

    }
}