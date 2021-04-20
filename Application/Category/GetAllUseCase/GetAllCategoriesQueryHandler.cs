using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.Application.Commands;

namespace Sample.Application.Category.GetAllUseCase
{
    class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryItem>>
    {
        private readonly IMediator mediator;

        public GetAllCategoriesQueryHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<List<CategoryItem>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetAllCategoriesDBQuery(), cancellationToken);
        }
    }
}
