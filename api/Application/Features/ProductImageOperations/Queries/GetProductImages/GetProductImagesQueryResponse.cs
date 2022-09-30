namespace Application.Features.ProductImageOperations.Queries;

public class GetProductImagesQueryResponse
{
     public int Id { get; set; }
     public string Path { get; set; }
     public string FileName { get; set; }
     public bool Showcase { get; set; }
}
