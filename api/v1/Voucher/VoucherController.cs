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
        [HttpGet("GetAll")]
        public  async Task<IActionResult> getAllVouchers () {
           var data = await this._services.getAllVouchers();
           return Ok(data);
        }
        [HttpGet("GetById")]
        public  async Task<IActionResult> getVoucherById (string id) {
           var data = await this._services.getVoucherById(id);
           return Ok(data);
        }

        [HttpPost("Create")]
        public  async Task<IActionResult> createNewVoucher (VoucherModel voucher) {
           var data = await this._services.createNewVoucher(voucher);
           return Ok(data);
        }  
        [HttpPut("Update")]
        public  async Task<IActionResult> updateVoucher (VoucherModel voucher,string id) {
           var data = await this._services.updateVoucherInfo(voucher,  id);
           return Ok(data);
        }
    }
}