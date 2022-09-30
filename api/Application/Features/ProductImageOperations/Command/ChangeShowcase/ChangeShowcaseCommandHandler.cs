using Application.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductImageOperations.Command;

public class ChangeShowcaseCommandHandler : IRequestHandler<ChangeShowcaseCommandRequest, Unit>
{
     private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

     public ChangeShowcaseCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository)
     {
          _productImageFileWriteRepository = productImageFileWriteRepository;
     }

     public async Task<Unit> Handle(ChangeShowcaseCommandRequest request, CancellationToken cancellationToken)
     {
          var query = _productImageFileWriteRepository.Table
               .Include(p => p.Products)
               .SelectMany(p => p.Products, (pif, p) => new
               {
                    pif,
                    p
               });

          var data = await query.FirstOrDefaultAsync(p => p.p.Id == request.ProductId && p.pif.Showcase == true);

          if (data != null)
               data.pif.Showcase = false;

          var image = await query.FirstOrDefaultAsync(p => p.pif.Id == request.ImageId);
          if (image != null)
               image.pif.Showcase = true;

          await _productImageFileWriteRepository.SaveAsync();

          return Unit.Value;
     }
}
