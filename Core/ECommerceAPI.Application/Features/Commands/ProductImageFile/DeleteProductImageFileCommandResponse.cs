using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile
{
    public class DeleteProductImageFileCommandResponse
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Id { get; set; }
    }
}
