using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Sample.Application.Category.UpdateCategoryUseCase;
using Sample.Application.Commands;

namespace Sample.Application.Product.CreateProductUseCase
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private IMediator mediator;

        public CreateProductCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await mediator.Send(new GetProductDBQuery(request.Product.Id), cancellationToken);

            if (request.Product == null)
            {
                throw new BusinessLogicException("Недопустимо добавлять пустой продукт");
            }

            if (product.Id == request.Product.Id)
            {
                throw new BusinessLogicException("Недопустимо добавлять продукт с существующим ID");
            }

            if (request.Product.Category == null)
            {
                throw new BusinessLogicException("Недопустимо добавлять продукт с пустым параметром категории");
            }

            if (product.Category.Attributes.Any(a => request.Product.Category.Attributes.Any(a1 => a1.Id == a.Id)))
            {
                throw new BusinessLogicException("Недопустимо добавлять существующий атрибут категории");
            }

            await mediator.Send(new CreateProductDBCommand(request.Product));

            return new Unit();
        }
    }
}
