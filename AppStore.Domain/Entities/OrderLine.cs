namespace AppStore.Domain.Entities
{
    public sealed class OrderLine
    {
        public OrderLine(string orderNumber,
                         string title,
                         int qty,
                         decimal price)
        {
            OrderNumber = orderNumber;
            Title = title;
            Qty = qty;
            Price = price;
           
        }

        public string OrderNumber { get; init; }
        public Order? Order { get; set; }
        public string Title { get; init; }
        public Guid ProductId { get; private set; }
        public Product? Product { get; set; }
        public int Qty { get; private set; }
        public decimal Price { get; private set; }

    }
}