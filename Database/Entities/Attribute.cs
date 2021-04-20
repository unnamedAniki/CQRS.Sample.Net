using Sample.Application.Enums;
using System;

namespace Sample.Database.Entities
{
    public class Attribute: Entity
    {
        public string  Name { get; set; }
        public AttributeType Type { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
