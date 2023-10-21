using AppStore.Domain.Primers;

namespace AppStore.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role(string name, string slug)
        {
            Name = name;
            Slug = slug;

            Users = new List<User>();
        }

        public string Name { get; private set; }
        public string Slug { get; private set; }

        public List<User> Users { get; set; }
    }
}