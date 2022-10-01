namespace Application.Features.BasketOperations.Queries;

public class GetBasketItemsQueryResponse
{
     public int BasketItemId { get; set; }
     public string Name { get; set; }
     public float Price { get; set; }
     public int Quantity { get; set; }
}
