using AutoMapper;
using Sample.Application.Category.GetAllUseCase;
using Sample.Database.Entities;

namespace Sample.Database.AutoMapper.Profiles
{
    public class DBToApplicationProfile : Profile
    {
        public DBToApplicationProfile()
        {
            CreateMap<Category, CategoryItem>();
            CreateMap<Category, Application.Category.Category>().ReverseMap();
            CreateMap<Attribute, Application.Category.CategoryAttribute>().ReverseMap();
        }
    }
}
