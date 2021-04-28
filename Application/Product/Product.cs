using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.Enums;

namespace Sample.Application.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category.Category Category { get; set; }
        public IEnumerable<ProductAttribute> Values { get; set; }
    }

    public class ProductAttribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AttributeType Type { get; set; }
    }
}
