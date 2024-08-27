using AutoMapper;

namespace LMS.WebAPI.Profiles
{

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.CategoryDto, Entities.Category>();
            CreateMap<Entities.Category, Models.CategoryDto>();
        }
    }
}
