using Movie_Server.Container;
using Movie_Server.Helper;
using Movie_Server.Models;

namespace Movie_Server.Services {
        public interface IAuthorizeServices  {
            Task<ApiResponse> Register(AuthorizeModel request);
            Task<ApiResponse> Login(AuthorizeModel request);
            
        }
}
