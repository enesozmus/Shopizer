using FluentValidation;

namespace Application.Features.ProductOperations.Command;

public class ValidatorForCreateProductCommand : AbstractValidator<CreateProductCommandRequest>
{
     public ValidatorForCreateProductCommand()
     {
          RuleFor(p => p.Name).NotEmpty();
          RuleFor(p => p.Name).NotNull();
          RuleFor(p => p.Name).MinimumLength(2);
          RuleFor(p => p.Name).MaximumLength(100);

          RuleFor(p => p.Price).NotNull();
          RuleFor(p => p.Price).GreaterThanOrEqualTo(1);

          RuleFor(p => p.Stock).NotNull();
          RuleFor(p => p.Stock).GreaterThanOrEqualTo(0);

          RuleFor(p => p.IsOfferable).NotNull();

          RuleFor(p => p.IsSold).NotNull();

          RuleFor(p => p.CategoryId).NotEmpty();
          RuleFor(p => p.CategoryId).NotNull();
          RuleFor(p => p.CategoryId).GreaterThanOrEqualTo(1);

          RuleFor(p => p.BrandId).NotEmpty();
          RuleFor(p => p.BrandId).NotNull();
          RuleFor(p => p.BrandId).GreaterThanOrEqualTo(1);

          RuleFor(p => p.ColorId).NotEmpty();
          RuleFor(p => p.ColorId).NotNull();
          RuleFor(p => p.ColorId).GreaterThanOrEqualTo(1);

          RuleFor(p => p.SizeId).NotEmpty();
          RuleFor(p => p.SizeId).NotNull();
          RuleFor(p => p.SizeId).GreaterThanOrEqualTo(1);

          RuleFor(p => p.AppUserId).NotEmpty();
          RuleFor(p => p.AppUserId).NotNull();
          RuleFor(p => p.AppUserId).GreaterThanOrEqualTo(1);
     }
}
