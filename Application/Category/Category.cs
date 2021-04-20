using Sample.Application.Enums;
using System;
using System.Collections.Generic;

namespace Sample.Application.Category
{
    public class Category 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryAttribute> Attributes { get; set; }
    }

    public class CategoryAttribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AttributeType Type { get; set; }
    }
}
