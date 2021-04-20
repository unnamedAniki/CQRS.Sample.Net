using System.Collections.Generic;

namespace Sample.Database.Entities
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public IEnumerable<ProductAttributeValue> Values { get; set; }
    }
}
