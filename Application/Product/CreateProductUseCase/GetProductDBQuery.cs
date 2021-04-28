using System;
using Sample.Application.DBCommands;

namespace Sample.Application.Product.CreateProductUseCase
{
    public class GetProductDBQuery : IDBQuery<Product>
    {
        public Guid ProductId { get; private set; }

        public GetProductDBQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
