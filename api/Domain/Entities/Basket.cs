namespace Domain.Entities;

public class Basket : BaseEntity
{
     public int AppUserId { get; set; }
     public AppUser AppUser { get; set; }

     public ICollection<BasketItem> BasketItems { get; set; }

     public Order Order { get; set; }
}
