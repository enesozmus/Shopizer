namespace Application.Features.ColorOperations.Queries;

public class GetColorsQueryResponse
{
     public int Id { get; set; }
     public string Name { get; set; }
     public int Stock { get; set; }
     public float Price { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime? LastModifiedDate { get; set; }
}
