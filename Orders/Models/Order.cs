namespace Orders.Models;

    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }

        public Order(int id, string number, decimal total, DateTime createdAt)
        {
            Id = id;
            Number = number;
            Total = total;
            CreatedAt = createdAt;
        }
}