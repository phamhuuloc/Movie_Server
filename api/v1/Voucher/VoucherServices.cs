using Movie_Server.Services;
using Movie_Server.Models;
using Movie_Server.Helper;
using Movie_Server.Database.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
       public async Task<ApiResponse> updateVoucherInfo (VoucherModel voucher , string id){
        ApiResponse _response = new ApiResponse();
        try{
            _logger.LogInformation("Update Voucher Info");
            var _voucher = await this._context.Vouchers.FindAsync(id);
            if(_voucher == null){
               _response.responseCode = 404; 
               _response.responseMessage = "Voucher Not Found";
               return _response;
            }
            else {
                _voucher.Image = voucher.Image;
                _voucher.SupplierName = voucher.SupplierName;
                _voucher.PercentDiscount = voucher.PercentDiscount;
                _voucher.Description = voucher.Description;
                _voucher.PointCost = voucher.PointCost;
                _voucher.IsActive = voucher.IsActive;
            //    this._context.Vouchers.Update(_voucher);
                await this._context.SaveChangesAsync();
                _response.responseCode = 200;
                _response.responseMessage = "Update Successfully";
                return _response;    
            }
        }catch(Exception ex){
            _response.responseCode = 500;
            _response.responseMessage = ex.Message;
        }
        return _response;
       }
       public async Task<ApiResponse> getAllVouchers(){
        ApiResponse _response = new ApiResponse();
        try{
            _logger.LogInformation("Get All Vouchers");
            var data = await this._context.Vouchers.ToListAsync();
            if( data != null) {
                     _response.responseCode = 200;
                     _response.responseMessage  = "Get All Supplier Successfully";
                     _response.data = _mapper.Map<List<Voucher> , List<VoucherModel>>(data);
                     return _response;
            }

        }catch(Exception ex){
            _response.responseCode = 500;
            _response.responseMessage = ex.Message;
        }
        return _response;
       }
       public async Task<ApiResponse> getVoucherById(string id){
        ApiResponse _response = new ApiResponse();
        try {
            _logger.LogInformation("Get Voucher By ID");
            Voucher  _voucher = await this._context.Vouchers.FindAsync(id);
            if(_voucher == null){
                _response.responseCode = 404;
                _response.responseMessage = "Voucher Not Found";
                return _response;
            }
            else {
                _response.responseCode = 200;
                _response.responseMessage = "Get Voucher Successfully";
                _response.data = _mapper.Map<Voucher , VoucherModel>(_voucher);
                return _response;
            }


        }catch(Exception ex) {
            _response.responseCode = 500;
            _response.responseMessage =  "Get Voucher By ID Failed";
        }
        return _response;
       }
    }
} 