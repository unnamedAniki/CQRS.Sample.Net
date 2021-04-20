using System.Collections.Generic;

namespace Sample.Database.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
