using System;

namespace Sample.Database.Entities
{
    public class ProductAttributeValue: Entity
    {
        public Attribute Attribute { get; set; }
        public String Value { get; set; }
    }
}
