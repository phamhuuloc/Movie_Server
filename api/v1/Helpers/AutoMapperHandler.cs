using AutoMapper;
using Movie_Server.Models;
using Movie_Server.Database;
using Movie_Server.Database.Models;
namespace Movie_Server.Helper {
    public class AutoMapperHandler : Profile {
       public AutoMapperHandler () {
        CreateMap<User, UserModel>() ;
        CreateMap<AuthorizeModel, User>()
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            );
        CreateMap<UserCreateModel, User>()
            .ForMember(
                dest => dest.Username, 
                opt => opt.MapFrom(src => src.Username)
            ).ForMember(
                dest => dest.Email, 
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            ).ForMember(
                dest => dest.WalletBalance,
                opt => opt.MapFrom(src => src.WalletBalance)
            ).ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone)
            ).ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => src.IsActive)
            );
        CreateMap<UserUpdateModel, User>()
            .ForMember(
                dest => dest.Username, 
                opt => opt.MapFrom(src => src.Username)
            ).ForMember(
                dest => dest.Password, 
                opt => opt.MapFrom(src => src.Password)
            ).ForMember(
                dest => dest.ProfilePic,
                opt => opt.MapFrom(src => src.ProfilePic)
            ).ForMember(
                dest => dest.WalletBalance,
                opt => opt.MapFrom(src => src.WalletBalance)
            ).ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone)
            ).ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => src.IsActive)
            );

        CreateMap<Supplier, SupplierModel>() ;
        CreateMap<SupplierCreateModel, Supplier>()
            .ForMember(
                dest => dest.SlName, 
                opt => opt.MapFrom(src => src.SlName)
            ).ForMember(
                dest => dest.SlEmail, 
                opt => opt.MapFrom(src => src.SlEmail)
            ).ForMember(
                dest => dest.SlPhone, 
                opt => opt.MapFrom(src => src.SlPhone)
            ).ForMember(
                dest => dest.SlAddress,
                opt => opt.MapFrom(src => src.SlAddress)
            );

            CreateMap<SupplierUpdateModel, Supplier>()
            .ForMember(
                dest => dest.SlName, 
                opt => opt.MapFrom(src => src.SlName)
            ).ForMember(
                dest => dest.SlEmail, 
                opt => opt.MapFrom(src => src.SlPhone)
            ).ForMember(
                dest => dest.SlPhone, 
                opt => opt.MapFrom(src => src.SlPhone)
            ).ForMember(
                dest => dest.SlAddress,
                opt => opt.MapFrom(src => src.SlAddress)
            );
        CreateMap<Movie , MovieInfoModel>();
        CreateMap<Movie , MovieModel>();
        
        CreateMap<MovieModel , Movie>()
            .ForMember(
                dest => dest.SupplierId,
                opt => opt.MapFrom(src => src.SupplierId)
            ).ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Title)
            ).ForMember(
                dest => dest.Desc,
                opt => opt.MapFrom(src => src.Desc)
            ).ForMember(
                dest => dest.Img,
                opt => opt.MapFrom(src => src.Img)
            ).ForMember(
                dest => dest.ImgSm,
                opt => opt.MapFrom(src => src.ImgSm)
            ).ForMember(
                dest => dest.Trailer,
                opt => opt.MapFrom(src => src.Trailer)
            ).ForMember(
                dest => dest.Video,
                opt => opt.MapFrom(src => src.Video)
            ).ForMember(
                dest => dest.Year,
                opt => opt.MapFrom(src => src.Year)
            ).ForMember(
                dest => dest.Limit,
                opt => opt.MapFrom(src => src.Limit)
            ).ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price)
            ).ForMember(
                dest => dest.Clicked,
                opt => opt.MapFrom(src => src.Clicked)
            ).ForMember(
                dest => dest.IsSeries,
                opt => opt.MapFrom(src => src.IsSeries)
            );
            CreateMap<MovieCategoryModel , MovieCategory>()
            .ForMember(
                dest => dest.MvMovieId,
                opt => opt.MapFrom(src => src.MvMovieId)
            ).ForMember(
                dest => dest.MvCateId,
                opt => opt.MapFrom(src => src.MvCateId)
            );

            CreateMap<Voucher, VoucherModel>();
            CreateMap<VoucherModel, Voucher>()
            .ForMember(
                dest => dest.Image, 
                opt => opt.MapFrom(src => src.Image)
            ).ForMember(
                dest => dest.SupplierName, 
                opt => opt.MapFrom(src => src.SupplierName)
            ).ForMember(
                dest => dest.PercentDiscount, 
                opt => opt.MapFrom(src => src.PercentDiscount)
            ).ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            ).ForMember(
                dest => dest.PointCost,
                opt => opt.MapFrom(src => src.PointCost)
            ).ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => src.IsActive)
            );
 
            CreateMap<List, ListModel>();
            CreateMap<MovieListModel ,ListMovie>()
            .ForMember(
                dest => dest.LmListId,
                opt => opt.MapFrom(src => src.LmListId)
            ).ForMember(
                dest => dest.LmMovieId,
                opt => opt.MapFrom(src => src.LmMovieId)
            );

            CreateMap<ListMovieCreateModel, List>()
            .ForMember(
                dest => dest.Title, 
                opt => opt.MapFrom(src => src.Title)
            ).ForMember(
                dest => dest.Type, 
                opt => opt.MapFrom(src => src.Type)
            ).ForMember(
                dest => dest.Description, 
                opt => opt.MapFrom(src => src.Description)
            );           
       }
    }
}