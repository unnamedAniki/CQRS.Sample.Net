using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.DBCommands;

namespace Sample.Application.Product.CreateProductUseCase
{
    public class CreateProductDBCommand: IDBCommand
    {
        public CreateProductDBCommand(Product product)
        {
            Product = product;
        }
        public Product Product { get; set; }
    }
}
