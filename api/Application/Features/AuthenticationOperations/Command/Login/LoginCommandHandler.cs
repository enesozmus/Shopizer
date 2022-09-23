using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AuthenticationOperations.Command;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly SignInManager<AppUser> _signInManager;

     public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
     {
          _userManager = userManager;
          _signInManager = signInManager;
     }

     public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     {
          AppUser user = await _userManager.FindByNameAsync(request.UserName);
          //AppUser user = await _userManager.FindByEmailAsync(request.Email);
          if (user == null)
               return new()
               {
                    Message = "Girdiğiniz kullanıcı adı veri tabanında bulunamadı!"
               };
          SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

          if (result.Succeeded)
               return new()
               {
                    Message = "Kimlik doğrulama başarılı!"
               };
          else
               return new()
               {
                    Message = "Girdiğiniz şifre hatalı!"
               };
     }
}
