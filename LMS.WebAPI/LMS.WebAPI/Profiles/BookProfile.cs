using AutoMapper;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Models;

namespace LMS.WebAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Models.BookDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Models.BookForCreateAndUpdateDto, Entities.Book>();
            CreateMap<Entities.Book, Models.BookForCreateAndUpdateDto>();
            CreateMap<Models.BookDto, Entities.Book>();

            CreateMap<Entities.Book, Models.BookDto>()
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ForMember(dest => dest.AverageRating, opt => opt.Ignore()); // ignore mapping average review, it will be handeled manually

        }
    }
}
