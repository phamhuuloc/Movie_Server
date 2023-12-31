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
        public async Task<ApiResponse> getAllSuppliers() {
            ApiResponse _response = new ApiResponse();
             try { 
                _logger.LogInformation("Get All Suppliers Starting");
                List<SupplierModel>  listSuppliers = new List<SupplierModel>();
                var data = await this._context.Suppliers.ToListAsync();
                if( data != null) {
                     _response.responseCode = 200;
                     _response.responseMessage  = "Get All Supplier Successfully";
                     _response.data = _mapper.Map<List<Supplier> , List<SupplierModel>>(data);
                     return _response;
                }

             }catch (Exception ex) {
                _response.responseCode = 500;
                _response.responseMessage = ex.Message;
             }
             return _response;
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
                bool isEmilValid = Regex.IsMatch(supplier.SlEmail, @"^[a-zA-Z0-9._%+-]+@gmail\.com$");
                var _supplier =  await this._context.Suppliers.FindAsync(id);
                if(isValidPhoneNumber == false) {
                    _response.responseCode = 400;
                    _response.responseMessage = "Phone number is not valid";
                   return _response; 
                }
                else if(isEmilValid == false){
                    _response.responseCode = 400;
                    _response.responseMessage = "Email is not valid";
                    return _response;
                }
                else if (_supplier != null){
                    _supplier.SlName = supplier.SlName;
                    _supplier.SlPhone = supplier.SlPhone;
                    _supplier.SlEmail = supplier.SlEmail;
                    _supplier.SlAddress = supplier.SlAddress; 
                    await this._context.SaveChangesAsync();
                    _response.responseCode = 201;
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