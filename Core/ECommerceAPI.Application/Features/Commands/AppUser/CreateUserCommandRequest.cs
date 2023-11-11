using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.AppUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string fullName { get; set; }
        public string userName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string rePassword { get; set; }
    }
}
