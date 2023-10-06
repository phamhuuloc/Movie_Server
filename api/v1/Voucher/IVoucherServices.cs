using Movie_Server.Helper;
using Movie_Server.Models;

namespace Movie_Server.Services {
    public interface IVoucherServices {
        Task<ApiResponse> createNewVoucher(VoucherModel voucher);
        Task<ApiResponse> updateVoucherInfo(VoucherModel voucher, string id );
        Task<ApiResponse> getAllVouchers();
        Task<ApiResponse> getVoucherById(string id);
    }
} 