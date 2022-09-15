using Application.Requests;
using Domain.Entities;

namespace Application.Specifications;

public class ProductsWithBrandsAndColorSpecification : Specification<Product>
{
     public ProductsWithBrandsAndColorSpecification(ProductSpecParams productParams) : base(x =>

     (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
     (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId) &&
     (!productParams.ColorId.HasValue || x.ColorId == productParams.ColorId) &&
     (!productParams.SizeId.HasValue || x.SizeId == productParams.SizeId))
     {
          AddInclude(x => x.Brand);
          AddInclude(x => x.Color);
          AddInclude(x => x.Size);
          AddOrderBy(x => x.Name);
          ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

          if (!string.IsNullOrEmpty(productParams.Sort))
          {
               switch (productParams.Sort)
               {
                    case "priceAsc":
                         AddOrderBy(x => x.Price);
                         break;
                    case "priceDesc":
                         AddOrderByDescending(p => p.Price);
                         break;
                    default:
                         AddOrderBy(n => n.Name);
                         break;
               }
          }
     }

     public ProductsWithBrandsAndColorSpecification(int id) : base(x => x.Id == id)
     {
          AddInclude(x => x.Brand);
          AddInclude(x => x.Color);
     }

     #region step by step

     //public ProductsWithBrandsAndColorSpecification()
     //{
     //     AddInclude(x => x.Brand);
     //     AddInclude(x => x.Color);
     //}

     //public ProductsWithBrandsAndColorSpecification(string sort)
     //{
     //     AddInclude(x => x.Brand);
     //     AddInclude(x => x.Color);
     //     AddOrderBy(x => x.Name);
     //}

     //public ProductsWithBrandsAndColorSpecification(string sort)
     //{
     //     AddInclude(x => x.Brand);
     //     AddInclude(x => x.Color);
     //     AddOrderBy(x => x.Name);

     //     if (!string.IsNullOrEmpty(sort))
     //     {
     //          switch (sort)
     //          {
     //               case "priceAsc":
     //                    AddOrderBy(x => x.Price);
     //                    break;
     //               case "priceDesc":
     //                    AddOrderByDescending(p => p.Price);
     //                    break;
     //               default:
     //                    AddOrderBy(n => n.Name);
     //                    break;
     //          }
     //     }
     //}

     //public ProductsWithBrandsAndColorSpecification(string? sort, int? brandId, int? colorId, int? sizeId) : base(x =>
     //          (!brandId.HasValue || x.BrandId == brandId) &&
     //          (!colorId.HasValue || x.ColorId == colorId) &&
     //          (!sizeId.HasValue || x.SizeId == sizeId))
     //{
     //     AddInclude(x => x.Brand);
     //     AddInclude(x => x.Color);
     //     AddInclude(x => x.Size);
     //     AddOrderBy(x => x.Name);

     //     if (!string.IsNullOrEmpty(sort))
     //     {
     //          switch (sort)
     //          {
     //               case "priceAsc":
     //                    AddOrderBy(x => x.Price);
     //                    break;
     //               case "priceDesc":
     //                    AddOrderByDescending(p => p.Price);
     //                    break;
     //               default:
     //                    AddOrderBy(n => n.Name);
     //                    break;
     //          }
     //     }
     //}

     #endregion
}
