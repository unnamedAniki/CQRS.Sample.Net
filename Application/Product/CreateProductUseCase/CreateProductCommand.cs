using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.Commands;

namespace Sample.Application.Product.CreateProductUseCase
{
    public class CreateProductCommand : CommandBase
    {
        public CreateProductCommand(Product product)
        {
            Product = product;
        }
        public Product Product { get; set; }

    }
}
