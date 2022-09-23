using Application.Abstractions.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AuthenticationOperations.Command;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly SignInManager<AppUser> _signInManager;
     private readonly ITokenHandler _tokenHandler;

     public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
     {
          _userManager = userManager;
          _signInManager = signInManager;
          _tokenHandler = tokenHandler;
     }

     public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     {
          AppUser user = await _userManager.FindByNameAsync(request.UserName);
          //AppUser user = await _userManager.FindByEmailAsync(request.Email);
          if (user == null)
               return new LoginCommandUnsuccessfulResponse()
               {
                    Message = "Girdiğiniz kullanıcı adı veri tabanında bulunamadı!"
               };

          SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

          if (result.Succeeded)
               return new LoginCommandSuccessfulResponse()
               {
                    Token = _tokenHandler.CreateAccessToken(5)
               };
          else
               return new LoginCommandUnsuccessfulResponse()
               {
                    Message = "Girdiğiniz şifre hatalı!"
               };
     }
}
