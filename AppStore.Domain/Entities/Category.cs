using AppStore.Domain.Primers;

namespace AppStore.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Category(string title, string description) : base()
        {
            Title = title;
            Description = description;
            Slug = title.Replace(" ", "-").ToLower();
            IsDeleted = false;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; init; }
        public bool IsDeleted { get; private set; }
        public List<Product> Products { get; set; } = null!;

        public void SetupCategory(string title, string description)
        {
            Title = title;
            Description = description;

        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
