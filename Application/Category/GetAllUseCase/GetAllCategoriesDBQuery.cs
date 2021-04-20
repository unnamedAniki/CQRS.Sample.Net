using Sample.Application.DBCommands;
using System.Collections.Generic;

namespace Sample.Application.Category.GetAllUseCase
{
    public class GetAllCategoriesDBQuery : IDBQuery<List<CategoryItem>>
    {
        public GetAllCategoriesDBQuery()
        {
        }
    }
}
