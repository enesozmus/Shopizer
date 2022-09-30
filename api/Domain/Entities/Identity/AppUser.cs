using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<int>
{
     public string FirstName { get; set; }
     public string LastName { get; set; }

     public string? RefreshToken { get; set; }
     public DateTime? RefreshTokenEndDate { get; set; }

     public ICollection<Offer> Offers { get; set; }
     public ICollection<Product> Products { get; set; }
     public ICollection<Basket> Baskets { get; set; }
}
