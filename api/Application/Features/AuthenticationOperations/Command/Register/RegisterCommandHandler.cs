using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.AuthenticationOperations.Command;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
     {
          var userEntity = _mapper.Map<AppUser>(request);

          IdentityResult result = await _userManager.CreateAsync(userEntity, request.Password);

          if (result.Succeeded)
          {
               return new()
               {
                    IsSucceeded = true,
                    Message = "Kullanıcı başarıyla oluşturulmuştur."
               };
          }
          else
          {
               RegisterCommandResponse response = new();

               response.IsSucceeded = false;
               foreach (var error in result.Errors)
                    response.Message += $"{error.Description}\n";
               return response;
          }
     }
}
