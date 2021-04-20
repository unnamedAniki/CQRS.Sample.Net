using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Database.Context;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Category.GetAllUseCase;

namespace Sample.Database.Commands.Category
{
    public class GetAllCategoriesDBQueryHandler : IDBQueryHandler<GetAllCategoriesDBQuery, List<CategoryItem>>
    {
        private readonly SampleContext context;
        private readonly IMapper mapper;

        public GetAllCategoriesDBQueryHandler(SampleContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CategoryItem>> Handle(GetAllCategoriesDBQuery request, CancellationToken cancellationToken)
        {
            return await context.Categories.Select(x => mapper.Map<CategoryItem>(x)).ToListAsync(cancellationToken: cancellationToken);

        }
    }
}
