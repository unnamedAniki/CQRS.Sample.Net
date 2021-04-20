using AutoMapper;
using Sample.API.Controllers;
using Sample.Application.Category;
using Sample.Application.Category.GetAllUseCase;

namespace Sample.API.AutoMapper
{
    public class ApplicationToApiProfile : Profile
    {
        public ApplicationToApiProfile()
        {
            CreateMap<CategoryItem, CategoryResponse>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<CategoryAttributeRequest, CategoryAttribute>();
        }
    }
}
