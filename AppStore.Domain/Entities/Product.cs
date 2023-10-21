using AppStore.Domain.Primers;

namespace AppStore.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Product(string title,
                       string description,
                       decimal price,
                       decimal pricePerKg,
                       Guid categoryId) : base()
        {
            Title = title;
            Description = description;
            Slug = title.Replace(" ", "-");
            Price = price;
            PricePerKg = pricePerKg;
            CategoryId = categoryId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public decimal Price { get; private set; }
        public decimal PricePerKg { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category? Category { get; set; }

        public void SetupProduct(string title, string description, decimal price, decimal pricePerKg)
        {
            Title = title;
            Description = description;
            Price = price;
            PricePerKg = pricePerKg;

        }
    }
}