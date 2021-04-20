using Sample.Application.DBCommands;

namespace Sample.Application.Category.UpdateCategoryUseCase
{
    public class UpdateCategoryDBCommand: IDBCommand
    {
        public UpdateCategoryDBCommand(Category category)
        {
            Category = category;
        }
        public Category Category { get; set; }
    }
}
