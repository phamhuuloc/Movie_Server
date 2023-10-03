using Movie_Server.Helper;
using Movie_Server.Models;

namespace  Movie_Server.Services {
    public interface ISupplierServices {
         Task<ApiResponse>getAllSuppliers(); 
         Task<ApiResponse> createNewSupplier(SupplierCreateModel supplier); 
         Task<ApiResponse> updateSupplierInfo (SupplierUpdateModel supplier , string id);
    }

}