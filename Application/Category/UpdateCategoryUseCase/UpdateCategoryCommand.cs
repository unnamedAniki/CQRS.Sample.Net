using Sample.Application.Commands;

namespace Sample.Application.Category.UpdateCategoryUseCase
{
    public class UpdateCategoryCommand: CommandBase
    {
        public UpdateCategoryCommand(Category category)
        {
            Category = category;
        }
        public Category Category { get; set; }
    }
}
