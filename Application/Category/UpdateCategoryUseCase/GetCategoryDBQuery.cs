using Sample.Application.DBCommands;
using System;

namespace Sample.Application.Category
{
    public class GetCategoryDBQuery : IDBQuery<Category>
    {
        public Guid CategoryId { get; private set; }

        public GetCategoryDBQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
