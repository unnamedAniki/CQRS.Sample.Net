using MediatR;
using Sample.Application.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Category.UpdateCategoryUseCase
{
    class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private IMediator mediator;

        public UpdateCategoryCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await mediator.Send(new GetCategoryDBQuery(request.Category.Id), cancellationToken);

            if (request.Category.Attributes.GroupBy(x=>x.Id).Select(g=>new {Id=g.Key, Count = g.Count() }).Any(x => x.Count > 1))
            {
                throw new BusinessLogicException("В запросе есть атрибуты с одинаковым Id");
            }

            // Проверяем что нельзя удалять атрибут
            if (category.Attributes.Any(a => !request.Category.Attributes.Any(a1 => a1.Id == a.Id)))
            {
                throw new BusinessLogicException("Недопустимо удалять атрибут категории");
            }

            // TODO Реализовать логику сравнения атрибутов чтобы нельзя было изменять тип атрибута,
            // можно было только добавлять атрибут и изменять его наименование
            if (category.Attributes.Any(a => request.Category.Attributes.Any(a1 => (a1.Type != a.Type) && a1.Id == a.Id)))
            {
                throw new BusinessLogicException("Недопустимо изменять типа атрибута категории");
            }


            await mediator.Send(new UpdateCategoryDBCommand(request.Category));

            return new Unit();
        }
    }

}
