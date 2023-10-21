namespace AppStore.Domain.ValueObjects
{
    public record DeliveryAddress(int Number,
                                  string Street,
                                  string Complement,
                                  string City,
                                  string State,
                                  string Country,
                                  string ZipCode)
    {
    }
}