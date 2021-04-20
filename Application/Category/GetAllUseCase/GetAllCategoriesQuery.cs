using Sample.Application.Commands;
using System;
using System.Collections.Generic;

namespace Sample.Application.Category.GetAllUseCase
{
    public class GetAllCategoriesQuery : IQuery<List<CategoryItem>>
    {
    }

    public class CategoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
