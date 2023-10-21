using AppStore.Domain.Primers;
using AppStore.Domain.ValueObjects;

namespace AppStore.Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        public Order(Guid userId,
                    short qty,
                    decimal deliveryFee,
                    decimal discount) : base()
        {
            UserId = userId;
            Qty = qty;
            OrderNumber = Guid.NewGuid().ToString()[..8].Normalize();
            ShipmentID = GenerateShipmentID();
            PostedAt = DateTimeOffset.UtcNow;
            DeliveryFee = deliveryFee;
            Discount = discount;


            _lines = new List<OrderLine>();
        }

        private List<OrderLine> _lines;

        public Guid UserId { get; init; }
        public User? User { get; private set; }
        public short Qty { get; private set; }
        public string OrderNumber { get; init; }
        public string ShipmentID { get; init; }
        public DateTimeOffset PostedAt { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; } = null!;
        public IReadOnlyCollection<OrderLine> OrderLines => _lines;

        public void SetupServices(IReadOnlyCollection<Product> products)
        {
            foreach (var product in products)
            {
                var subTotal = product.Price + product.PricePerKg * Qty;
                TotalPrice += subTotal + DeliveryFee - Discount;

                _lines.Add(new OrderLine(OrderNumber, product.Title, Qty, TotalPrice));
            }
        }

        public void UpdateOrder(short qty)
        {
            Qty = qty;
        }

        private static string GenerateShipmentID()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ@";
            const string numbers = "0123456789";

            var code = new char[10];
            var ramdom = new Random();

            for (var i = 0; i < chars.Length; i++)
            {
                code[i] = chars[ramdom.Next(chars.Length)];
            }

            for (var i = 5; i < 10; i++)
            {
                code[i] = numbers[ramdom.Next(numbers.Length)];
            }

            return new string(code);
        }

    }
}
