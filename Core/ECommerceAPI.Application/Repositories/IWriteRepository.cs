using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Update(T model);
        bool UpdateRange(List<T> model);
        bool Remove(T model);
        Task<bool> Remove(string id);
        bool RemoveRange(List<T> datas);

        Task<int> SaveAsync();
    }
}
