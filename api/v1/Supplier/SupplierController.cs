using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Services;

namespace Movie_Server.Controllers {
    // [EnableRateLimiting("fixedwindow")]
    [Route("api/v1/[controller]")]
    [ApiController]

   public class SupplierController : ControllerBase {
       private readonly ISupplierServices services;
       public SupplierController(ISupplierServices services) {
        this.services = services;
       }
 
       [HttpPost("Create")]
       public async Task<IActionResult> createNewSupplier(SupplierCreateModel supplier) {
             var data =  await this.services.createNewSupplier(supplier);
             return Ok(data);
       }
    [HttpPost("Update")]
       public async Task<IActionResult> updateSupplierInfo(SupplierUpdateModel supplier, string id) {
             var data =  await this.services.updateSupplierInfo(supplier, id);
             return Ok(data);
       }


   } 
}