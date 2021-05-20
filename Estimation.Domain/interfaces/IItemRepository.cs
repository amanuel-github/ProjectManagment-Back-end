using Estimation.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimation.Domain.interfaces
{
    public interface IItemRepository 
    {

        IQueryable<Item> FindAll();
        Task<Item> FindByCondition(int id);
        void Create(Item entity);
        Task<Item> Update(Item entity);
        void Delete(Item entity);

        Task<int> SaveChangesAsync();
    }
}
