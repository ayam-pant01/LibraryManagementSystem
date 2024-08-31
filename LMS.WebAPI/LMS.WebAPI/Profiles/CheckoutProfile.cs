using AutoMapper;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Models;

namespace LMS.WebAPI.Profiles
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<Checkout, CheckoutDto>()
                .ForMember(dest => dest.NumberOfBooks, opt => opt.MapFrom(src => src.CheckoutDetails.Count))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => 
                    $"{src.User.FirstName} {(string.IsNullOrEmpty(src.User.MiddleName) ? "" : src.User.MiddleName + " ")}{src.User.LastName}"));
            CreateMap<CheckoutDetail, CheckoutDetailDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.IsReturned, opt => opt.MapFrom(src => src.ReturnedDate != null));
            CreateMap<Checkout, UserCheckoutDto>()
              .ForMember(dest => dest.NumberOfBooks, opt => opt.MapFrom(src => src.CheckoutDetails.Count));
        }
    }
}
