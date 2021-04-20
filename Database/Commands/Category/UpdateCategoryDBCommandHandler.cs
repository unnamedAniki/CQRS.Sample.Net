using AutoMapper;
using MediatR;
using Sample.Application.Category.UpdateCategoryUseCase;
using Sample.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Database.Commands.Category
{
    class UpdateCategoryDBCommandHandler : IDBCommandHandler<UpdateCategoryDBCommand>
    {
        private readonly SampleContext context;
        private readonly IMapper mapper;

        public UpdateCategoryDBCommandHandler(SampleContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryDBCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.Category.Id);
            category.Name = request.Category.Name;
            category.Description = request.Category.Description;

            foreach(var attr in request.Category.Attributes)
            {
                var dbAttr = category.Attributes.FirstOrDefault(x => x.Id == attr.Id);
                if (dbAttr == null)
                {
                    dbAttr = new Entities.Attribute() { Id = attr.Id, Category = category };
                    context.Attributes.Add(dbAttr);
                }
                dbAttr.Type = attr.Type;
                dbAttr.Name = attr.Name;
            }
            await context.SaveChangesAsync();
            return new Unit();
        }
    }
}
