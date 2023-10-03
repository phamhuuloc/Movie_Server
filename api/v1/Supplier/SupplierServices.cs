using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movie_Server.Helper;
using Movie_Server.Models;
using Movie_Server.Database;
using Movie_Server.Services;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Cors;
using Movie_Server.Database.Models;


namespace Movie_Server.Container  {
    public class SupplierServices : ISupplierServices {
        private readonly MovieserverContext _context;
        private readonly Mapper _mapper;
        private readonly ILogger<SupplierServices> _logger;
        public SupplierServices(MovieserverContext context, IMapper mapper, ILogger<SupplierServices> logger) {
            this._context = context;
            this._mapper = (Mapper?)mapper;
            this._logger = logger;
        }
       public async Task<ApiResponse> createNewSupplier(SupplierCreateModel supplier) {
            _logger.LogInformation("Create A  New Supplier Starting");   
            ApiResponse _response = new ApiResponse(); 
            try {
                var isExit =  await this._context.Suppliers.AnyAsync( s => s.SlEmail == supplier.SlEmail);
                bool isValidGmail = Regex.IsMatch(supplier.SlEmail, @"^[a-zA-Z0-9._%+-]+@gmail\.com$");
                bool isValidPhoneNumber = Regex.IsMatch(supplier.SlPhone, @"^[0-9]{10}$");
                if (isValidGmail == false) {
                    _response.responseCode = 400;
                    _response.responseMessage = "Email is not valid";
                    return _response;
                }
                else if (isValidPhoneNumber == false) {
                     _response.responseCode = 400;
                    _response.responseMessage = "Phone number is not valid!";
                    return _response;
                }
                else if (isExit == true){
                    _response.responseCode = 404;
                    _response.responseMessage = "Supplier already exists";
                    _response.data = null;
                    return _response;
                }
                else{
                    Supplier _supplier = _mapper.Map<SupplierCreateModel, Supplier>(supplier);
                    _supplier.Id = Guid.NewGuid().ToString();
                    await this._context.Suppliers.AddAsync(_supplier);
                    await this._context.SaveChangesAsync();
                    _response.responseCode = 200;
                    _response.responseMessage = "Create Successfully";
                    _response.data = null;
                    return _response;
                }
            }catch(Exception ex) {
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
                _response.data = null;
            }
            return _response;
       } 
       public  async Task<ApiResponse> updateSupplierInfo (SupplierUpdateModel supplier, string id) {
          _logger.LogInformation("Update supplier starting");
            ApiResponse _response = new ApiResponse(); 
          try{
                bool isValidPhoneNumber = Regex.IsMatch(supplier.SlPhone, @"^[0-9]{10}$");
                var SupplierInfo =  await this._context.Suppliers.FindAsync(id);
                if(isValidPhoneNumber == false) {
                    _response.responseCode = 400;
                    _response.responseMessage = "Phone number is not valid";
                   return _response; 
                }
                else if (SupplierInfo != null){
                    Supplier _supplier = _mapper.Map<SupplierUpdateModel, Supplier>(supplier);
                    await this._context.SaveChangesAsync();
                    _response.responseCode = 200;
                    _response.responseMessage = "Update Successfully";
                    _response.data = null;
                    return _response;
                }
          }catch(Exception ex){
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
                _response.data = null;

          }
          return _response;
       }
       
    }
}