﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> uploadAsync(string pathOrContainerName, IFormFileCollection files);

        Task  DeleteAsync(string pathOrContainerName, string fileName);
    
        List<string> GetFiles(string pathrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    
    }
}
