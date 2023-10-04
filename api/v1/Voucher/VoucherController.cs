using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Server.Services;
using Movie_Server.Models;
using Movie_Server.Helper;

namespace Movie_Server.Controllers {
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase {
        private readonly IVoucherServices _services;
        public VoucherController(IVoucherServices services) {
            this._services = services;
        }
        [HttpPost("Create")]
        public  async Task<IActionResult> createNewVoucher (VoucherModel voucher) {
           var data = await this._services.createNewVoucher(voucher);
           return Ok(data);
        }  


    }
}