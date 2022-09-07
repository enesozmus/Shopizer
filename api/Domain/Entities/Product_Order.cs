namespace Domain.Entities;

public class Product_Order
{
     public int OrderId { get; set; }
     public Order Order { get; set; }

     public int ProductId { get; set; }
     public Product Product { get; set; }
}
