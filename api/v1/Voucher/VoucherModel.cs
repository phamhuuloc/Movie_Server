using System.ComponentModel.DataAnnotations;

namespace Movie_Server.Models {
    public class VoucherModel {
    
    [Required(ErrorMessage ="Image Id is required")]
    public string Image { get; set; } = null!;

    [Required(ErrorMessage ="Supplier Name is required")]
    public string? SupplierName { get; set; }

    [Required(ErrorMessage ="Percent Discount is required")]
    [Range(0,100)]
    public double PercentDiscount { get; set; }

    [Required(ErrorMessage ="Description is required")]
    public string? Description { get; set; }

    [Required(ErrorMessage ="Point Cost is required")]
    public double? PointCost { get; set; }
    public bool? IsActive { get; set; }



    }

    
}