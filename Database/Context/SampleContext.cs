using Sample.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Attribute = Sample.Database.Entities.Attribute;

namespace Sample.Database.Context
{
    public class SampleContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set;}

        private readonly ILoggerFactory loggerFactory;
        
        public SampleContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            this.loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSnakeCaseNamingConvention().UseLoggerFactory(loggerFactory);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categoryId = new Guid("A427F99E-D620-49FB-AFA3-69B81B41556C");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = categoryId, Name = "Super toy",
                Description = "Supper pupper toys"
            });
            modelBuilder.Entity<Attribute>().HasData(new Attribute
            {
                Id = new Guid("C732A300-3DD9-46B6-8D38-0B6512212FA1"), Name="Height", Type = Application.Enums.AttributeType.Int, CategoryId = categoryId
            });
        }
    }
}
