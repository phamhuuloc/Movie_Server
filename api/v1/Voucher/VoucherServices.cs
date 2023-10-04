using Movie_Server.Services;
using Movie_Server.Models;
using Movie_Server.Helper;
using Movie_Server.Database.Models;
using AutoMapper;
namespace Movie_Server.Container {
    public class VoucherServices : IVoucherServices {
        private readonly MovieserverContext _context;
        private readonly Mapper _mapper;
        private readonly ILogger<IVoucherServices> _logger;

        public VoucherServices (MovieserverContext context , IMapper mapper , ILogger<IVoucherServices> voucher) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
            this._logger = voucher;
        }
       public async Task<ApiResponse> createNewVoucher(VoucherModel voucher) {
        ApiResponse _response = new ApiResponse();
        try{
            _logger.LogInformation("Create New Voucher");
            Voucher _voucher = _mapper.Map<Voucher>(voucher);
            _voucher.Id = Guid.NewGuid().ToString();
            await this._context.Vouchers.AddAsync(_voucher);
            await this._context.SaveChangesAsync();
            _response.responseCode = 201;
            _response.responseMessage = "Create New Voucher Successfully";

        }catch(Exception ex) {
            _response.responseCode = 500;
            _response.responseMessage = ex.Message;
        }
        return _response;

       } 

    }
} 