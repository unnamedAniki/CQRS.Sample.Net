using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Category;
using Sample.Database.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Database.Commands.Category
{
    class GetCategoryDBQueryHandler : IDBQueryHandler<GetCategoryDBQuery, Application.Category.Category>
    {
        private readonly SampleContext context;
        private readonly IMapper mapper;

        public GetCategoryDBQueryHandler(SampleContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Application.Category.Category> Handle(GetCategoryDBQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.Include(c => c.Attributes)
                .FirstOrDefaultAsync(x => x.Id == request.CategoryId);

            return mapper.Map<Application.Category.Category>(category);
        }
    }
}
