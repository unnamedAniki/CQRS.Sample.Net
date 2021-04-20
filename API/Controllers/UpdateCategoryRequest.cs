using Sample.Application.Enums;
using System;
using System.Collections.Generic;

namespace Sample.API.Controllers
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryAttributeRequest> Attributes { get; set; }
    }

    public class CategoryAttributeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AttributeType Type { get; set; }
    }
}
