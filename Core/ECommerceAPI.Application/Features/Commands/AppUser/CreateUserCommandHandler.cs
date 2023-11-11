using ECommerceAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.AppUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<ECommerceAPI.Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          IdentityResult identityResult =   await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.fullName,
                UserName = request.userName,
                Email = request.mail
            },request.password
            );


            CreateUserCommandResponse response = new() { Succeeded = identityResult.Succeeded };


            if (identityResult.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturuldu.";
            else
                response.Message = "Kullanıcı kaydı oluşturulurken bir hata oluştu.";
            return response;
        }
    }
}
