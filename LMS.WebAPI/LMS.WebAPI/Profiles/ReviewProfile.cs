using AutoMapper;

namespace LMS.WebAPI.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Entities.Review, Models.ReviewDto>()
                .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
        }
    }
}
