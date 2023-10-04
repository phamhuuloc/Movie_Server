using Movie_Server.Helper;
using Movie_Server.Models;

namespace Movie_Server.Services {
    public interface IVoucherServices {
        Task<ApiResponse> createNewVoucher(VoucherModel voucher);
    }
} 