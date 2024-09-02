using AutoMapper;

namespace LMS.WebAPI.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Entities.Review, Models.ReviewDto>()
                .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src =>
                    $"{src.User.FirstName} {(string.IsNullOrEmpty(src.User.MiddleName) ? "" : src.User.MiddleName + " ")}{src.User.LastName}"));

            CreateMap<Models.ReviewDto, Entities.Review>();
            CreateMap<Models.ReviewForCreateAndUpdateDto, Entities.Review>();
            CreateMap<Entities.Review, Models.ReviewForCreateAndUpdateDto>();
        }
    }
}
