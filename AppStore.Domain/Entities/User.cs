using AppStore.Domain.Primers;
using AppStore.Domain.ValueObjects;

namespace AppStore.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public User(string firstName,
                    string lastName,
                    string email,
                    string passwordHash) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            Slug = email.Replace("@", "-").Replace(".", "-");
            Active = true;

            Orders = new List<Order>();
            Roles = new List<Role>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; init; }
        public string PasswordHash { get; private set; }
        public string Slug { get; init; }
        public bool Active { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; } = null!;
        public List<Order> Orders { get; private set; }
        public List<Role> Roles { get; private set; }

        public void Deactivate()
            => Active = false;

        public void SetupUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void SetPassword(string password)
        {
            PasswordHash = password;
        }
        
    }
}
